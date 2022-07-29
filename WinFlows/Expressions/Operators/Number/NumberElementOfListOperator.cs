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
            var index = Convert.ToInt32(Operands[0].Evaluate());
            var list = (ListOfNumbers)Operands[1];

            if (index >= list.Length)
            {
                var err = $"ERROR: Attempted to read element {index} of a list with {list.Length} elements. There is a bug in the program. Please fix. Returning zero.";
                MessageBox.Show(err);
                MainForm.ConsoleWrite(err);
                return 0.0f;
            }

            return (float)list[index];
        }
    }
}
