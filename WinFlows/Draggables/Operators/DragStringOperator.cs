using WinFlows.Helpers;

namespace WinFlows.Draggables.Operators
{
    public partial class DragStringOperator : Draggable
    {
        public string StringOperation { get; set; }
        public string DisplayText { get; set; }

        public DragStringOperator()
        {
            StringOperation = string.Empty;
            DisplayText = string.Empty;

            InitializeComponent();
        }

        public override object WhatIsDragging()
        {
            if (string.IsNullOrEmpty(StringOperation))
            {
                var err = $"Set StringOperation for all DragStringOperators.";
                MessageBox.Show(err);
                throw new InvalidDataException(err);
            }
            return $"OPERATOR:STRING:{StringOperation}";
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
                DisplayText
                );
        }
    }
}
