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

        public virtual string Save(int indent)
        {
            MessageBox.Show("Cannot save Expression");
            return "EXPRESSION:NOT_SAVED";
        }
    }
}
