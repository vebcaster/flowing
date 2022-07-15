using System.Text;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class OutBlock : Block
    {
        public string? VariableName { private get; set; }

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
            if (string.IsNullOrWhiteSpace(VariableName))
                StringHelper.DrawStringInsideBox(g, Globals.BlockRectTwoThirds, ColorScheme.StartText, "OUTPUT");
            else
                StringHelper.DrawStringInsideBox(g, rect, ColorScheme.StartText, $"\u2190{VariableName}");
        }

        public override void DoubleClicked()
        {
            var variableNames = Variables.Names.Where(v => !Variables.Get(v).Type.ToString().ToLower().Contains("list")).ToList();

            if (!variableNames.Any())
            {
                MessageBox.Show("There are no variables to read. Create some variables first.");
                return;
            }

            using var combo = new OptionCombo(variableNames, "Which variable to write?", VariableName);
            combo.ShowDialog(this);
            if (combo.DialogResult == DialogResult.OK)
            {
                VariableName = combo.SelectedItem;
                Invalidate();
            }
        }

        public override Block? Execute()
        {
            if (string.IsNullOrEmpty(VariableName))
                MainForm.ConsoleWrite("ERROR: Nothing to write");
            else if (!Variables.Exists(VariableName))
                MainForm.ConsoleWrite($"ERROR: Variable {VariableName} no longer exists");
            else
                MainForm.ConsoleWrite(Variables.Get(VariableName).Evaluate().ToString());
            return South;
        }

        public override string Save()
        {
            var sb = new StringBuilder(base.Save());

            sb.AppendLine($"VARIABLE:{VariableName}");

            return sb.ToString();
        }
    }
}
