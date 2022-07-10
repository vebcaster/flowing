using WinFlows.Helpers;

namespace WinFlows.Draggables.Blocks
{
    public partial class DragOutBlock : Draggable
    {
        public DragOutBlock()
        {
            InitializeComponent();
        }

        public override object WhatIsDragging()
        {
            return "BLOCK:OUTPUT";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var points = ShapeHelper.GetParallelogramPoints(Width, Height);
            e.Graphics.DrawPolygon(Pens.Navy, points);

            StringHelper.DrawStringInsideBox(
                e.Graphics,
                new Rectangle(Width / 5, 0, Width * 4 / 5, Height),
                Color.Navy,
                "\u2190 OUT"
                );
        }
    }
}
