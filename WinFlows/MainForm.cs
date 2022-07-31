namespace WinFlows
{
    public partial class MainForm : Form
    {
        private static TextBox _console = null!;

        public MainForm()
        {
            InitializeComponent();
            _console = console;
            speedBar_Scroll(0, EventArgs.Empty);
        }

        public static void ConsoleWrite(string? s)
        {
            if (_console == null)
                return;

            if (s == null)
                _console.AppendText("ERROR: NULL VALUE");
            else
                _console.AppendText($"{Environment.NewLine}{s}");
        }

        private void btnVariables_Click(object sender, EventArgs e)
        {
            var varForm = new VariablesForm();
            varForm.Show();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!FlowChart.Instance.IsRunning)
                FlowChart.Instance.Execute();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var s = flowChart.GetSaveString();

            using var sfd = new SaveFileDialog();
            sfd.Filter = "Flowing files (*.flowing)|*.flowing|All files (*.*)|*.*";

            if (sfd.ShowDialog(this) == DialogResult.OK)
                File.WriteAllText(sfd.FileName, s);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string s;

            using var ofd = new OpenFileDialog();
            ofd.Filter = "Flowing files (*.flowing)|*.flowing|All files (*.*)|*.*";

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;

            s = File.ReadAllText(ofd.FileName);
            flowChart.LoadFromString(s);
        }

        private void speedBar_Scroll(object sender, EventArgs e)
        {
            Globals.Delay = speedBar.Value switch
            {
                5 => 0,
                4 => 125,
                3 => 250,
                2 => 500,
                1 => 1000,
                0 => 2000,
                _ => throw new ArgumentOutOfRangeException($"Speed {speedBar.Value} is not valid.")
            };
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (FlowChart.Instance.IsRunning)
                    FlowChart.Instance.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetUndoRedo(bool canUndo, bool canRedo)
        {
            btnUndo.Enabled = canUndo;
            btnRedo.Enabled = canRedo;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (flowChart.CanUndo)
                flowChart.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (flowChart.CanRedo)
                flowChart.Redo();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            var full = path + "\\last.pro";
            if (File.Exists(full))
            {
                try
                {
                    var load = File.ReadAllText(full);
                    FlowChart.Instance.LoadFromString(load);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not load last program, cannot continue where you left off. Error was {ex.Message}");
                    FlowChart.Instance.Reset();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            var full = path + "\\last.pro";
            var save = FlowChart.Instance.GetSaveString();

            try
            {
                File.WriteAllText(full, save);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save last program, won't be able to continue where you left off. Error was {ex.Message}");
            }
        }
    }
}