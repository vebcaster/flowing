using WinFlows.Helpers;

namespace WinFlows.Draggables.Variables
{
    public partial class DragListOfStringsVariable : Draggable
    {
        private string _variableName;
        
        public DragListOfStringsVariable(string variableName)
        {
            InitializeComponent();

            _variableName = variableName;
        }

        public override object WhatIsDragging()
        {
            return $"VARIABLE:LIST_OF_STRINGS:{_variableName}";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(ColorScheme.StringFill);
            var pen = new Pen(ColorScheme.StringStroke);

            ShapeHelper.DrawList(e.Graphics, ClientRectangle, pen, brush);

            StringHelper.DrawStringInsideBox(
                e.Graphics,
                ClientRectangle,
                ColorScheme.StringText,
                _variableName
                );
        }
    }
}
