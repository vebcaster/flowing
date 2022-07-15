using System.Text;

namespace WinFlows.Blocks.Connectors
{
    public partial class Connector : Block
    {
        protected enum SidesFlags
        {
            None = 0,
            East = 1,
            West = 2,
            North = 4,
            South = 8
        }

        public Block From { get; set; }

        private bool _isHighlighted = false;
        public Pen Pen => new(
            _isHighlighted ? ColorScheme.ConnectorHighlight : ColorScheme.ConnectorStroke, 
            _isHighlighted ? Globals.HighlightConnectorStroke : Globals.ConnectorStroke);
        public Brush Brush = new SolidBrush(ColorScheme.ConnectorArrowheadFill);

        public virtual void Insert(Block block1, Block block2) { MessageBox.Show("Implement InsertBlock in all connectors."); }

        public Connector()
        {
            InitializeComponent();
            From = this;
        }

        private void Connector_DragEnter(object sender, DragEventArgs e)
        {
            if (this is SplitFlowConnector 
                || this is LoopFlowConnector)
                e.Effect = DragDropEffects.None;
            else if (e.Data != null
                    && e.Data.GetData(DataFormats.Text) != null
                    && e.Data.GetData(DataFormats.Text).ToString()!.StartsWith("BLOCK:")
                    )
            {
                e.Effect = DragDropEffects.Copy;
                if (!_isHighlighted)
                {
                    _isHighlighted = true;
                    Invalidate();
                }
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void Connector_DragDrop(object sender, DragEventArgs e)
        {
            if (_isHighlighted)
            {
                _isHighlighted = false;
                Invalidate();
            }

            string droppedData;
            if (e.Data != null
                    && e.Data.GetData(DataFormats.Text) != null
                    && e.Data.GetData(DataFormats.Text).ToString()!.StartsWith("BLOCK:")
                    )
                droppedData = e.Data.GetData(DataFormats.Text).ToString()!;
            else
                return;

            var (newBlock1, newBlock2) = BlockFactory.CreateBlocksForInsert(droppedData);
            Insert(newBlock1, newBlock2);

            FlowChart.Instance.Reposition();
        }

        protected void DrawBendInTheMiddle(Graphics g, SidesFlags flags)
        {
            var size = new Size(Globals.ConnectorBendRadius * 2, Globals.ConnectorBendRadius * 2);

            var x = 0;
            var y = 0;

            if ((flags & SidesFlags.West) == SidesFlags.West)
                x = Globals.BlockSize.Width / 2;

            if ((flags & SidesFlags.East) == SidesFlags.East)
                x = Width - Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius * 2;

            if ((flags & SidesFlags.North) == SidesFlags.North)
                y = Globals.BlockSize.Height / 2;

            if ((flags & SidesFlags.South) == SidesFlags.South)
                y = Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius * 2;

            var rect = new Rectangle(x, y, size.Width, size.Height);

            switch (flags)
            {
                case SidesFlags.South | SidesFlags.West:
                    g.DrawArc(Pen, rect, 90, 90);
                    break;
                case SidesFlags.West | SidesFlags.North:
                    g.DrawArc(Pen, rect, 180, 90);
                    break;
                case SidesFlags.North | SidesFlags.East:
                    g.DrawArc(Pen, rect, 270, 90);
                    break;
                case SidesFlags.East | SidesFlags.South:
                    g.DrawArc(Pen, rect, 0, 90);
                    break;
                default:
                    g.DrawLine(Pens.Red, 0, 0, Width, Height);
                    g.DrawLine(Pens.Red, 0, Width, Height, 0);
                    break;
            }
        }

        private void Connector_DragLeave(object sender, EventArgs e)
        {
            if (_isHighlighted)
            {
                _isHighlighted = false;
                Invalidate();
            }
        }

        public override string Save()
        {
            var sb = new StringBuilder(base.Save());

            sb.AppendLine($"FROM:{From.Id}");

            return sb.ToString();
        }
    }
}
