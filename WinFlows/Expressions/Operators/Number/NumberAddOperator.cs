using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberAddOperator : Operator
    {
        public NumberAddOperator()
            : base(ExpressionTypes.Number,
                new string[] { " ( ", " + ", " ) " },
                new string[] { string.Empty, " + ", string.Empty })
        {
            Operands[0] = new NumberConstant();
            Operands[1] = new NumberConstant();
        }

        public override object Evaluate()
        {
            return (float)Operands[0].Evaluate() + (float)Operands[1].Evaluate();
        }
    }
}
