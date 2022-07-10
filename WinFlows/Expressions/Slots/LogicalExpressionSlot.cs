using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Expressions.Slots
{
    public partial class LogicalExpressionSlot : ExpressionSlot
    {
        public LogicalExpressionSlot(Expression expression)
            : base(expression)
        {
            if (expression.Type != ExpressionTypes.Logical)
            {
                var err = "Expression should be logical here.";
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
                type.Equals("LOGICAL")
                &&
                (
                    kind.Equals("VARIABLE")
                    ||
                    kind.Equals("OPERATOR")
                );
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.LogicalStroke, Globals.SlotStroke);
            var brush = new SolidBrush(_isHighlighted ? ColorScheme.ExpressionHighlight : ColorScheme.LogicalFill);

            var points = ShapeHelper.GetOctagonPoints(Width, Height);

            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            if (Expression is Constant || Expression is Variable)
                StringHelper.DrawStringInsideBox(g, ClientRectangle, ColorScheme.LogicalText, Expression.ToString());
            else if (Expression is Operator)
                OperatorSlotHelper.WriteOperatorTexts(g, this, ColorScheme.LogicalText);
        }

        public override bool DoubleClicked()
        {
            var values = new List<string> { "False", "True" };

            using var optionCombo = new OptionCombo(values, $"Set a value", Expression.Evaluate().ToString());
            if (optionCombo.ShowDialog(this) == DialogResult.OK)
            {
                switch (optionCombo.SelectedItem)
                {
                    case "True":
                        Expression = new LogicalConstant { Value = true };
                        break;
                    case "False":
                        Expression = new LogicalConstant { Value = false };
                        break;
                }

                return true;
            }

            return false;
        }
    }
}
