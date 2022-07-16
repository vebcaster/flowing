using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Variables;

namespace WinFlows.Expressions.Operators.Logical
{
    public class LogicalAssignmentOperator : AssignmentOperator
    {
        public LogicalAssignmentOperator()
            : base(ExpressionTypes.Logical)
        {
            Operands[0] = new LogicalVariable("DRAG A LOGICAL VARIABLE OR ELEMENT OF LIST HERE");
            Operands[1] = new LogicalConstant();
        }
    }
}
