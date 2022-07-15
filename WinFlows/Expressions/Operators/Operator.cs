using System.Text;

namespace WinFlows.Expressions.Operators
{
    public abstract class Operator : Expression
    {
        public ExpressionTypes ReturnType { get; private set; }

        public Expression[] Operands { get; }
        public string[] StringTexts { get; }
        public string[] SlotTexts { get; }

        public Operator(ExpressionTypes type, string[] stringTexts, string[] slotTexts) : base(type)
        {
            if (stringTexts.Length != slotTexts.Length)
            {
                var err = "Operator constructor takes visualTexts and slotTexts of the same size.";
                MessageBox.Show(err);
                throw new ArgumentException(err);
            }
            SlotTexts = slotTexts;
            StringTexts = stringTexts;
            Operands = new Expression[stringTexts.Length - 1];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < StringTexts.Length; i++)
            {
                sb.Append(StringTexts[i]);
                if (i < StringTexts.Length - 1)
                    sb.Append(Operands[i]);
            }

            return sb.ToString();
        }

        public override string Save(int indent)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:START");

            sb.AppendLine($"{string.Empty.PadLeft(indent * 2)}OPERATOR:{GetType()}");
            for (int i = 0; i < Operands.Length; i++)
            {
                sb.AppendLine($"{string.Empty.PadLeft(indent * 2)}OPERAND_NO:{i}");
                sb.AppendLine(Operands[i].Save(indent + 1));
            }

            sb.AppendLine($"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:END");
            return sb.ToString();
        }
    }
}
