using WinFlows.Helpers;

namespace WinFlows.Blocks
{
    public partial class EndBlock : Block
    {
        public EndBlock()
        {
            InitializeComponent();
        }

        public override Block? Execute()
        {
            MainForm.ConsoleWrite("---------- PROGRAM ENDED ----------");
            return base.Execute();
        }

        public override void Repaint(Graphics g)
        {
            var pen = new Pen(ColorScheme.StopStroke, Globals.BlockStroke);
            var brush = new SolidBrush(ColorScheme.StopFill);

            ShapeHelper.DrawPill(g, Globals.BlockRect, pen, brush);

            StringHelper.DrawStringInsideBox(g, Globals.BlockRectTwoThirds, ColorScheme.StopText, "STOP");
        }
    }
}
