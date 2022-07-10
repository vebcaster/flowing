using WinFlows.Expressions.Variables.Lists;

namespace WinFlows.Expressions.Variables
{
    public abstract class Variable : Expression
    {
        protected object _value = null;
        private string _name;

        public abstract void Set(object val);

        public Variable(ExpressionTypes type, string name) : base(type)
        {
            _name = name;
        }

        public override object Evaluate()
        {
            return _value;
        }

        public static Variable Create(ExpressionTypes type, string name)
        {
            switch (type)
            {
                case ExpressionTypes.Logical:
                    return new LogicalVariable(name);
                case ExpressionTypes.Number:
                    return new NumberVariable(name);
                case ExpressionTypes.String:
                    return new StringVariable(name);
                case ExpressionTypes.ListOfNumbers:
                    return new ListOfNumbers(name);
                default:
                    MessageBox.Show($"Variables of type {type} are not supported yet. Making a string instead.");
                    return new StringVariable(name);
            }
        }

        public static ExpressionTypes TypeFromString(string typeName)
        {
            typeName = typeName.ToLower();

            if (typeName.Contains("list"))
            {
                MessageBox.Show($"Variables of type {typeName} are not supported yet. Making a string instead.");
                return ExpressionTypes.String;
            }

            if (typeName.Contains("logic"))
                return ExpressionTypes.Logical;
            if (typeName.Contains("number"))
                return ExpressionTypes.Number;
            if (typeName.Contains("string"))
                return ExpressionTypes.String;

            MessageBox.Show($"Could not figure out variable type for {typeName}. Making a string instead.");
            return ExpressionTypes.String;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
