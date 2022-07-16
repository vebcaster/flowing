namespace WinFlows.Expressions.Slots
{
    public static class ExpressionSlotFactory
    {
        public static ExpressionSlot Create(Expression expression)
        {
            return expression.Type switch
            {
                ExpressionTypes.Logical => new LogicalExpressionSlot(expression),
                ExpressionTypes.Number => new NumberExpressionSlot(expression),
                ExpressionTypes.String => new StringExpressionSlot(expression),
                ExpressionTypes.ListOfNumbers => new ListOfNumbersExpressionSlot(expression),
                ExpressionTypes.ListOfStrings => new ListOfStringsExpressionSlot(expression),
                ExpressionTypes.ListOfLogicals => new ListOfLogicalsExpressionSlot(expression),
                ExpressionTypes.NotSet => new NotSetExpressionSlot(expression),
                _ => throw new Exception($"ExpressionSlotFactory cannot handle type {expression.Type}.")
            };
        }
    }
}
