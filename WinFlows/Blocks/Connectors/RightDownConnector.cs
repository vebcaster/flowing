namespace WinFlows.Blocks.Connectors
{
    public partial class RightDownConnector : DownLastSingleBendedConnector
    {
        public RightDownConnector()
        {
            InitializeComponent();
        }

        public override void ComputeLocation()
        {
            Left =
                Globals.BlockSize.Width / 2
                + Globals.BlockSize.Width * (From.Column + 1);
            Top = Globals.BlockSize.Height * Row;
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Width - Globals.BlockSize.Width / 2, Globals.BlockSize.Height / 2 + Globals.ConnectorBendRadius - 1,
                Width - Globals.BlockSize.Width / 2, Height); ;
            g.DrawLine(Pen,
                Width - Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius + 1, Globals.BlockSize.Height / 2,
                0, Globals.BlockSize.Height / 2);

            DrawBendInTheMiddle(g, SidesFlags.North | SidesFlags.East);

            if (South is not Connector)
            {
                var arrowHead = new Point[]
                    {
                    new Point(Width - 4 * Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Width / 9),
                    new Point(Width - Globals.BlockSize.Width / 2, Height),
                    new Point(Width - 5 * Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Width / 9)
                    };

                g.FillPolygon(Brush, arrowHead);
                g.DrawPolygon(Pen, arrowHead);
            }
        }
    }
}
