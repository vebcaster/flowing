using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFlows.Expressions;
using WinFlows.Expressions.Variables;

namespace WinFlows
{
    public partial class VariablesForm : Form
    {
        public VariablesForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using var createVariable = new CreateVariable();
            if (createVariable.ShowDialog(this) == DialogResult.OK)
                RefreshVariableList();
        }

        private void RefreshVariableList()
        {
            lstVariables.Items.Clear();
            Variables.Names.ForEach(
                x =>
                {
                    var lvi = new ListViewItem(x);
                    lvi.SubItems.Add(Variables.Get(x).Evaluate().ToString());
                    lvi.SubItems.Add(Variables.Get(x).Type.ToString());
                    lstVariables.Items.Add(lvi);
                });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshVariableList();
        }

        private void VariablesForm_Load(object sender, EventArgs e)
        {
            RefreshVariableList();
        }
    }
}
