using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Logical
{
    public class LogicalAndOperator : Operator
    {
        public LogicalAndOperator()
            : base(ExpressionTypes.Logical,
                  new string[] { " ( ", " AND ", " ) " },
                  new string[] { string.Empty, " AND ", string.Empty })
        {
            Operands[0] = new LogicalConstant();
            Operands[1] = new LogicalConstant();
        }

        public override object Evaluate()
        {
            return (bool)Operands[0].Evaluate() && (bool)Operands[1].Evaluate();
        }
    }
}
