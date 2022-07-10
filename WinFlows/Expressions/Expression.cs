namespace WinFlows.Expressions
{
    public abstract class Expression
    {
        public ExpressionTypes Type { get; set; }
        public abstract object Evaluate();

        public Expression(ExpressionTypes type)
        {
            Type = type;
        }
    }
}
