using System.Data;
using WinFlows.Expressions;
using WinFlows.Expressions.Variables;

namespace WinFlows
{
    public partial class CreateVariable : Form
    {
        public CreateVariable()
        {
            InitializeComponent();
        }

        private void CreateVariable_Load(object sender, EventArgs e)
        {
            var enumValues = Enum.GetNames(typeof(ExpressionTypes))
                .Cast<string>()
                .ToArray();
            cmbType.Items.AddRange(enumValues);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ExpressionTypes type;
            string name;

            if (cmbType.SelectedItem == null)
            {
                MessageBox.Show("Please select a variable type.", "Action required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.DroppedDown = true;
                return;
            }

            if (!Enum.TryParse(cmbType.SelectedItem.ToString(), out type))
            {
                MessageBox.Show("Error parsing ExpressionTypes enum.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please type a name for the variable.", "Action required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.SelectAll();
                txtName.Select();
                return;
            }

            name = txtName.Text.Trim();
            if (Variables.Exists(name))
            {
                MessageBox.Show("A variable with this name already exists. Please choose a different name.", "Action required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.SelectAll();
                txtName.Select();
                return;
            }

            Variables.Create(name, type);
            DialogResult = DialogResult.OK;
        }
    }
}
