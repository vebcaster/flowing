using WinFlows.Helpers;

namespace WinFlows.Draggables.Operators
{
    public partial class DragLogicalOperator : Draggable
    {
        public string LogicalOperation { get; set; }
        public string DisplayText { get; set; }

        public DragLogicalOperator()
        {
            LogicalOperation = string.Empty;
            DisplayText = string.Empty;

            InitializeComponent();
        }

        public override object WhatIsDragging()
        {
            if (string.IsNullOrEmpty(LogicalOperation))
            {
                var err = $"Set LogicalOperation for all DragLogicalOperators.";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }
            return $"OPERATOR:LOGICAL:{LogicalOperation}";
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
                DisplayText
                );
        }
    }
}
