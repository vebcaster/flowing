using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Variables.Lists;

namespace WinFlows.Expressions.Operators.String
{
    public class StringElementOfListOperator : ElementOfListOperator
    {
        public StringElementOfListOperator()
            : base(ExpressionTypes.String)
        {
            Operands[0] = new NumberConstant();
            Operands[1] = new DummyListOfStrings();
        }

        public override object Evaluate()
        {
            return (string)
                ((ListOfStrings)Operands[1])
                [Convert.ToInt32(Operands[0].Evaluate())];
        }
    }
}
