using WinFlows.Helpers;

namespace WinFlows.Draggables.Variables
{
    public partial class DragStringVariable : Draggable
    {
        private string _variableName;

        public DragStringVariable(string variableName)
        {
            InitializeComponent();

            _variableName = variableName;
        }

        public override object WhatIsDragging()
        {
            return $"VARIABLE:STRING:{_variableName}";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(ColorScheme.StringFill);
            var pen = new Pen(ColorScheme.StringStroke);

            ShapeHelper.DrawPill(e.Graphics, ClientRectangle, pen, brush);

            StringHelper.DrawStringInsideBox(
                e.Graphics,
                ClientRectangle,
                ColorScheme.StringText,
                _variableName
                );
        }
    }
}
