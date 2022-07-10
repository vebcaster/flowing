using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Slots;

namespace WinFlows.Helpers
{
    public static class OperatorSlotHelper
    {
        public static void WriteOperatorTexts(Graphics g, ExpressionSlot slot, Color color)
        {
            if (slot.Expression is not Operator)
            {
                var err = $"WriteOperatorTexts does not work with {slot.Expression.GetType()}";
                MessageBox.Show(err);
                throw new InvalidOperationException(err);
            }

            var op = (Operator)slot.Expression;
            var x = Globals.SlotPadding;
            for (int i = 0; i < op.SlotTexts.Length; i++)
            {
                string text = op.SlotTexts[i];
                if (!string.IsNullOrEmpty(text))
                    StringHelper.DrawStringInsideBox(
                        g,
                        new Rectangle(x, 0, text.Length * Globals.PixelsPerLetterInSlotText, Globals.OperandSize.Height),
                        color,
                        text
                        );

                if (i < op.Operands.Length)
                    x = slot.FindControlByTag(i).Right + Globals.SlotPadding;
            }
        }
    }
}
