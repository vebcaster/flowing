namespace WinFlows.Expressions.Constants
{
    public class LogicalConstant : Constant
    {
        public bool Value { get; set; } = false;

        public override object Evaluate()
        {
            return Value;
        }

        public LogicalConstant() : base(ExpressionTypes.Logical)
        {
        }

        public LogicalConstant(bool val) : base(ExpressionTypes.Logical)
        {
            Value = val;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
