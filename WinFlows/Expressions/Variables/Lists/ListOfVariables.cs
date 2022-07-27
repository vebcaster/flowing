namespace WinFlows.Expressions.Variables.Lists
{
    public abstract class ListOfVariables : Variable
    {
        private object[] _array = new object[0];

        public ListOfVariables(ExpressionTypes type, string name)
            : base(type, name)
        {
        }

        public override object Evaluate()
        {
            var count = _array == null ? 0 : _array.Length;
            return $"Contains {count} elements.";
        }

        public override void Set(object val)
        {
            var err = "Calling Set() on lists is not allowed.";
            MessageBox.Show(err);
            throw new InvalidOperationException(err);
        }

        public virtual object this[int key]
        {
            get
            {
                if (_array.Length <= key)
                {
                    MessageBox.Show($"Attempted to read element {key} of the array {ToString()}, but the array only has {_array.Length} elements.");
                    return "ERROR";
                }
                return _array[key];
            }
            set
            {
                if (_array.Length <= key)
                {
                    Array.Resize(ref _array, key + 1);
                }
                _array[key] = value;
            }
        }
    }
}
