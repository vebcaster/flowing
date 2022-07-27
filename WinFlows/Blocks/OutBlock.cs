using System.Text;
using WinFlows.Expressions;
using WinFlows.Expressions.Constants;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class OutBlock : Block
    {
        public Expression Expression{ private get; set; }

        public OutBlock()
        {
            InitializeComponent();
            Expression = new StringConstant("Hello, World!");
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.InStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.InFill);
            var rect = Globals.BlockRect;

            var points = new Point[] {
                new Point(rect.Right / 5, rect.Top),
                new Point(rect.Right, rect.Top),
                new Point(rect.Right * 4 / 5, rect.Bottom),
                new Point(rect.Left, rect.Bottom)
            };

            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);
            StringHelper.DrawStringInsideBox(g, rect, ColorScheme.StartText, Expression.ToString());
        }

        public override void DoubleClicked()
        {
            var original = Expression.Save(0);

            using var eb = new ExpressionBuilder(Expression);
            if (eb.ShowDialog(this) == DialogResult.OK)
            {
                Expression = eb.Expression;
                Invalidate();
            }
            else
            {
                Expression = Expression.LoadExpressionFromLines(original.Split(Environment.NewLine), 0);
            }
        }

        public override Block? Execute()
        {
            var result = (string)Expression.Evaluate();
            MainForm.ConsoleWrite(result);
            
            return South;
        }

        public override string Save()
        {
            var sb = new StringBuilder(base.Save());

            var expression = Expression.Save(0);
            sb.AppendLine($"EXPRESSION:");
            sb.AppendLine(expression);

            return sb.ToString();
        }
    }
}
