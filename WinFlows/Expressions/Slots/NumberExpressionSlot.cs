using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Expressions.Slots
{
    public partial class NumberExpressionSlot : ExpressionSlot
    {
        public NumberExpressionSlot(Expression expression)
            : base(expression)
        {
            if (expression.Type != ExpressionTypes.Number)
            {
                var err = "Expression should be number here.";
                MessageBox.Show(err);
                throw new ArgumentException(err);
            }

            InitializeComponent();
        }

        public override bool AcceptsDraggableData(string? kind, string? type, string? what)
        {
            if (kind == null || type == null)
                return false;

            return
                type.Equals("NUMBER")
                &&
                (
                    kind.Equals("VARIABLE")
                    ||
                    kind.Equals("OPERATOR")
                );
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.NumberStroke, Globals.SlotStroke);
            var brush = new SolidBrush(_isHighlighted ? ColorScheme.ExpressionHighlight : ColorScheme.NumberFill);

            var points = ShapeHelper.GetHexagonPoints(Width, Height);

            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            if (Expression is Constant || Expression is Variable)
                StringHelper.DrawStringInsideBox(g, ClientRectangle, ColorScheme.NumberText, Expression.ToString());
            else if (Expression is Operator)
                OperatorSlotHelper.WriteOperatorTexts(g, this, ColorScheme.NumberText);
        }

        public override bool DoubleClicked()
        {
            float typedNumber;

            using var optionString = new OptionString($"Input numerical value", string.Empty, false, true);
            if (optionString.ShowDialog(this) == DialogResult.OK)
            {
                if (!float.TryParse(optionString.TypedText, out typedNumber))
                {
                    var err = $"float could not parse {typedNumber}";
                    MessageBox.Show(err);
                    throw new InvalidOperationException(err);
                }

                Expression = new NumberConstant(typedNumber);

                return true;
            }

            return false;
        }
    }
}
