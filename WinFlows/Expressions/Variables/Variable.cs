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
                case ExpressionTypes.ListOfStrings:
                    return new ListOfStrings(name);
                case ExpressionTypes.ListOfLogicals:
                    return new ListOfLogicals(name);
                default:
                    MessageBox.Show($"Variables of type {type} are not supported yet. Making a string instead.");
                    return new StringVariable(name);
            }
        }

        public override string ToString()
        {
            return _name;
        }

        public override string Save(int indent)
        {
            return
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:START{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}VARIABLE:{_name}{Environment.NewLine}" +
                $"{string.Empty.PadLeft(indent * 2)}EXPRESSIONLEVEL:{indent}:END{Environment.NewLine}";
        }
    }
}
