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
            var index = Convert.ToInt32(Operands[0].Evaluate());
            var list = (ListOfStrings)Operands[1];

            if (index >= list.Length)
            {
                var err = $"ERROR: Attempted to read element {index} of a list with {list.Length} elements. There is a bug in the program. Please fix. Returning empty string.";
                MessageBox.Show(err);
                MainForm.ConsoleWrite(err);
                return string.Empty;
            }

            return (string)list[index];
        }
    }
}
