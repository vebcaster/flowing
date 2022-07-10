using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.String
{
    public class StringConcatenateOperator : Operator
    {
        public StringConcatenateOperator()
            : base(ExpressionTypes.String,
                new string[] { " concat ( ", " ) with ( ", " ) " },
                new string[] { " concat ", " with ", string.Empty })
        {
            Operands[0] = new StringConstant();
            Operands[1] = new StringConstant();
        }

        public override object Evaluate()
        {
            return Operands[0].Evaluate().ToString() + Operands[1].Evaluate().ToString();
        }
    }
}
