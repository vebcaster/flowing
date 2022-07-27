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

        public static Operator LoadOperatorFromLines(string[] expressionLines, int indent)
        {
            expressionLines = Trim(expressionLines);

            // OPERATOR:WinFlows.Expressions.Operators.Logical.LogicalAndOperator
            if (!expressionLines[0].Trim().StartsWith("OPERATOR:"))
            {
                var err = $"Expected line to start with OPERATOR: but found {expressionLines[0]}";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            var index = expressionLines[0].IndexOf(":");
            var second = expressionLines[0].Substring(index + 1);

            var op = (Operator)Activator.CreateInstance(System.Type.GetType(second));
            expressionLines = expressionLines[1..];

            for (int i = 0; i < op.Operands.Length; i++)
            {
                string[] operandLines;

                if (!expressionLines[0].Trim().Equals($"OPERAND_NO:{i}"))
                {
                    var err = $"Unexpected {expressionLines[0]}. Was expecting OPERAND_NO:{i}";
                    MessageBox.Show(err);
                    throw new InvalidDataException(err);
                }

                if (i == op.Operands.Length - 1)
                    op.Operands[i] = LoadExpressionFromLines(expressionLines[1..], indent + 1);
                else
                {
                    var lookingFor = $"{string.Empty.PadLeft(indent * 2)}OPERAND_NO:{i + 1}";
                    var j = 0;
                    while (j < expressionLines.Length && !expressionLines[j].Equals(lookingFor))
                        j++;
                    if (j == expressionLines.Length)
                    {
                        var err = $"Did not find end of operand {i}";
                        MessageBox.Show(err);
                        throw new InvalidDataException(err);
                    }
                    op.Operands[i] = LoadExpressionFromLines(expressionLines[1..j], indent + 1);

                    expressionLines = expressionLines[j..];
                }
            }

            return op;
        }
    }
}
