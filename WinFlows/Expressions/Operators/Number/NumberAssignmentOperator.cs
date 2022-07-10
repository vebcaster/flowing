using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Variables;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberAssignmentOperator : AssignmentOperator
    {
        public NumberAssignmentOperator()
            :base(ExpressionTypes.Number)
        {
            Operands[0] = new NumberVariable("DRAG A NUMBER VARIABLE OR ELEMENT OF LIST HERE");
            Operands[1] = new NumberConstant();
        }
    }
}
