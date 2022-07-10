namespace WinFlows.Expressions.Variables
{
    public class LogicalVariable : Variable
    {
        public LogicalVariable(string name) : base(ExpressionTypes.Logical, name)
        {
            _value = false;
        }

        public override void Set(object val)
        {
            if (val.GetType() != typeof(bool))
            {
                MessageBox.Show($"Cannot set boolean variable to {val.GetType()} type.");
                return;
            }
            _value = val;
        }
    }
}
