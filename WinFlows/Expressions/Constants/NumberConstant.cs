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
    }
}
