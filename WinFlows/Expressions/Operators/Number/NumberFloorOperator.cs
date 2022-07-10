using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberFloorOperator : Operator
    {
        public NumberFloorOperator()
            : base(ExpressionTypes.Number,
                new string[] { " FLOOR ( ", " ) " },
                new string[] { " FLOOR ", string.Empty })
        {
            Operands[0] = new NumberConstant();
        }

        public override object Evaluate()
        {
            return (float)Math.Floor((float)(Operands[0].Evaluate()));
        }
    }
}
