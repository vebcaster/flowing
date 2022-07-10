using WinFlows.Helpers;

namespace WinFlows.Draggables.Blocks
{
    public partial class DragIfBlock : Draggable
    {
        public DragIfBlock()
        {
            InitializeComponent();
        }

        public override object WhatIsDragging()
        {
            return "BLOCK:IF";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var points = ShapeHelper.GetRhombusPoints(Width, Height);
            e.Graphics.DrawPolygon(Pens.Navy, points);

            StringHelper.DrawStringInsideBox(
                e.Graphics,
                new Rectangle(Width / 5, 0, Width * 4 / 5, Height),
                Color.Navy,
                "IF-ELSE"
                );
        }
    }
}
