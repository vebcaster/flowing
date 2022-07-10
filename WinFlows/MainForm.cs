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
    }
}