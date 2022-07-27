using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Expressions.Variables.Lists;

namespace WinFlows.Expressions
{
    public abstract class Expression
    {
        public ExpressionTypes Type { get; set; }
        public abstract object Evaluate();

        public Expression(ExpressionTypes type)
        {
            Type = type;
        }

        public virtual string Save(int indent)
        {
            MessageBox.Show("Cannot save base Expression. Override Save in derived expressions.");
            return "EXPRESSION:NOT_SAVED";
        }

        public static Expression LoadExpressionFromLines(string[] expressionLines, int indent)
        {
            expressionLines = Trim(expressionLines);

            if (!expressionLines[0].Trim().Equals($"EXPRESSIONLEVEL:{indent}:START"))
            {
                var err = $"Unexpected line {expressionLines[0]}. Was expecting EXPRESSIONLEVEL:{indent}:START";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }
            if (!expressionLines[expressionLines.Length - 1].Trim().Equals($"EXPRESSIONLEVEL:{indent}:END"))
            {
                var err = $"Unexpected line {expressionLines[expressionLines.Length - 1]}. Was expecting EXPRESSIONLEVEL:{indent}:END";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }

            expressionLines = expressionLines[1..(expressionLines.Length - 1)];

            var index = expressionLines[0].IndexOf(":");
            var first = expressionLines[0].Substring(0, index);
            var second = expressionLines[0].Substring(index + 1);

            return first.Trim() switch
            {
                "CONSTANT_LOGICAL" => new LogicalConstant(bool.Parse(second)),
                "CONSTANT_NUMBER" => new NumberConstant(float.Parse(second)),
                "CONSTANT_STRING" => new StringConstant(second),
                "CONSTANT_NOT_SET" => new NotSetConstant(),
                "VARIABLE" => Variables.Variables.Names.Contains(second)
                                ? Variables.Variables.Get(second) :
                                    second.Equals("Drag a list here")
                                    ? new DummyListOfNumbers()
                                    : new NotSetVariable(),
                "OPERATOR" => Operator.LoadOperatorFromLines(expressionLines, indent),
                _ => throw new ArgumentException($"{first} is not a valid start for an Expression")
            };
        }

        protected static string[] Trim(string[] expressionLines)
        {
            while (string.IsNullOrWhiteSpace(expressionLines[0]))
                expressionLines = expressionLines[1..];
            while (string.IsNullOrWhiteSpace(expressionLines[expressionLines.Length - 1]))
                expressionLines = expressionLines[..(expressionLines.Length - 1)];

            return expressionLines;
        }
    }
}
