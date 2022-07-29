using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.String
{
    public class NumberToStringOperator : Operator
    {
        public NumberToStringOperator()
            : base(ExpressionTypes.String,
                new string[] { " to_string ( ", " ) " },
                new string[] { " to_string ", string.Empty })
        {
            Operands[0] = new NumberConstant();
        }

        public override object Evaluate()
        {
            return Operands[0].Evaluate().ToString();
        }
    }
}
