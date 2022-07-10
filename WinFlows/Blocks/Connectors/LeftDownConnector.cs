namespace WinFlows.Blocks.Connectors
{
    public partial class LeftDownConnector : DownLastSingleBendedConnector
    {
        public LeftDownConnector()
        {
            InitializeComponent();
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2, Globals.BlockSize.Height / 2 + Globals.ConnectorBendRadius - 1,
                Globals.BlockSize.Width / 2, Height);
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2 + Globals.ConnectorBendRadius - 1, Globals.BlockSize.Height / 2,
                Width, Globals.BlockSize.Height / 2);

            DrawBendInTheMiddle(g, SidesFlags.North | SidesFlags.West);

            if (South is not Connector)
            {
                var arrowHead = new Point[]
                    {
                new Point(4 * Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Width / 9),
                new Point(Globals.BlockSize.Width / 2, Height),
                new Point(5 * Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Width / 9)
                    };

                g.FillPolygon(Brush, arrowHead);
                g.DrawPolygon(Pen, arrowHead);
            }
        }
    }
}
