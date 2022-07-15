namespace WinFlows
{
    public partial class MainForm : Form
    {
        private static TextBox _console = null!;

        public MainForm()
        {
            InitializeComponent();
            _console = console;
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
    }
}