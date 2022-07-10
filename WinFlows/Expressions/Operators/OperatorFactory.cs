using WinFlows.Expressions.Operators.Logical;
using WinFlows.Expressions.Operators.Number;
using WinFlows.Expressions.Operators.String;

namespace WinFlows.Expressions.Operators
{
    public static class OperatorFactory
    {
        public static Operator Build(string op)
        {
            return op switch
            {
                // Logical
                "AND" => new LogicalAndOperator(),
                "NOT" => new LogicalNotOperator(),
                "OR" => new LogicalOrOperator(),
                "XOR" => new LogicalXorOperator(),
                "NUMBERS_ARE_EQUAL" => new NumbersAreEqualOperator(),
                "STRINGS_ARE_EQUAL" => new StringsAreEqualOperator(),

                // Numbers
                "PLUS" => new NumberAddOperator(),
                "MINUS" => new NumberSubtractOperator(),
                "MULTIPLY" => new NumberMultiplyOperator(),
                "DIVIDE" => new NumberDivideOperator(),
                "MODULO" => new NumberModuloOperator(),
                "FLOOR" => new NumberFloorOperator(),
                "CEILING" => new NumberCeilingOperator(),
                "ROUND" => new NumberRoundOperator(),
                "NUMBER_ELEMENT_OF_LIST" => new NumberElementOfListOperator(),

                // Strings
                "CONCAT" => new StringConcatenateOperator(),

                // What is this?
                _ => throw new NotImplementedException($"OperatorFactory cannot build {op}")
            };
        }
    }
}
