using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Operators.Logical;
using WinFlows.Expressions.Operators.Number;
using WinFlows.Expressions.Operators.String;
using WinFlows.Expressions.Variables;
using WinFlows.Expressions.Variables.Lists;
using WinFlows.Helpers;

namespace WinFlows.Expressions.Slots
{
    public partial class NotSetExpressionSlot : ExpressionSlot
    {
        public NotSetExpressionSlot(Expression expression)
            : base(expression)
        {
            if (expression.Type != ExpressionTypes.NotSet)
            {
                var err = "Expression should be NotSet here.";
                MessageBox.Show(err);
                throw new ArgumentException(err);
            }

            InitializeComponent();
        }

        public override bool AcceptsDraggableData(string? kind, string? type, string? what)
        {
            if (kind == null || type == null)
                return false;

            // Trying to drop over the assignment operator itself. Not allowed.
            if (Expression is AssignmentOperator)
                return false;

            // Are we on the left side of an assignment? On LVALUES allowed.
            if (Expression is NotSetVariable)
            {
                if (kind.Equals("VARIABLE") && Variables.Variables.Get(what) is not ListOfVariables)
                    return true;
                if (kind.Equals("OPERATOR") && what != null && what.Contains("ELEMENT_OF_LIST"))
                    return true;
                return false;
            }

            // On the right side, everything goes except lists, the type has not yet been determined
            if (!type.Contains("LIST")
                && (
                    kind.Equals("VARIABLE")
                    || kind.Equals("OPERATOR")
                ))
                return true;

            // Some external or unhandled stuff is likely being dropped
            return false;
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.NotSetStroke, Globals.SlotStroke)
            {
                DashCap = System.Drawing.Drawing2D.DashCap.Round,
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            };
            var brush = new SolidBrush(_isHighlighted ? ColorScheme.ExpressionHighlight : ColorScheme.NotSetFill);

            ShapeHelper.DrawPill(g, ClientRectangle, pen, brush);

            if (Expression is Constant || Expression is Variable)
                StringHelper.DrawStringInsideBox(g, ClientRectangle, ColorScheme.NotSetText, Expression.ToString());
            else if (Expression is Operator)
                OperatorSlotHelper.WriteOperatorTexts(g, this, ColorScheme.NotSetText);
        }

        public override bool DoubleClicked()
        {
            return false;
        }

        public override void Dropped(string? kind, string? type, string? what)
        {
            // Figure out on which operand this was dropped
            int operandIndex;

            if (Expression is NotSetVariable)
                operandIndex = 0;
            else if (Expression is NotSetConstant)
                operandIndex = 1;
            else
            {
                var err = "Could not figure on which operand this was dropped.";
                MessageBox.Show(err);
                throw new InvalidOperationException(err);
            }

            // We call the base, which will replace our Expression with the correct one,
            // then we build a new, correctly typed, AssignmentOperator
            base.Dropped(kind, type, what);
            var newType = Expression.Type;

            var parentForm = (ExpressionBuilder)ParentForm;

            AssignmentOperator newAssignmentOperator;

            switch (newType)
            {
                case ExpressionTypes.Logical:
                    newAssignmentOperator = new LogicalAssignmentOperator();
                    break;
                case ExpressionTypes.Number:
                    newAssignmentOperator = new NumberAssignmentOperator();
                    break;
                case ExpressionTypes.String:
                    newAssignmentOperator = new StringAssignmentOperator();
                    break;
                default:
                    var err = "Dropped data invalid. Should be either left or right side of the assignment operator.";
                    MessageBox.Show(err);
                    throw new InvalidOperationException(err);
            }

            newAssignmentOperator.Operands[operandIndex] = Expression;

            parentForm.Expression = newAssignmentOperator;
            parentForm.MainSlot.Expression = newAssignmentOperator;

            foreach (var child in parentForm.MainSlot.Controls)
                if (child is NotSetExpressionSlot && child != this)
                    ((NotSetExpressionSlot)child).Expression = newAssignmentOperator.Operands[1 - operandIndex];
        }
    }
}
