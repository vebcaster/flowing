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
                "NUMBERS_LESS_THAN" => new NumberLessThanOperator(),
                "NUMBERS_LESS_OR_EQUAL" => new NumberLessThanOrEqualOperator(),
                "NUMBERS_GREATER_THAN" => new NumberGreaterThanOperator(),
                "NUMBERS_GREATER_OR_EQUAL" => new NumberGreaterThanOrEqualOperator(),
                "STRINGS_ARE_EQUAL" => new StringsAreEqualOperator(),
                "LOGICAL_ELEMENT_OF_LIST" => new LogicalElementOfListOperator(),

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
                "STRING_ELEMENT_OF_LIST" => new StringElementOfListOperator(),

                // What is this?
                _ => throw new NotImplementedException($"OperatorFactory cannot build {op}")
            };
        }
    }
}
