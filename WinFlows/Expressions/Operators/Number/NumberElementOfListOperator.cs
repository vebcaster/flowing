using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Variables.Lists;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberElementOfListOperator : ElementOfListOperator
    {
        public NumberElementOfListOperator()
            : base(ExpressionTypes.Number)
        {
            Operands[0] = new NumberConstant();
            Operands[1] = new DummyListOfNumbers();
        }

        public override object Evaluate()
        {
            return (float)
                ((ListOfNumbers)Operands[1])
                [Convert.ToInt32(Operands[0].Evaluate())];
        }
    }
}
