namespace WinFlows
{
    public partial class OptionCombo : Form
    {
        public string SelectedItem { get; set; } = string.Empty;

        public OptionCombo()
        {
            InitializeComponent();
        }

        public OptionCombo(List<string> options, string title, string selectedItem)
        {
            InitializeComponent();
            Text = title;
            options.ForEach(option => cmbOptions.Items.Add(option));
            if (!string.IsNullOrEmpty(selectedItem))
                cmbOptions.SelectedItem = selectedItem;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbOptions.SelectedItem == null)
            {
                MessageBox.Show("Please choose an option from the list.", "Action required", MessageBoxButtons.OK);
                cmbOptions.Select();
                cmbOptions.DroppedDown = true;
                return;
            }
            SelectedItem = cmbOptions.SelectedItem.ToString()!;
            DialogResult = DialogResult.OK;
        }

        private void OptionCombo_Load(object sender, EventArgs e)
        {
            cmbOptions.Select();
        }
    }
}
