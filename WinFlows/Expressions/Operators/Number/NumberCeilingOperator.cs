using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberCeilingOperator : Operator
    {
        public NumberCeilingOperator()
            : base(ExpressionTypes.Number,
                new string[] { " CEILING ( ", " ) " },
                new string[] { " CEILING ", string.Empty })
        {
            Operands[0] = new NumberConstant();
        }

        public override object Evaluate()
        {
            return (float)Math.Ceiling((float)(Operands[0].Evaluate()));
        }
    }
}
