using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Logical
{
    public class LogicalXorOperator : Operator
    {
        public LogicalXorOperator()
            : base(ExpressionTypes.Logical,
                  new string[] { " ( ", " XOR ", " ) " },
                  new string[] { string.Empty, " XOR ", string.Empty })
        {
            Operands[0] = new LogicalConstant();
            Operands[1] = new LogicalConstant();
        }

        public override object Evaluate()
        {
            return (bool)Operands[0].Evaluate() ^ (bool)Operands[1].Evaluate();
        }
    }
}
