namespace WinFlows.Expressions.Variables
{
    public class NumberVariable : Variable
    {
        public NumberVariable(string name) : base(ExpressionTypes.Number, name)
        {
            _value = 0f;
        }

        public override void Set(object val)
        {
            if (val.GetType() != typeof(int) && val.GetType() != typeof(float))
            {
                MessageBox.Show($"Cannot set number variable to {val.GetType()} type.");
                return;
            }

            _value = Convert.ToSingle(val);
        }
    }
}
