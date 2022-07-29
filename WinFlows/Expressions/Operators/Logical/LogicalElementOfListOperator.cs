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
            var index = Convert.ToInt32(Operands[0].Evaluate());
            var list = (ListOfLogicals)Operands[1];

            if (index >= list.Length)
            {
                var err = $"ERROR: Attempted to read element {index} of a list with {list.Length} elements. There is a bug in the program. Please fix. Returning false.";
                MessageBox.Show(err);
                MainForm.ConsoleWrite(err);
                return false;
            }

            return (bool)list[index];
        }
    }
}