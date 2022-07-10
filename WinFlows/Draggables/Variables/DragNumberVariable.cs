using WinFlows.Helpers;

namespace WinFlows.Draggables.Variables
{
    public partial class DragNumberVariable : Draggable
    {
        private string _variableName;

        public DragNumberVariable(string variableName)
        {
            InitializeComponent();

            _variableName = variableName;
        }

        public override object WhatIsDragging()
        {
            return $"VARIABLE:NUMBER:{_variableName}";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(ColorScheme.NumberFill);
            var pen = new Pen(ColorScheme.NumberStroke);

            var points = ShapeHelper.GetHexagonPoints(Width, Height);

            e.Graphics.FillPolygon(brush, points);
            e.Graphics.DrawPolygon(pen, points);

            StringHelper.DrawStringInsideBox(
                e.Graphics,
                ClientRectangle,
                ColorScheme.NumberText,
                _variableName
                );
        }
    }
}
