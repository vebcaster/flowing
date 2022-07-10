using WinFlows.Helpers;

namespace WinFlows.Draggables.Variables
{
    public partial class DragListOfNumbersVariable : Draggable
    {
        private string _variableName;

        public DragListOfNumbersVariable(string variableName)
        {
            InitializeComponent();

            _variableName = variableName;
        }

        public override object WhatIsDragging()
        {
            return $"VARIABLE:LIST_OF_NUMBERS:{_variableName}";
        }

        public override void Repaint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(ColorScheme.NumberFill);
            var pen = new Pen(ColorScheme.NumberStroke);

            ShapeHelper.DrawList(e.Graphics, ClientRectangle, pen, brush);

            StringHelper.DrawStringInsideBox(
                e.Graphics,
                ClientRectangle,
                ColorScheme.NumberText,
                _variableName
                );
        }
    }
}
