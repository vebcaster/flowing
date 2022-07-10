using WinFlows.Helpers;

namespace WinFlows.Draggables.Operators
{
    public partial class DragNumberOperator : Draggable
    {
        public string NumberOperation { get; set; }
        public string DisplayText { get; set; }

        public DragNumberOperator()
        {
            NumberOperation = string.Empty;
            DisplayText = string.Empty;

            InitializeComponent();
        }

        public override object WhatIsDragging()
        {
            if (string.IsNullOrEmpty(NumberOperation))
            {
                var err = $"Set NumberOperation for all DragNumberOperators.";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }
            return $"OPERATOR:NUMBER:{NumberOperation}";
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
                DisplayText
                );
        }
    }
}
