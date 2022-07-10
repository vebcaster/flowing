using WinFlows.Blocks.Connectors;

namespace WinFlows.Blocks
{
    public partial class WhileBlock : Block
    {
        public LoopFlowConnector LoopFlowConnector { get; set; }

        public override int SouthOffset
        {
            get
            {
                if (South is DownRightUpLeftConnector || South is DownRightConnector)
                    return Math.Max(LoopFlowConnector.EastInput.Row - Row + 1, 1);
                else
                    return Math.Max(LoopFlowConnector.EastInput.Row - Row, 1);
            }
        }

        public WhileBlock(LoopFlowConnector loopFlowConnector)
        {
            InitializeComponent();

            LoopFlowConnector = loopFlowConnector;
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.WhileStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.WhileFill);
            var rect = Globals.BlockRect;

            var points = new Point[] {
                new Point(rect.Right / 2, rect.Top),
                new Point(rect.Right, rect.Bottom / 2),
                new Point(rect.Right / 2, rect.Bottom),
                new Point(rect.Left, rect.Bottom / 2)
            };

            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);
        }
    }
}
