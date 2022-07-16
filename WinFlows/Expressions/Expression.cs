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
            MessageBox.Show("Cannot save base Expression. Override Save in derived expressions.");
            return "EXPRESSION:NOT_SAVED";
        }
    }
}
