using WinFlows.Draggables;
using WinFlows.Draggables.Variables;
using WinFlows.Expressions;
using WinFlows.Expressions.Slots;
using WinFlows.Expressions.Variables;

namespace WinFlows
{
    public partial class ExpressionBuilder : Form
    {
        public Expression Expression { get; set; }
        public ExpressionSlot MainSlot;
        private int _mainSlotTop = 0;
        private int _mainSlotLeft = 0;

        public ExpressionBuilder(Expression expression)
        {
            InitializeComponent();

            foreach (var child in Controls)
                if (child is Draggable)
                {
                    var drg = (Draggable)child;
                    if (_mainSlotTop < drg.Bottom + 30)
                        _mainSlotTop = drg.Bottom + 30;
                }
            _mainSlotLeft = variablesPanel.Right + 30;

            Expression = expression;
            UpdateData();
        }

        public void UpdateData()
        {
            UpdateData(true);
        }

        public void UpdateData(bool modelToView)
        {
            if (modelToView)
            {
                if (MainSlot != null)
                    Controls.Remove(MainSlot);

                MainSlot = ExpressionSlotFactory.Create(Expression);
                MainSlot.Location = new Point(_mainSlotLeft, _mainSlotTop);

                Controls.Add(MainSlot);
                MainSlot.RecalculateChildDepth();
                MainSlot.RepositionElements();
            }
            else
            {
                MainSlot.BuildExpression();
                Expression = MainSlot.Expression;
            }
        }

        private void ExpressionBuilder_Load(object sender, EventArgs e)
        {
            LoadVariables();
        }

        private void LoadVariables()
        {
            // TODO: Customize y and variable height
            int y = 30;
            foreach (var name in Variables.Names)
            {
                var var = Variables.Get(name);
                if (var != null)
                {
                    Draggable drgVar;
                    switch (var.Type)
                    {
                        case ExpressionTypes.Logical:
                            drgVar = new DragLogicalVariable(name);
                            break;
                        case ExpressionTypes.Number:
                            drgVar = new DragNumberVariable(name);
                            break;
                        case ExpressionTypes.String:
                            drgVar = new DragStringVariable(name);
                            break;
                        case ExpressionTypes.ListOfNumbers:
                            drgVar = new DragListOfNumbersVariable(name);
                            break;
                        default:
                            var err = $"ExpressionBuilder cannot show {var.Type} variables.";
                            MessageBox.Show(err);
                            throw new NotImplementedException(err);
                    }
                    drgVar.Location = new Point(10, y);
                    drgVar.Height = 40;
                    y += drgVar.Height + 15;
                    variablesPanel.Controls.Add(drgVar);
                }
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            UpdateData(false);
            Expression = MainSlot.Expression;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
