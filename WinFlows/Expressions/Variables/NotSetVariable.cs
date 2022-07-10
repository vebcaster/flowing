namespace WinFlows.Expressions.Variables
{
    /// <summary>
    /// This is only used in the Assignment operator as a temporary placeholder
    /// until the user decides which variable or list element to assign to
    /// </summary>
    public class NotSetVariable : Variable
    {
        public NotSetVariable() : base(ExpressionTypes.NotSet, "DRAG A VARIABLE OR LIST ELEMENT HERE")
        {
            _value = "DRAG A VARIABLE OR LIST ELEMENT HERE";
        }

        public override void Set(object val)
        {
            throw new NotSupportedException("Do not call Set on undefined variables");
        }
    }
}
