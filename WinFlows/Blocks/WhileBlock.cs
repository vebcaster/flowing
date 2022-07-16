using System.Text;
using WinFlows.Blocks.Connectors;
using WinFlows.Expressions;
using WinFlows.Expressions.Constants;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class WhileBlock : Block
    {
        public LoopFlowConnector LoopFlowConnector { get; set; }
        public Expression Expression { private get; set; }

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

        public WhileBlock()
        {
            InitializeComponent();

            LoopFlowConnector = null!;
            Expression = new LogicalConstant();
        }

        public WhileBlock(LoopFlowConnector loopFlowConnector)
        {
            InitializeComponent();

            LoopFlowConnector = loopFlowConnector;
            Expression = new LogicalConstant();
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

            StringHelper.DrawStringInsideBox(g, rect, ColorScheme.IfText, Expression.ToString() + "?");
        }

        public override void DoubleClicked()
        {
            using var eb = new ExpressionBuilder(Expression);
            if (eb.ShowDialog(this) == DialogResult.OK)
            {
                Expression = eb.Expression;
                Invalidate();
            }
        }

        public override Block? Execute()
        {
            var result = Expression.Evaluate();
            if (result is not bool)
            {
                var err = $"Expressions in WHILE blocks should evaluate to BOOL, not {result.GetType()}";
                MessageBox.Show(err);
                throw new InvalidOperationException(err);
            }

            if ((bool)result)
                return East;
            else
                return South;
        }

        public override string Save()
        {
            var sb = new StringBuilder(base.Save());

            var expression = Expression.Save(0);
            sb.AppendLine($"LOOP_FLOW_CONNECTOR:{LoopFlowConnector.Id}");
            sb.AppendLine($"EXPRESSION:");
            sb.AppendLine(expression);

            return sb.ToString();
        }
    }
}
