using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Logical
{
    public class StringsAreEqualOperator : Operator
    {
        public StringsAreEqualOperator()
            : base(ExpressionTypes.Logical,
                  new string[] { " ( ", " == ", " ) " },
                  new string[] { string.Empty, " == ", string.Empty })
        {
            Operands[0] = new StringConstant();
            Operands[1] = new StringConstant();
        }

        public override object Evaluate()
        {
            var s1 = (string)Operands[0].Evaluate();
            var s2 = (string)Operands[1].Evaluate();
            return s1.Equals(s2);
        }
    }
}
