namespace WinFlows.Draggables
{
    public partial class Draggable : UserControl
    {
        public Draggable()
        {
            InitializeComponent();
        }

        private void Draggable_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(WhatIsDragging(), DragDropEffects.Copy);
        }

        private void Draggable_Paint(object sender, PaintEventArgs e)
        {
            Repaint(sender, e);
        }

        public virtual object WhatIsDragging()
        {
            return "Nothing";
        }

        public virtual void Repaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, 0, 0, Width, Height);
            e.Graphics.DrawLine(Pens.Red, Width, 0, 0, Height);
        }
    }
}
