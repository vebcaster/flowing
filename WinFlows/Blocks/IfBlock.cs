using System.Text;
using WinFlows.Blocks.Connectors;
using WinFlows.Expressions;
using WinFlows.Expressions.Constants;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class IfBlock : Block
    {
        public SplitFlowConnector MergeConnector { get; set; }
        public Expression Expression { private get; set; }

        public IfBlock()
        {
            InitializeComponent();
            MergeConnector = null!;
            Expression = new LogicalConstant();
        }

        public IfBlock(SplitFlowConnector mergeConnector)
        {
            InitializeComponent();
            MergeConnector = mergeConnector;
            Expression = new LogicalConstant();
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.IfStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.IfFill);
            var rect = Globals.BlockRectTwoThirds;

            var points = ShapeHelper.GetRhombusPoints(Width, Height);

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
                new Rectangle(0, Height / 10, yWidth, yHeight),
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
                var err = $"Expressions in IF blocks should evaluate to BOOL, not {result.GetType()}";
                MessageBox.Show(err);
                throw new InvalidOperationException(err);
            }

            if ((bool)result)
                return East;
            else
                return West;
        }

        public override string Save()
        {
            var sb = new StringBuilder(base.Save());

            var expression = Expression.Save(0);
            sb.AppendLine($"MERGE_CONNECTOR:{MergeConnector.Id}");
            sb.AppendLine($"EXPRESSION:");
            sb.AppendLine(expression);

            return sb.ToString();
        }
    }
}
