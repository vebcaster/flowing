namespace WinFlows
{
    public partial class OptionString : Form
    {
        private bool _allowEmptyString = false;
        private bool _mustConvertToNumber = false;
        public string TypedText { get; private set; } = string.Empty;

        public OptionString()
        {
            InitializeComponent();
        }

        public OptionString(string title, string initialValue, bool allowEmptyString, bool mustConvertToNumber)
        {
            InitializeComponent();
            Text = title;
            txtOption.Text = initialValue;
            _allowEmptyString = allowEmptyString;
            _mustConvertToNumber = mustConvertToNumber;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOption.Text) && !_allowEmptyString)
            {
                MessageBox.Show("Please type something.", "Action required", MessageBoxButtons.OK);
                txtOption.SelectAll();
                txtOption.Select();
                return;
            }

            if (_mustConvertToNumber)
            {
                if (!float.TryParse(txtOption.Text, out _))
                {
                    MessageBox.Show("Please type a number.", "Action required", MessageBoxButtons.OK);
                    txtOption.SelectAll();
                    txtOption.Select();
                    return;
                }
            }

            TypedText = txtOption.Text;
            DialogResult = DialogResult.OK;
        }

        private void OptionString_Load(object sender, EventArgs e)
        {
            txtOption.SelectAll();
            txtOption.Select();
        }
    }
}
