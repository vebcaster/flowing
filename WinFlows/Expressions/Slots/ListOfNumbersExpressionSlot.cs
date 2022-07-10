using System.Reflection.Metadata;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Expressions.Slots
{
    public partial class ListOfNumbersExpressionSlot : ExpressionSlot
    {
        public ListOfNumbersExpressionSlot(Expression expression)
            : base(expression)
        {
            if (expression.Type != ExpressionTypes.ListOfNumbers)
            {
                var err = "Expression should be list of numbers here.";
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
                type.Equals("LIST_OF_NUMBERS")
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

            ShapeHelper.DrawList(g, ClientRectangle, pen, brush);

            if (Expression is Constant || Expression is Variable)
                StringHelper.DrawStringInsideBox(g, ClientRectangle, ColorScheme.NumberText, Expression.ToString());
            else if (Expression is Operator)
                OperatorSlotHelper.WriteOperatorTexts(g, this, ColorScheme.NumberText);
        }
    }
}
