using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberDivideOperator : Operator
    {
        public NumberDivideOperator()
            : base(ExpressionTypes.Number,
                new string[] { " ( ", " / ", " ) " },
                new string[] { string.Empty, " / ", string.Empty })
        {
            Operands[0] = new NumberConstant(1);
            Operands[1] = new NumberConstant(1);
        }

        public override object Evaluate()
        {
            var denominator = (float)Operands[1].Evaluate();

            if (denominator == 0)
            {
                var err = "ERROR: Division by zero. The rest of the program will have unpredictable outcome.";
                MainForm.ConsoleWrite(err);
                MessageBox.Show(err);
                return 0.0f;
            }

            return (float)Operands[0].Evaluate() / denominator;
        }
    }
}
