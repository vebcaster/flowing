using WinFlows.Helpers;

namespace WinFlows.Draggables.Variables
{
    public partial class DragLogicalVariable : Draggable
    {
        private string _variableName;

        public DragLogicalVariable(string variableName)
        {
            InitializeComponent();

            _variableName = variableName;
        }

        public override object WhatIsDragging()
        {
            return $"VARIABLE:LOGICAL:{_variableName}";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(ColorScheme.LogicalFill);
            var pen = new Pen(ColorScheme.LogicalStroke);

            var points = ShapeHelper.GetOctagonPoints(Width, Height);

            e.Graphics.FillPolygon(brush, points);
            e.Graphics.DrawPolygon(pen, points);
                
            StringHelper.DrawStringInsideBox(
                e.Graphics,
                ClientRectangle,
                ColorScheme.LogicalText,
                _variableName
                );
        }
    }
}
