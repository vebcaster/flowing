using System.Text;

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

        public override string Save(int indent)
        {
            return
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:START{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}CONSTANT_LOGICAL:{Value}{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:END{Environment.NewLine}";
        }
    }
}
