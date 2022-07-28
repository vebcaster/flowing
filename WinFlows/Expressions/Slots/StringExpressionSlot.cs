using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Expressions.Slots
{
    public partial class StringExpressionSlot : ExpressionSlot
    {
        public StringExpressionSlot(Expression expression)
            : base(expression)
        {
            if (expression.Type != ExpressionTypes.String)
            {
                var err = "Expression should be string here.";
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
                type.Equals("STRING")
                &&
                (
                    kind.Equals("VARIABLE")
                    ||
                    kind.Equals("OPERATOR")
                );
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.StringStroke, Globals.SlotStroke);
            var brush = new SolidBrush(_isHighlighted ? ColorScheme.ExpressionHighlight : ColorScheme.StringFill);

            ShapeHelper.DrawPill(g, ClientRectangle, pen, brush);

            if (Expression is Constant || Expression is Variable)
                StringHelper.DrawStringInsideBox(g, ClientRectangle, ColorScheme.StringText, Expression.ToString());
            else if (Expression is Operator)
                OperatorSlotHelper.WriteOperatorTexts(g, this, ColorScheme.StringText);
        }

        public override bool DoubleClicked()
        {
            var text = string.Empty;
            if (Expression is StringConstant)
                text = (string)Expression.Evaluate();

            using var optionString = new OptionString($"Input text value", text, true, false);
            if (optionString.ShowDialog(this) == DialogResult.OK)
            {
                Expression = new StringConstant(optionString.TypedText);

                return true;
            }

            return false;
        }
    }
}
