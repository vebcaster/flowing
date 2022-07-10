using WinFlows.Expressions.Variables.Lists;

namespace WinFlows.Expressions.Operators
{
    public abstract class ElementOfListOperator : Operator
    {
        public string ListName { get => ((ListOfVariables)Operands[1]).ToString(); }
        public int ElementIndex { get => Convert.ToInt32(Operands[0].Evaluate()); }

        public ElementOfListOperator(ExpressionTypes type)
            : base(type,
                new string[] { " ELEMENT ", " OF ", " " },
                new string[] { " ELEMENT ", " OF ", string.Empty })
        {
        }
    }
}
