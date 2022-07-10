namespace WinFlows.Expressions.Variables
{
    public class StringVariable : Variable
    {
        public StringVariable(string name) : base(ExpressionTypes.String, name)
        {
            _value = string.Empty;
        }

        public override void Set(object val)
        {
            if (val.GetType() != typeof(string))
            {
                MessageBox.Show($"Cannot set string variable to {val.GetType()} type.");
                return;
            }
            _value = val == null ? string.Empty : val;
        }
    }
}
