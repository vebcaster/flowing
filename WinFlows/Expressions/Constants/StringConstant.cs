namespace WinFlows.Expressions.Constants
{
    public class StringConstant : Constant
    {
        public string Value { get; set; } = string.Empty;

        public StringConstant() : base(ExpressionTypes.String)
        {
        }

        public StringConstant(string val) : base(ExpressionTypes.String)
        {
            Value = val;
        }

        public override object Evaluate()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
