using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class InBlock : Block
    {
        private string? _variableName;

        public InBlock()
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
                StringHelper.DrawStringInsideBox(g, rect, ColorScheme.StartText, "INPUT");
            else
                StringHelper.DrawStringInsideBox(g, rect, ColorScheme.StartText, $"\u2192{_variableName}");
        }

        public override void DoubleClicked()
        {
            var variableNames = Variables.Names;

            if (!variableNames.Any())
            {
                MessageBox.Show("There are no variables to read. Create some variables first.");
                return;
            }

            using var combo = new OptionCombo(variableNames, "Which variable to read?", _variableName);
            combo.ShowDialog(this);
            if (combo.DialogResult == DialogResult.OK)
            {
                _variableName = combo.SelectedItem;
                Invalidate();
            }
        }

        public override Block? Execute()
        {
            if (string.IsNullOrWhiteSpace(_variableName))
            {
                MessageBox.Show("INPUT block is missing variable. Please select a variable to read by double-clicking the block.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Variables.Exists(_variableName))
            {
                MessageBox.Show("This variable no longer exists. Please select a new variable to read by double-clicking the block.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (Variables.Get(_variableName).Type)
                {
                    case Expressions.ExpressionTypes.Logical:
                        ReadLogical();
                        break;
                    case Expressions.ExpressionTypes.Number:
                        ReadNumber();
                        break;
                    case Expressions.ExpressionTypes.String:
                        ReadString();
                        break;
                    default:
                        MessageBox.Show("Catn't read this type of variable.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            return South;
        }

        private void ReadNumber()
        {
            if (_variableName == null)
            {
                MessageBox.Show("_variableName should not be null here");
                return;
            }

            float typedNumber;

            using var optionString = new OptionString($"Input numerical value for {_variableName}", "", false, true);
            if (optionString.ShowDialog(this) == DialogResult.OK)
            {
                if (!float.TryParse(optionString.TypedText, out typedNumber))
                {
                    var err = $"float could not parse {typedNumber}";
                    MessageBox.Show(err);
                    throw new InvalidOperationException(err);
                }

                Variables.Get(_variableName).Set(typedNumber);
            }
        }

        private void ReadString()
        {
            if (_variableName == null)
            {
                MessageBox.Show("_variableName should not be null here");
                return;
            }

            var ok = false;
            while (!ok)
            {
                using var optionString = new OptionString($"Input value for {_variableName}", "", true, false);
                if (optionString.ShowDialog(this) == DialogResult.OK)
                {
                    Variables.Get(_variableName).Set(optionString.TypedText);
                    ok = true;
                }
            }
        }

        private void ReadLogical()
        {
            if (_variableName == null)
            {
                MessageBox.Show("_variableName should not be null here");
                return;
            }

            var values = new List<string> { "False", "True" };
            var ok = false;
            while (!ok)
            {
                using var optionCombo = new OptionCombo(values, $"Input value for {_variableName}", string.Empty);
                if (optionCombo.ShowDialog(this) == DialogResult.OK)
                {
                    switch (optionCombo.SelectedItem)
                    {
                        case "True":
                            Variables.Get(_variableName).Set(true);
                            ok = true;
                            break;
                        case "False":
                            Variables.Get(_variableName).Set(false);
                            ok = true;
                            break;
                    }
                }
            }
        }
    }
}
