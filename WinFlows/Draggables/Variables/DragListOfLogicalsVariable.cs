using WinFlows.Helpers;

namespace WinFlows.Draggables.Variables
{
    public partial class DragListOfLogicalsVariable : Draggable
    {
        private string _variableName;

        public DragListOfLogicalsVariable(string variableName)
        {
            InitializeComponent();

            _variableName = variableName;
        }

        public override object WhatIsDragging()
        {
            return $"VARIABLE:LIST_OF_LOGICALS:{_variableName}";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(ColorScheme.LogicalFill);
            var pen = new Pen(ColorScheme.LogicalStroke);

            ShapeHelper.DrawList(e.Graphics, ClientRectangle, pen, brush);

            StringHelper.DrawStringInsideBox(
                e.Graphics,
                ClientRectangle,
                ColorScheme.LogicalText,
                _variableName
                );
        }
    }
}
