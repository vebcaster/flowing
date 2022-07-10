namespace WinFlows.Blocks.Connectors
{
    public partial class LoopFlowConnector : Connector
    {
        public Connector EastInput { get; set; }

        public LoopFlowConnector(Connector eastInput)
        {
            InitializeComponent();

            EastInput = eastInput;
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen, Globals.BlockSize.Width / 2, 0, Globals.BlockSize.Width / 2, Height);
            g.DrawLine(Pen,
                Width / 2 + Globals.ConnectorBendRadius - 1, Height / 2,
                Width, Height / 2);

            DrawBendInTheMiddle(g, SidesFlags.North | SidesFlags.West);

            if (South is not Connector)
            {
                var arrowHead = new Point[]
                    {
                            new Point(4 * Globals.BlockSize.Width / 9, Globals.BlockSize.Height - Globals.BlockSize.Width / 9),
                            new Point(Globals.BlockSize.Width / 2, Globals.BlockSize.Height),
                            new Point(5 * Globals.BlockSize.Width / 9, Globals.BlockSize.Height - Globals.BlockSize.Width / 9)
                    };

                g.FillPolygon(Brush, arrowHead);
                g.DrawPolygon(Pen, arrowHead);
            }
        }
    }
}
