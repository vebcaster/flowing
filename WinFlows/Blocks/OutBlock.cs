using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class OutBlock : Block
    {
        private string? _variableName;

        public OutBlock()
        {
            InitializeComponent();
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.InStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.InFill);
            var rect = Globals.BlockRect;

            var points = new Point[] {
                new Point(rect.Right / 5, rect.Top),
                new Point(rect.Right, rect.Top),
                new Point(rect.Right * 4 / 5, rect.Bottom),
                new Point(rect.Left, rect.Bottom)
            };

            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);
            if (_variableName == null)
                StringHelper.DrawStringInsideBox(g, rect, ColorScheme.StartText, "OUTPUT");
            else
                StringHelper.DrawStringInsideBox(g, rect, ColorScheme.StartText, $"\u2190{_variableName}");
        }

        public override void DoubleClicked()
        {
            var variableNames = Variables.Names;

            if (!variableNames.Any())
            {
                MessageBox.Show("There are no variables to read. Create some variables first.");
                return;
            }

            using var combo = new OptionCombo(variableNames, "Which variable to write?", _variableName);
            combo.ShowDialog(this);
            if (combo.DialogResult == DialogResult.OK)
            {
                _variableName = combo.SelectedItem;
                Invalidate();
            }
        }

        public override Block? Execute()
        {
            if (string.IsNullOrEmpty(_variableName))
                MainForm.ConsoleWrite("ERROR: Nothing to write");
            else if (!Variables.Exists(_variableName))
                MainForm.ConsoleWrite($"ERROR: Variable {_variableName} no longer exists");
            else
                MainForm.ConsoleWrite(Variables.Get(_variableName).Evaluate().ToString());
            return South;
        }
    }
}
