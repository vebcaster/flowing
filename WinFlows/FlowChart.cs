using WinFlows.Blocks;
using WinFlows.Blocks.Connectors;
using WinFlows.Expressions;
using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators.Logical;
using WinFlows.Expressions.Variables;

namespace WinFlows
{
    public partial class FlowChart : UserControl
    {
        public class CodeColumn
        {
            public string Name;
            public int ActualColumnIndex = int.MinValue;
            public int WesternSubtreeWidth = int.MinValue;
            public int EasternSubtreeWidth = int.MinValue;
            public int FullWingspan => WesternSubtreeWidth + EasternSubtreeWidth + 1;

            public string ParentName;
            public int Offset;
            public CodeColumn(string name, string parentName, int offset, int westernSubtreeWidth, int easternSubtreeWidth)
            {
                Name = name;
                ParentName = parentName;
                Offset = offset;
                WesternSubtreeWidth = westernSubtreeWidth;
                EasternSubtreeWidth = easternSubtreeWidth;
            }
        }

        public Dictionary<string, CodeColumn> CodeCols = new Dictionary<string, CodeColumn>();
        private int _nextColName = 0;

        public static FlowChart Instance { get; private set; } = null!;

        private Block StartBlock { get; set; } = null!;
        private Block EndBlock { get; set; } = null!;
        private Control[] _currentBlockMarkers = new Control[4];
        private Block? _currentBlock = null;
        private Block? CurrentBlock
        {
            get => _currentBlock;
            set
            {
                _currentBlock = value;
                UpdateCurrentBlockMarker(_currentBlock);
            }
        }

        private int Delay => speedBar.Value switch
        {
            0 => 0,
            1 => 125,
            2 => 250,
            3 => 500,
            4 => 1000,
            5 => 2000,
            _ => throw new ArgumentOutOfRangeException($"Speed {speedBar.Value} is not valid.")
        };

        public FlowChart()
        {
            InitializeComponent();

            Instance = this;
            for (int i = 0; i < _currentBlockMarkers.Length; i++)
            {
                _currentBlockMarkers[i] = new Control();
                _currentBlockMarkers[i].BackColor = ColorScheme.CurrentBlockMarker;
                Controls.Add(_currentBlockMarkers[i]);
                _currentBlockMarkers[i].Visible = false;
            }
            ResizeCurrentBlockMarkers();

            Reset();
        }

        public void Reset()
        {
            RemoveNonBlockChildControls();

            StartBlock = new StartBlock();
            EndBlock = new EndBlock();
            var down = new DownConnector
            {
                From = StartBlock,
                South = EndBlock
            };
            StartBlock.South = down;

            var (x, y) = BlockFactory.CreateBlocksForInsert("BLOCK:IF");
            down.Insert(x, y);

            Variables.Create("a", ExpressionTypes.Logical);
            Variables.Create("b", ExpressionTypes.Logical);
            Variables.Create("c", ExpressionTypes.Logical);

            Variables.Create("x", ExpressionTypes.Number);
            Variables.Create("y", ExpressionTypes.Number);
            Variables.Create("z", ExpressionTypes.Number);

            Variables.Create("s1", ExpressionTypes.String);
            Variables.Create("s2", ExpressionTypes.String);
            Variables.Create("s3", ExpressionTypes.String);

            Variables.Create("n1", ExpressionTypes.ListOfNumbers);
            Variables.Create("n2", ExpressionTypes.ListOfNumbers);
            Variables.Create("n3", ExpressionTypes.ListOfNumbers);

            var t1 = new LogicalConstant() { Value = true };
            var f1 = new LogicalConstant() { Value = false };

            var o2 = new LogicalAndOperator();
            var o3 = new LogicalAndOperator();

            o3.Operands[0] = Variables.Get("b");
            o3.Operands[1] = f1;

            o2.Operands[0] = o3;
            o2.Operands[1] = Variables.Get("c");

            var le = new LogicalAndOperator();
            le.Operands[0] = t1;
            le.Operands[1] = o2;

            ((IfBlock)x).Expression = le;

            Reposition();
        }

        private void RemoveNonBlockChildControls()
        {
            var toRemove = new List<Control>();

            foreach (Control child in Controls)
                if (child is Block)
                    toRemove.Add(child);

            toRemove.ForEach(x => Controls.Remove(x));
        }

        public void Reposition()
        {
            var origScroll = AutoScrollPosition;
            AutoScrollPosition = new Point(0, 0);

            foreach (Control child in Controls)
                if (child is Block)
                {
                    ((Block)child).Row = -1;
                    ((Block)child).CodeColumnName = string.Empty;
                }

            MarkRows(StartBlock, 1);

            CodeCols.Clear();
            _nextColName = 0;
            MarkColumns(StartBlock, string.Empty, 0);

            SetActualColumnIndexes();

            foreach (var col in CodeCols.Keys)
                SetColumn(col, CodeCols[col].ActualColumnIndex);

            Reposition(StartBlock);
            SendOverlappingConnectorsBack();
            ResizeCurrentBlockMarkers();
            UpdateCurrentBlockMarker(CurrentBlock);

            AutoScrollPosition = origScroll;
        }

        private void SendOverlappingConnectorsBack()
        {
            var list = new List<Connector>();
            foreach (Control child in Controls)
                if (child is DownRightUpLeftConnector || child is DownFirstSingleBendedConnector)
                    list.Add((Connector)child);

            var arr = list.ToArray();

            // Bubble sort
            var done = false;
            while (!done)
            {
                done = true;

                for (int i = 0; i < arr.Length - 1; i++)
                    if (arr[i].Width > arr[i + 1].Width)
                    {
                        (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                        done = false;
                    }
            }

            // Send them back in the right order
            for (int i = 0; i < arr.Length; i++)
                arr[i].SendToBack();
        }

        private void SetActualColumnIndexes()
        {
            var colZero = CodeCols["c0"];
            colZero.ActualColumnIndex = 0;
            colZero.Offset = 0;

            // First pass: set index relative to c0. Keep track of minimum too
            bool done = false;
            var minIndex = 0;
            while (!done)
            {
                done = true;
                foreach (var column in CodeCols.Values)
                    if (column.ActualColumnIndex == int.MinValue
                        && !column.ParentName.Equals(string.Empty)
                        && CodeCols[column.ParentName].ActualColumnIndex != int.MinValue)
                    {
                        column.ActualColumnIndex = CodeCols[column.ParentName].ActualColumnIndex + column.Offset;
                        done = false;

                        if (minIndex > column.ActualColumnIndex)
                            minIndex = column.ActualColumnIndex;
                    }
            }

            // Second pass: set absolute index
            foreach (var column in CodeCols.Values)
                column.ActualColumnIndex += -minIndex;
        }

        private (int, int) MarkColumns(Block block, string parentColumnName, int offset)
        {
            var codeColName = $"c{_nextColName++}";
            var west = 0;
            var east = 0;

            var curent = block;
            var done = false;
            while (!done)
            {
                curent.CodeColumnName = codeColName;

                if (curent.West != null)
                {
                    (var w, var e) = MarkColumns(curent.West, codeColName, -1);
                    if (w + e + 1 > west)
                        west = w + e + 1;
                }
                if (curent.East != null)
                {
                    (var w, var e) = MarkColumns(curent.East, codeColName, +1);
                    if (w + e + 1 > east)
                        east = w + e + 1;
                }

                if (curent.South != null && curent.South is LoopFlowConnector && !string.IsNullOrEmpty(curent.South.CodeColumnName))
                    done = true;
                else if (curent.South != null && curent.South is not SplitFlowConnector)
                    curent = curent.South;
                else if (curent is IfBlock)
                    curent = ((IfBlock)curent).MergeConnector;
                else
                    done = true;
            }

            if (block is RightDownConnector && ((Connector)block).From is WhileBlock)
                east++;

            var newCol = new CodeColumn(
                codeColName, parentColumnName,
                offset < 0 ? -east - 1 : west + 1,
                west, east);
            CodeCols.Add(newCol.Name, newCol);
            return (west, east);
        }

        private void SetColumn(string colName, int col)
        {
            foreach (Control child in Controls)
                if (child is Block && ((Block)child).CodeColumnName.Equals(colName))
                    ((Block)child).Column = col;
        }

        private void MarkRows(Block block, int row)
        {
            if (block is SplitFlowConnector && block.Row >= row)    // We already went down that path
                return;

            if (block is LoopFlowConnector && block.Row > 0)    // We already went down that path
                return;

            block.Row = row;

            if (block.West != null)
                MarkRows(block.West, row);
            if (block.East != null)
                MarkRows(block.East, row);

            if (block.South != null)
                MarkRows(block.South, row + block.SouthOffset);
        }

        private void Reposition(Block block)
        {
            block.ComputeSize();
            block.ComputeLocation();

            block.Invalidate();

            if (block.East != null)
                Reposition(block.East);

            if (block.West != null)
                Reposition(block.West);

            if (block.South != null && block.South.Row >= block.Row) // Avoid infinite loops caused by loop blocks
                Reposition(block.South);
        }

        public async void Execute()
        {
            if (CurrentBlock == null)
                CurrentBlock = StartBlock;

            while (CurrentBlock != null)
            {
                await Task.Delay(Delay);
                CurrentBlock = CurrentBlock.Execute();
                await Task.Delay(Delay);
            }
        }

        private void ResizeCurrentBlockMarkers()
        {
            var block = new Block();
            block.Width = Globals.BlockSize.Width;
            block.Height = Globals.BlockSize.Height;
            Controls.Remove(block);
            var surround = GetMarkerRectAroundBlock(block);

            _currentBlockMarkers[0].Width = surround.Width - (int)Globals.CurrentBlockMarkerStroke;
            _currentBlockMarkers[0].Height = (int)Globals.CurrentBlockMarkerStroke;
            _currentBlockMarkers[1].Width = (int)Globals.CurrentBlockMarkerStroke;
            _currentBlockMarkers[1].Height = surround.Height - (int)Globals.CurrentBlockMarkerStroke;
            _currentBlockMarkers[2].Width = surround.Width - (int)Globals.CurrentBlockMarkerStroke;
            _currentBlockMarkers[2].Height = (int)Globals.CurrentBlockMarkerStroke;
            _currentBlockMarkers[3].Width = (int)Globals.CurrentBlockMarkerStroke;
            _currentBlockMarkers[3].Height = surround.Height - (int)Globals.CurrentBlockMarkerStroke;
        }

        private void UpdateCurrentBlockMarker(Block? newCurrent)
        {
            if (newCurrent == null)
                foreach (var block in _currentBlockMarkers)
                    block.Visible = false;
            else
            {
                _currentBlockMarkers[0].Left = newCurrent.Left - (int)Globals.CurrentBlockMarkerStroke * 2;
                _currentBlockMarkers[0].Top = newCurrent.Top - (int)Globals.CurrentBlockMarkerStroke * 2;
                _currentBlockMarkers[1].Left = newCurrent.Right + (int)Globals.CurrentBlockMarkerStroke;
                _currentBlockMarkers[1].Top = newCurrent.Top - (int)Globals.CurrentBlockMarkerStroke * 2;
                _currentBlockMarkers[2].Left = newCurrent.Left - (int)Globals.CurrentBlockMarkerStroke * 2;
                _currentBlockMarkers[2].Top = newCurrent.Bottom + (int)Globals.CurrentBlockMarkerStroke;
                _currentBlockMarkers[3].Left = newCurrent.Left - (int)Globals.CurrentBlockMarkerStroke * 2;
                _currentBlockMarkers[3].Top = newCurrent.Top - (int)Globals.CurrentBlockMarkerStroke * 2;
                foreach (var block in _currentBlockMarkers)
                {
                    block.Visible = true;
                    block.BringToFront();
                }
            }
        }

        private void zoomBar_Scroll(object sender, EventArgs e)
        {
            Globals.ZoomFactor = zoomBar.Value / 100.0f;
        }

        private Rectangle GetMarkerRectAroundBlock(Block block)
        {
            return new Rectangle(
                (int)(block.Left - Globals.CurrentBlockMarkerStroke * 2),
                (int)(block.Top - Globals.CurrentBlockMarkerStroke * 2),
                (int)(block.Width + Globals.CurrentBlockMarkerStroke * 4),
                (int)(block.Height + Globals.CurrentBlockMarkerStroke * 4));
        }
    }
}
