namespace WinFlows.Blocks.Connectors
{
    public partial class LeftDownRightConnector : DoubleBendedConnector
    {
        public LeftDownRightConnector()
        {
            InitializeComponent();
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2, Globals.BlockSize.Height / 2 + Globals.ConnectorBendRadius - 1,
                Globals.BlockSize.Width / 2, Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius + 1);
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2 + Globals.ConnectorBendRadius - 1, Globals.BlockSize.Height / 2,
                Width, Globals.BlockSize.Height / 2);
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2 + Globals.ConnectorBendRadius - 1, Height - Globals.BlockSize.Height / 2,
                Width, Height - Globals.BlockSize.Height / 2);

            DrawBendInTheMiddle(g, SidesFlags.West | SidesFlags.South);
            DrawBendInTheMiddle(g, SidesFlags.West | SidesFlags.North);

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

        public override void Insert(Block block1, Block block2)
        {
            var originalSource = From;
            var finalDestination = South;

            FlowChart.Instance.Controls.Remove(this);

            var leftDown = new LeftDownConnector
            {
                From = originalSource,
                South = block1
            };
            originalSource.West = leftDown;

            var downRight = new DownRightConnector
            {
                From = block2,
                South = finalDestination
            };
            block2.South = downRight;
        }
    }
}
