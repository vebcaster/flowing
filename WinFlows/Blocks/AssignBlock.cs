using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class AssignBlock : Block
    {
        private AssignmentOperator _assignmentOperator;

        public AssignBlock()
        {
            InitializeComponent();

            _assignmentOperator = new AssignmentOperator();
        }

        public override Block? Execute()
        {
            _assignmentOperator.Evaluate();

            return base.Execute();
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.AssignStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.AssignFill);

            g.FillRectangle(brush, Globals.BlockRect);
            g.DrawRectangle(pen, Globals.BlockRect);

            if (_assignmentOperator.Operands[0] is NotSetVariable)
                StringHelper.DrawStringInsideBox(g, Globals.BlockRect, ColorScheme.AssignText, "ASSIGN");
            else
                StringHelper.DrawStringInsideBox(g, Globals.BlockRect, ColorScheme.AssignText, _assignmentOperator.ToString());
        }

        public override void DoubleClicked()
        {
            var variableNames = Variables.Names;

            if (!variableNames.Any())
            {
                MessageBox.Show("There are no variables to assign values to. Create some variables first.");
                return;
            }

            using var exprBuilder = new ExpressionBuilder(_assignmentOperator);
            if (exprBuilder.ShowDialog(this) != DialogResult.OK)
                return;

            _assignmentOperator = (AssignmentOperator)exprBuilder.Expression;

            Invalidate();
        }
    }
}
