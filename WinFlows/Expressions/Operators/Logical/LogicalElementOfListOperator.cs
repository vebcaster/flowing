using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Variables.Lists;

namespace WinFlows.Expressions.Operators.Logical
{
    public class LogicalElementOfListOperator : ElementOfListOperator
    {
        public LogicalElementOfListOperator()
            : base(ExpressionTypes.Logical)
        {
            Operands[0] = new NumberConstant();
            Operands[1] = new DummyListOfLogicals();
        }

        public override object Evaluate()
        {
            return (bool)
                ((ListOfLogicals)Operands[1])
                [Convert.ToInt32(Operands[0].Evaluate())];
        }
    }
}