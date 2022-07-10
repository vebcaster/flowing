using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberRoundOperator : Operator
    {
        public NumberRoundOperator()
            : base(ExpressionTypes.Number,
                new string[] { " ROUND ( ", " ) " },
                new string[] { " ROUND ", string.Empty })
        {
            Operands[0] = new NumberConstant();
        }

        public override object Evaluate()
        {
            return (float)Math.Round((float)(Operands[0].Evaluate()));
        }
    }
}
