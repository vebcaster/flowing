using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Logical
{
    public class LogicalOrOperator : Operator
    {
        public LogicalOrOperator()
            : base(ExpressionTypes.Logical,
                  new string[] { " ( ", " OR ", " ) " },
                  new string[] { string.Empty, " OR ", string.Empty })
        {
            Operands[0] = new LogicalConstant();
            Operands[1] = new LogicalConstant();
        }

        public override object Evaluate()
        {
            return (bool)Operands[0].Evaluate() || (bool)Operands[1].Evaluate();
        }
    }
}
