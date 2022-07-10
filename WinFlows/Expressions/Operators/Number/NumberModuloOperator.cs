using WinFlows.Expressions.Constants;

namespace WinFlows.Expressions.Operators.Number
{
    public class NumberModuloOperator : Operator
    {
        public NumberModuloOperator()
            : base(ExpressionTypes.Number,
                new string[] { " ( ", " MOD ", " ) " },
                new string[] { string.Empty, " MOD ", string.Empty })
        {
            Operands[0] = new NumberConstant();
            Operands[1] = new NumberConstant();
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

            return Convert.ToInt32((float)Operands[0].Evaluate()) % Convert.ToInt32(denominator);
        }
    }
}
