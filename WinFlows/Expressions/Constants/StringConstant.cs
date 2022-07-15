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

        public override string Save(int indent)
        {
            return
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:START{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}CONSTANT_STRING:{Value} {Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:END{Environment.NewLine}";
        }
    }
}
