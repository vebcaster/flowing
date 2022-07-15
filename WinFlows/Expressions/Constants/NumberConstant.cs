namespace WinFlows.Expressions.Constants
{
    public class NumberConstant : Constant
    {
        public float Value { get; set; } = 1.0f;

        public NumberConstant() : base(ExpressionTypes.Number)
        {
        }

        public NumberConstant(float val) : base(ExpressionTypes.Number)
        {
            Value = val;
        }

        public override object Evaluate()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override string Save(int indent)
        {
            return
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:START{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}CONSTANT_NUMBER:{Value}{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:END{Environment.NewLine}";
        }
    }
}
