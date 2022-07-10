namespace WinFlows.Blocks.Connectors
{
    public partial class DownLeftConnector : DownFirstSingleBendedConnector
    {
        public override int SouthOffset => 0;

        public DownLeftConnector()
        {
            InitializeComponent();
        }

        public override void ComputeLocation()
        {
            Left =
                Globals.BlockSize.Width / 2
                + Globals.BlockSize.Width * (South.Column + 1);
            Top = Globals.BlockSize.Height * (From.Row + 1);
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Width - Globals.BlockSize.Width / 2, 0,
                Width - Globals.BlockSize.Width / 2, Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius + 1);
            g.DrawLine(Pen,
                Width - Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius + 1, Height - Globals.BlockSize.Height / 2,
                0, Height - Globals.BlockSize.Height / 2
                );

            DrawBendInTheMiddle(g, SidesFlags.East | SidesFlags.South);

            if (South is not Connector)
            {
                var arrowHead = new Point[]
                    {
                            new Point(Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Height / 2 - Globals.BlockSize.Width / 18),
                            new Point(0, Height - Globals.BlockSize.Height / 2),
                            new Point(Globals.BlockSize.Width / 9, Height - Globals.BlockSize.Height / 2 + Globals.BlockSize.Width / 18)
                    };

                g.FillPolygon(Brush, arrowHead);
                g.DrawPolygon(Pen, arrowHead);
            }
        }
    }
}
