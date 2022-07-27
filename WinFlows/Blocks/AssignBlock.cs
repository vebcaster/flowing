using System.Text;
using WinFlows.Expressions;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class AssignBlock : Block
    {
        public AssignmentOperator AssignmentOperator { get; set; }

        public AssignBlock()
        {
            InitializeComponent();

            AssignmentOperator = new AssignmentOperator();
        }

        public override Block? Execute()
        {
            AssignmentOperator.Evaluate();

            return base.Execute();
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.AssignStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.AssignFill);

            g.FillRectangle(brush, Globals.BlockRect);
            g.DrawRectangle(pen, Globals.BlockRect);

            if (AssignmentOperator.Operands[0] is NotSetVariable)
                StringHelper.DrawStringInsideBox(g, Globals.BlockRectTwoThirds, ColorScheme.AssignText, "ASSIGN");
            else
                StringHelper.DrawStringInsideBox(g, Globals.BlockRect, ColorScheme.AssignText, AssignmentOperator.ToString());
        }

        public override void DoubleClicked()
        {
            var variableNames = Variables.Names;

            if (!variableNames.Any())
            {
                MessageBox.Show("There are no variables to assign values to. Create some variables first.");
                return;
            }

            var original = AssignmentOperator.Save(0);

            using var exprBuilder = new ExpressionBuilder(AssignmentOperator);
            if (exprBuilder.ShowDialog(this) == DialogResult.OK)
            {
                AssignmentOperator = (AssignmentOperator)exprBuilder.Expression;
                Invalidate();
            }
            else
            {
                AssignmentOperator = (AssignmentOperator)Expression.LoadExpressionFromLines(original.Split(Environment.NewLine), 0);
            }
        }

        public override string Save()
        {
            var sb = new StringBuilder(base.Save());

            var assignmentOperator = AssignmentOperator.Save(0);
            sb.AppendLine($"ASSIGNMENT:");
            sb.AppendLine(assignmentOperator);

            return sb.ToString();
        }
    }
}
