using WinFlows.Expressions.Constants;
using WinFlows.Expressions.Operators;
using WinFlows.Expressions.Variables;
using WinFlows.Helpers;

namespace WinFlows.Expressions.Slots
{
    public partial class ExpressionSlot : UserControl
    {
        public Expression Expression { get; set; }
        public int ChildDepth { get; set; }
        protected bool _isHighlighted = false;

        public virtual void Repaint(Graphics g)
        {
            g.DrawLine(Pens.Red, 0, 0, Width, Height);
            g.DrawLine(Pens.Red, 0, Height, Width, 0);
        }

        /// <summary>
        /// Return true to reload
        /// </summary>
        public virtual bool DoubleClicked() => false;

        public virtual bool AcceptsDraggableData(string? kind, string? type, string? what) { return false; }

        public ExpressionSlot(Expression expression)
        {
            InitializeComponent();

            Expression = expression;
            Size = Globals.OperandSize;
            AllowDrop = true;
            SetStyle(
                ControlStyles.SupportsTransparentBackColor
                | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;

            if (expression is Operator)
            {
                var op = (Operator)expression;

                for (int i = 0; i < op.Operands.Length; i++)
                {
                    var operand = ExpressionSlotFactory.Create(op.Operands[i]);
                    Controls.Add(operand);
                    operand.Tag = i;        // Remember in which order they are
                }
            }
        }

        public void RecalculateChildDepth()
        {
            if (Expression is Variable || Expression is Constant)
                ChildDepth = 0;
            else
            {
                var max = 0;
                foreach (var child in Controls)
                    if (child is ExpressionSlot)
                    {
                        var slot = (ExpressionSlot)child;
                        slot.RecalculateChildDepth();
                        max = Math.Max(max, slot.ChildDepth);
                    }
                ChildDepth = max + 1;
            }
        }

        public void RepositionElements()
        {
            foreach (var child in Controls)
                if (child is ExpressionSlot)
                    ((ExpressionSlot)child).RepositionElements();

            Height = Globals.OperandSize.Height + Globals.SlotPadding * ChildDepth;

            if (Expression is Operator)
            {
                var op = (Operator)Expression;
                var x = Globals.SlotPadding;

                for (int i = 0; i < op.Operands.Length; i++)
                {
                    x += op.SlotTexts[i].Length * Globals.PixelsPerLetterInSlotText;

                    var operandSlot = FindControlByTag(i);

                    operandSlot.Left = x;
                    operandSlot.Top = Height / 2 - operandSlot.Height / 2;
                    x += operandSlot.Width + Globals.SlotPadding;
                }
                x += op.SlotTexts[op.Operands.Length].Length * Globals.PixelsPerLetterInSlotText;
                Width = x;
            }
            else
            {
                Width = Math.Max(Globals.OperandSize.Width, Expression.ToString().Length * Globals.PixelsPerLetterInSlotText);
                Height = Globals.OperandSize.Height;
            }
            Invalidate();
        }

        public ExpressionSlot FindControlByTag(int tag)
        {
            foreach (var child in Controls)
                if (child is ExpressionSlot && (int)((ExpressionSlot)child).Tag == tag)
                    return (ExpressionSlot)child;

            var err = $"Could not find child ExpressionSlot with Tag {tag}";
            MessageBox.Show(err);
            throw new ArgumentException(err);
        }

        private void ExpressionSlot_Paint(object sender, PaintEventArgs e)
        {
            Repaint(e.Graphics);
        }

        private void ExpressionSlot_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClicked())
            {
                ((ExpressionBuilder)FindForm()).UpdateData(false);
                ((ExpressionBuilder)FindForm()).UpdateData();
            }
        }

        private void ExpressionSlot_DragEnter(object sender, DragEventArgs e)
        {
            // Generic logic that rejects stuff from the start, related to assignment and LVALUE
            // Nothing can be dropped to replace an AssignmentOperator
            if (Expression is AssignmentOperator)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            // If it's on the left side of an assignment, only variables and elements of lists are allowed
            bool lValuesOnly = false;
            if (Parent is ExpressionSlot
                && ((ExpressionSlot)Parent).Expression is AssignmentOperator
                && (int)Tag == 0)
                lValuesOnly = true;

            string? data;
            if (e.Data != null && e.Data.GetData(DataFormats.Text) != null)
                data = e.Data.GetData(DataFormats.Text).ToString();
            else
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            var (kind, type, what) = StringHelper.SplitDragDropDataForExpressions(data);

            if (lValuesOnly
                && kind.Equals("OPERATOR")
                && what != null
                && !what.Contains("ELEMENT_OF_LIST"))
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

            if (AcceptsDraggableData(kind, type, what))
            {
                e.Effect = DragDropEffects.Copy;
                if (!_isHighlighted)
                {
                    _isHighlighted = true;
                    Invalidate();
                }
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void ExpressionSlot_DragDrop(object sender, DragEventArgs e)
        {
            string? data = null;
            if (e.Data != null && e.Data.GetData(DataFormats.Text) != null)
                data = e.Data.GetData(DataFormats.Text).ToString();
            else
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            var (kind, type, what) = StringHelper.SplitDragDropDataForExpressions(data);

            if (!AcceptsDraggableData(kind, type, what))
                return;

            RemoveOperandSlots();
            Dropped(kind, type, what);
            ((ExpressionBuilder)FindForm()).UpdateData(false);
            ((ExpressionBuilder)FindForm()).UpdateData();
        }

        public virtual void Dropped(string? kind, string? type, string? what)
        {
            if (kind == null || type == null || what == null
                || !AcceptsDraggableData(kind, type, what))
                return;

            if (kind.Equals("VARIABLE"))
                Expression = Variables.Variables.Get(what);
            else if (kind.Equals("OPERATOR"))
                Expression = OperatorFactory.Build(what);
        }

        private void RemoveOperandSlots()
        {
            while (Controls.Count > 0)
            {
                Controls.RemoveAt(0);
            }
        }

        public void BuildExpression()
        {
            if (Expression is Variable || Expression is Constant)
                return;

            if (Expression is Operator)
            {
                var op = (Operator)Expression;
                foreach (var child in Controls)
                    if (child is ExpressionSlot)
                    {
                        var slot = (ExpressionSlot)child;
                        slot.BuildExpression();
                        op.Operands[(int)slot.Tag] = slot.Expression;
                    }
            }
        }

        private void ExpressionSlot_DragLeave(object sender, EventArgs e)
        {
            if (_isHighlighted)
            {
                _isHighlighted = false;
                Invalidate();
            }
        }
    }
}
