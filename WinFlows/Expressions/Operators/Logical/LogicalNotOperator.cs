using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Logical
{
    public class LogicalNotOperator : Operator
    {
        public LogicalNotOperator()
            : base(ExpressionTypes.Logical,
                  new string[] { " NOT ", string.Empty },
                  new string[] { " NOT ", string.Empty })
        {
            Operands[0] = new LogicalConstant();
        }

        public override object Evaluate()
        {
            return !(bool)Operands[0].Evaluate();
        }
    }
}
