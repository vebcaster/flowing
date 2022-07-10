using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Variables;
using WinFlows.Expressions.Variables.Lists;

namespace WinFlows.Expressions.Operators
{
    public class AssignmentOperator : Operator
    {
        public AssignmentOperator(ExpressionTypes type)
            : base(type,
                new string[] { "  ", " = ", " " },
                new string[] { string.Empty, " = ", string.Empty })
        {
        }

        public AssignmentOperator()
            : base(ExpressionTypes.NotSet,
                new string[] { "  ", " = ", " " },
                new string[] { string.Empty, " = ", string.Empty })
        {
            Operands[0] = new NotSetVariable();
            Operands[1] = new NotSetConstant();
        }

        public override object Evaluate()
        {
            if (Operands[0] is NotSetVariable || Operands[1] is NotSetConstant)
            {
                MessageBox.Show("Double-click the ASSIGN block to select a variable and a value for assignment.");
                return false;
            }

            if (Operands[0].Type != Operands[1].Type)
            {
                var err = $"Assignment operator should have the same type on both operands. This one has {Operands[0].Type} and {Operands[1].Type}.";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            var result = Operands[1].Evaluate();

            if (Operands[0] is Variable)
            {
                var variable = (Variable)Operands[0];
                variable.Set(result);
            }
            else if (Operands[0] is ElementOfListOperator)
            {
                var elementOfList = (ElementOfListOperator)Operands[0];
                var listName = elementOfList.ListName;
                var index = elementOfList.ElementIndex;

                var list = (ListOfVariables)Variables.Variables.Get(listName);
                list[index] = result;
            }
            else
            {
                var err = $"First operand in assignment must be either variable or element of a list, but it is {Operands[0].GetType()}";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            return result;
        }
    }
}
