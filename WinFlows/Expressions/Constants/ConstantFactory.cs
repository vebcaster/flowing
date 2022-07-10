namespace WinFlows.Expressions.Constants
{
    public static class ConstantFactory
    {
        public static Constant Create(ExpressionTypes type)
        {
            return type switch
            {
                ExpressionTypes.Logical => new LogicalConstant(),
                ExpressionTypes.Number => new NumberConstant(),
                ExpressionTypes.String => new StringConstant(),
                _ => throw new InvalidOperationException("Constants can only be logical, numbers, or strings.")
            };
        }
    }
}
