using System.Text;
using WinFlows.Blocks;
using WinFlows.Blocks.Connectors;
using WinFlows.Expressions;
using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Operators.Logical;
using WinFlows.Expressions.Variables;
using WinFlows.Expressions.Variables.Lists;

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
                ResizeCurrentBlockMarkers();
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
            RemoveAllBlockChildControls();

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

            Variables.Create("b1", ExpressionTypes.ListOfLogicals);
            Variables.Create("b2", ExpressionTypes.ListOfLogicals);
            Variables.Create("b3", ExpressionTypes.ListOfLogicals);

            Variables.Create("str1", ExpressionTypes.ListOfStrings);
            Variables.Create("str2", ExpressionTypes.ListOfStrings);
            Variables.Create("str3", ExpressionTypes.ListOfStrings);

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

        public void DeleteBlock(Block block)
        {
            if (!Controls.Contains(block))
                throw new ArgumentException("Cannot find block to delete");

            // Find the True North and True South, connectors and blocks
            Connector northConn = null, southConn = null;
            Block northBlock = null, southBlock = null;
            var blocksToRemove = new List<Block>();

            // North
            foreach (var child in Controls)
                if (child is Connector &&
                    (
                        ((Connector)child).South == block
                        || ((Connector)child).East == block
                        || ((Connector)child).West == block
                    ))
                {
                    northConn = (Connector)child;
                    if (northConn is LoopFlowConnector)
                    {
                        foreach (var child2 in Controls)
                            if (child2 is Connector &&
                                child2 is not RightUpLeftConnector &&
                                child2 is not DownRightUpLeftConnector &&
                                (
                                    ((Connector)child2).South == northConn
                                    || ((Connector)child2).East == northConn
                                    || ((Connector)child2).West == northConn
                                ))
                            {
                                northConn = (Connector)child2;
                                break;
                            }
                    }
                    northBlock = northConn.From;
                    break;
                }
            if (northBlock == null || northConn == null)
                throw new InvalidOperationException("Cannot find what lies north of this block");

            // South
            if (block is IfBlock)
                southConn = (Connector)((IfBlock)block).MergeConnector.South;
            else
                southConn = (Connector)block.South;

            southBlock = southConn.South;

            // Keep a list of the blocks we need to delete
            AddTree(northConn, southConn, blocksToRemove);
            if (!blocksToRemove.Contains(southConn))
                blocksToRemove.Add(southConn);

            // Create the right type of connector
            Connector newConn = null;

            if (northConn is DownConnector && southConn is DownConnector)
                newConn = new DownConnector();
            else if (northConn is DownConnector && southConn is DownLeftConnector)
                newConn = new DownLeftConnector();
            else if (northConn is DownConnector && southConn is DownRightConnector)
                newConn = new DownRightConnector();
            else if (northConn is DownConnector && southConn is DownRightUpLeftConnector)
                newConn = new DownRightUpLeftConnector();

            else if (northConn is LeftDownConnector && southConn is DownConnector)
                newConn = new LeftDownConnector();
            else if (northConn is LeftDownConnector && southConn is DownRightConnector)
                newConn = new LeftDownRightConnector();

            else if (northConn is RightDownConnector && southConn is DownConnector)
                newConn = new RightDownConnector();
            else if (northConn is RightDownConnector && southConn is DownLeftConnector)
                newConn = new RightDownLeftConnector();
            else if (northConn is RightDownConnector && southConn is DownRightUpLeftConnector)
                newConn = new RightUpLeftConnector();

            else
            {
                var err = $"Cannot delete block between {northConn.GetType()} and {southConn.GetType()}";
                MessageBox.Show(err);
                throw new InvalidOperationException(err);
            }

            newConn.From = northBlock;
            newConn.South = southBlock;

            if (newConn is DownConnector
                    || newConn is DownFirstSingleBendedConnector
                    || newConn is DownRightUpLeftConnector)
                northBlock.South = newConn;
            else if (newConn is LeftDownConnector
                    || newConn is LeftDownRightConnector)
                northBlock.West = newConn;
            else if (newConn is RightDownConnector
                    || newConn is RightDownLeftConnector
                    || newConn is RightUpLeftConnector)
                northBlock.East = newConn;

            if (newConn is RightUpLeftConnector
                    || newConn is RightUpLeftConnector)
                ((LoopFlowConnector)southBlock).EastInput = newConn;

            foreach (Block b in blocksToRemove)
                Controls.Remove(b);

            Reposition();
        }

        private void AddTree(Block startFrom, Block stopAt, List<Block> list)
        {
            if (startFrom == stopAt)
                return;

            if (list.Contains(startFrom))
                return;

            list.Add(startFrom);

            if (startFrom.East != null)
                AddTree(startFrom.East, stopAt, list);
            if (startFrom.West != null)
                AddTree(startFrom.West, stopAt, list);
            if (startFrom.South != null)
                AddTree(startFrom.South, stopAt, list);
        }

        private void RemoveAllBlockChildControls()
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
            Rectangle surround;

            if (CurrentBlock != null)
            {
                surround = GetMarkerRectAroundBlock(CurrentBlock);
            }
            else
            {
                var block = new Block();
                block.Width = Globals.BlockSize.Width;
                block.Height = Globals.BlockSize.Height;
                Controls.Remove(block);
                surround = GetMarkerRectAroundBlock(block);
            }

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

        public string GetSaveString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("VARIABLES: START");
            foreach (var varName in Variables.Names)
                sb.AppendLine($"{varName}:{Variables.Get(varName).Type}");
            sb.AppendLine("VARIABLES: END");

            foreach (var child in Controls)
                if (child is Block)
                    sb.AppendLine(((Block)child).Save());

            return sb.ToString();
        }

        public void LoadFromString(string s)
        {
            try
            {
                // TODO: make a copy of the existing program
                LoadVariables(s);
                LoadBlocks(s);
                Reposition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // TODO: restore the original program
            }
        }

        private void LoadVariables(string s)
        {
            Variables.Clear();

            var index1 = s.IndexOf("VARIABLES: START") + "VARIABLES: START".Length;
            var index2 = s.IndexOf("VARIABLES: END");

            if (index1 == -1 || index2 == -1)
            {
                var err = "Invalid format. Could not find variable border markers.";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            s = s.Substring(index1, index2 - index1);

            var lines = s.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(":");
                if (parts.Length != 2)
                {
                    var err = $"Invalid format. Cannot read variable {line}";
                    MessageBox.Show(err);
                    throw new InvalidDataException(err);
                }

                Variables.Create(parts[0], parts[1]);
            }
        }

        private void LoadBlocks(string s)
        {
            RemoveAllBlockChildControls();

            Dictionary<string, Block> blocks = new Dictionary<string, Block>();

            var original = s;
            int index1, index2;

            // Load blocks ignoring IDs
            while (true)
            {
                index1 = s.IndexOf("NEW_BLOCK_ID:");
                index2 = s.IndexOf("NEW_BLOCK_ID:", index1 + 1);

                if (index1 == -1)
                    break;

                string blockString;
                if (index2 != -1)
                    blockString = s.Substring(index1, index2 - index1);
                else
                    blockString = s.Substring(index1);

                var block = LoadBlock(blockString);
                blocks[block.Id] = block;
                if (block is StartBlock)
                    StartBlock = block;

                if (index2 == -1)
                    break;
                s = s.Substring(index2);
            }

            // Now connect blocks considering their IDs
            s = original;
            while (true)
            {
                index1 = s.IndexOf("NEW_BLOCK_ID:");
                index2 = s.IndexOf("NEW_BLOCK_ID:", index1 + 1);

                if (index1 == -1)
                    break;

                string blockString;
                if (index2 != -1)
                    blockString = s.Substring(index1, index2 - index1);
                else
                    blockString = s.Substring(index1);

                LoadBlockConnections(blockString, blocks);

                if (index2 == -1)
                    break;
                s = s.Substring(index2);
            }
        }

        private void LoadBlockConnections(string s, Dictionary<string, Block> blocks)
        {
            var lines = s.Split(Environment.NewLine);

            if (!lines[0].StartsWith("NEW_BLOCK_ID:"))
            {
                var err = $"Expected line to start with NEW_BLOCK_ID: but found {lines[0]}";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }
            var id = lines[0].Split(":")[1];
            var block = blocks[id];

            foreach (var line in lines)
            {
                if (!line.Contains(":"))
                    continue;

                var parts = line.Split(":");
                var first = parts[0];
                var otherBlockId = parts[1];
                Block otherBlock = null!;
                if (blocks.ContainsKey(otherBlockId))
                    otherBlock = blocks[otherBlockId];

                switch (first)
                {
                    case "WEST":
                        block.West = otherBlock;
                        break;
                    case "SOUTH":
                        block.South = otherBlock;
                        break;
                    case "EAST":
                        block.East = otherBlock;
                        break;
                    case "FROM":
                        ((Connector)block).From = otherBlock;
                        break;
                    case "MERGE_PARENT":
                        ((SplitFlowConnector)block).MergeParent = otherBlock;
                        break;
                    case "MERGE_CONNECTOR":
                        ((IfBlock)block).MergeConnector = (SplitFlowConnector)otherBlock;
                        break;
                    case "EAST_INPUT":
                        ((LoopFlowConnector)block).EastInput = (Connector)otherBlock;
                        break;
                    case "LOOP_FLOW_CONNECTOR":
                        ((WhileBlock)block).LoopFlowConnector = (LoopFlowConnector)otherBlock;
                        break;
                    default:
                        continue;
                }
            }
        }

        private Block LoadBlock(string s)
        {
            var lines = s.Split(Environment.NewLine);

            if (!lines[0].StartsWith("NEW_BLOCK_ID:"))
            {
                var err = $"Expected line to start with NEW_BLOCK_ID: but found {lines[0]}";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }
            if (!lines[1].StartsWith("TYPE:"))
            {
                var err = $"Expected line to start with TYPE: but found {lines[0]}";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            var id = lines[0].Substring("NEW_BLOCK_ID:".Length);
            var type = lines[1].Substring("TYPE:".Length);

            var block = (Block)Activator.CreateInstance(
                Type.GetType(type));
            block.Id = id;

            for (int i = 2; i < lines.Length; i++)
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    var index = lines[i].IndexOf(":");
                    if (index == -1)
                    {
                        var err = $"Expected to find \":\" on line {lines[i]}";
                        MessageBox.Show(err);
                        throw new InvalidDataException(err);
                    }
                    var firstPart = lines[i].Substring(0, index);
                    var secondPart = lines[i].Substring(index + 1);

                    switch (firstPart)
                    {
                        case "WEST":
                        case "SOUTH":
                        case "EAST":
                        case "FROM":
                        case "MERGE_PARENT":
                        case "MERGE_CONNECTOR":
                        case "LOOP_FLOW_CONNECTOR":
                        case "EAST_INPUT":
                            // TODO: WHILE BLOCK LOOP FLOW CONNECTOR    case "?"
                            continue;

                        case "VARIABLE":
                            if (block is InBlock)
                                ((InBlock)block).VariableName = secondPart;
                            else
                            {
                                var err = $"Unexpected VARIABLE: in {block.GetType()}";
                                MessageBox.Show(err);
                                throw new InvalidDataException(err);
                            }
                            break;
                        case "EXPRESSION":
                        case "ASSIGNMENT":
                            var expressionLines = lines[(i + 1)..];
                            var expression = LoadExpressionFromLines(expressionLines, 0);
                            if (firstPart.Equals("EXPRESSION") && block is IfBlock)
                                ((IfBlock)block).Expression = expression;
                            else if (firstPart.Equals("EXPRESSION") && block is WhileBlock)
                                ((WhileBlock)block).Expression = expression;
                            else if (firstPart.Equals("EXPRESSION") && block is OutBlock)
                                ((OutBlock)block).Expression = expression;
                            else if (firstPart.Equals("ASSIGNMENT") && block is AssignBlock)
                                ((AssignBlock)block).AssignmentOperator = (AssignmentOperator)expression;
                            else
                            {
                                var err = $"Unhandled case {firstPart} for {block.GetType()}";
                                MessageBox.Show(err);
                                throw new InvalidDataException(err);
                            }
                            break;
                    }
                }

            return block;
        }

        private Expression LoadExpressionFromLines(string[] expressionLines, int indent)
        {
            expressionLines = Trim(expressionLines);

            if (!expressionLines[0].Trim().Equals($"EXPRESSIONLEVEL:{indent}:START"))
            {
                var err = $"Unexpected line {expressionLines[0]}. Was expecting EXPRESSIONLEVEL:{indent}:START";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }
            if (!expressionLines[expressionLines.Length - 1].Trim().Equals($"EXPRESSIONLEVEL:{indent}:END"))
            {
                var err = $"Unexpected line {expressionLines[expressionLines.Length - 1]}. Was expecting EXPRESSIONLEVEL:{indent}:END";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            expressionLines = expressionLines[1..(expressionLines.Length - 1)];

            var index = expressionLines[0].IndexOf(":");
            var first = expressionLines[0].Substring(0, index);
            var second = expressionLines[0].Substring(index + 1);

            return first.Trim() switch
            {
                "CONSTANT_LOGICAL" => new LogicalConstant(bool.Parse(second)),
                "CONSTANT_NUMBER" => new NumberConstant(float.Parse(second)),
                "CONSTANT_STRING" => new StringConstant(second),
                "CONSTANT_NOT_SET" => new NotSetConstant(),
                "VARIABLE" => Variables.Names.Contains(second)
                                ? Variables.Get(second) :
                                    second.Equals("Drag a list here")
                                    ? new DummyListOfNumbers()
                                    : new NotSetVariable(),
                "OPERATOR" => LoadOperatorFromLines(expressionLines, indent),
                _ => throw new ArgumentException($"{first} is not a valid start for an Expression")
            };
        }

        private Operator LoadOperatorFromLines(string[] expressionLines, int indent)
        {
            expressionLines = Trim(expressionLines);

            // OPERATOR:WinFlows.Expressions.Operators.Logical.LogicalAndOperator
            if (!expressionLines[0].Trim().StartsWith("OPERATOR:"))
            {
                var err = $"Expected line to start with OPERATOR: but found {expressionLines[0]}";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            var index = expressionLines[0].IndexOf(":");
            var second = expressionLines[0].Substring(index + 1);

            var op = (Operator)Activator.CreateInstance(Type.GetType(second));
            expressionLines = expressionLines[1..];

            for (int i = 0; i < op.Operands.Length; i++)
            {
                string[] operandLines;

                if (!expressionLines[0].Trim().Equals($"OPERAND_NO:{i}"))
                {
                    var err = $"Unexpected {expressionLines[0]}. Was expecting OPERAND_NO:{i}";
                    MessageBox.Show(err);
                    throw new InvalidDataException(err);
                }

                if (i == op.Operands.Length - 1)
                    op.Operands[i] = LoadExpressionFromLines(expressionLines[1..], indent + 1);
                else
                {
                    var lookingFor = $"{string.Empty.PadLeft(indent * 2)}OPERAND_NO:{i + 1}";
                    var j = 0;
                    while (j < expressionLines.Length && !expressionLines[j].Equals(lookingFor))
                        j++;
                    if (j == expressionLines.Length)
                    {
                        var err = $"Did not find end of operand {i}";
                        MessageBox.Show(err);
                        throw new InvalidDataException(err);
                    }
                    op.Operands[i] = LoadExpressionFromLines(expressionLines[1..j], indent + 1);

                    expressionLines = expressionLines[j..];
                }
            }

            return op;
        }

        private string[] Trim(string[] expressionLines)
        {
            while (string.IsNullOrWhiteSpace(expressionLines[0]))
                expressionLines = expressionLines[1..];
            while (string.IsNullOrWhiteSpace(expressionLines[expressionLines.Length - 1]))
                expressionLines = expressionLines[..(expressionLines.Length - 1)];

            return expressionLines;
        }
    }
}
