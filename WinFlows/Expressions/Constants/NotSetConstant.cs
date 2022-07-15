namespace WinFlows.Expressions.Constants
{
    /// <summary>
    /// This class is only used as a temporary placeholder in the assignment process
    /// or operator, until we find out what type of value needs to be assigned
    /// </summary>
    public class NotSetConstant : Constant
    {
        public NotSetConstant() : base(ExpressionTypes.NotSet)
        {
        }

        public override object Evaluate()
        {
            throw new NotSupportedException("Do not call Evaluate on NotSet constants.");
        }

        public override string ToString()
        {
            return "DRAG SOMETHING HERE";
        }

        public override string Save(int indent)
        {
            return
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:START{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}CONSTANT_NOT_SET:NOT_SET{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:END{Environment.NewLine}";
        }
    }
}
