using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class StartBlock : Block
    {
        public StartBlock()
        {
            InitializeComponent();

            ContextMenuStrip = null;
        }

        public override Block? Execute()
        {
            MainForm.ConsoleWrite("---------- PROGRAM STARTED ----------");
            return base.Execute();
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.StartStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.StartFill);

            ShapeHelper.DrawPill(g, Globals.BlockRect, pen, brush);

            StringHelper.DrawStringInsideBox(g, Globals.BlockRectTwoThirds, ColorScheme.StartText, "START");
        }
    }
}
