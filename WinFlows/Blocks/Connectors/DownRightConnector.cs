namespace WinFlows.Blocks.Connectors
{
    public partial class DownRightConnector : DownFirstSingleBendedConnector
    {
        public override int SouthOffset => 0;

        public DownRightConnector()
        {
            InitializeComponent();
        }

        public override void ComputeLocation()
        {
            Left =
                Globals.BlockSize.Width / 2
                + Globals.BlockSize.Width * Column;
            Top = Globals.BlockSize.Height * (From.Row + 1);
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2, 0,
                Globals.BlockSize.Width / 2, Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius + 1);
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2 + Globals.ConnectorBendRadius - 1, Height - Globals.BlockSize.Height / 2,
                Width, Height - Globals.BlockSize.Height / 2
                );

            DrawBendInTheMiddle(g, SidesFlags.West | SidesFlags.South);

            if (South is not Connector)
            {
                var arrowHead = new Point[]
                    {
                            new Point(Width - Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Height / 2 - Globals.BlockSize.Width / 18),
                            new Point(Width, Height - Globals.BlockSize.Height / 2),
                            new Point(Width - Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Height / 2 + Globals.BlockSize.Width / 18)
                    };

                g.FillPolygon(Brush, arrowHead);
                g.DrawPolygon(Pen, arrowHead);
            }
        }
    }
}
