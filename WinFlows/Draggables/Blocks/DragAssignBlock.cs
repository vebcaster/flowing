using WinFlows.Helpers;

namespace WinFlows.Draggables.Blocks
{
    public partial class DragAssignBlock : Draggable
    {
        public DragAssignBlock()
        {
            InitializeComponent();
        }

        public override object WhatIsDragging()
        {
            return "BLOCK:ASSIGN";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Navy, Globals.BlockRect);
            StringHelper.DrawStringInsideBox(
                e.Graphics,
                new Rectangle(0, 0, Width, Height),
                Color.Navy,
                "ASSIGN"
                );
        }
    }
}
