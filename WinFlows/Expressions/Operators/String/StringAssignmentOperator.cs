using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Variables;

namespace WinFlows.Expressions.Operators.String
{
    public class StringAssignmentOperator : AssignmentOperator
    {
        public StringAssignmentOperator()
            : base(ExpressionTypes.String)
        {
            Operands[0] = new StringVariable("DRAG A STRING VARIABLE OR ELEMENT OF LIST HERE");
            Operands[1] = new StringConstant();
        }
    }
}
