using WinFlows.Blocks.Connectors;
using WinFlows.Helpers;

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

            // Draw the Y
            var yWidth = Width / 10;
            var yHeight = (int)(yWidth * 1.5);
            StringHelper.DrawStringInsideBox(
                g,
                new Rectangle(Width - yWidth, Height / 10, yWidth, yHeight),
                ColorScheme.IfYesText,
                "Y");

            // Draw the N
            StringHelper.DrawStringInsideBox(
                g,
                new Rectangle(4 * Width / 7, 7 * Height / 10, yWidth, yHeight),
                ColorScheme.IfNoText,
                "N");

        }

        public override string Save()
        {
            MessageBox.Show("While Blocks cannot be saved");
            throw new NotImplementedException("While blocks cannot be saved");
        }
    }
}
