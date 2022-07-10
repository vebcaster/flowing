namespace WinFlows.Blocks.Connectors
{
    public partial class RightUpLeftConnector : Connector
    {
        public RightUpLeftConnector()
        {
            InitializeComponent();
        }

        public override void ComputeSize()
        {
            Size = new Size(Globals.BlockSize.Width, Globals.BlockSize.Height * 2); // Always spans exactly 2 rows
        }

        public override void ComputeLocation()
        {
            Left =
                Globals.BlockSize.Width / 2
                + Globals.BlockSize.Width * Column;
            Top = Globals.BlockSize.Height * South.Row;
        }

        public override void Insert(Block block1, Block block2)
        {
            var rightDown = new RightDownConnector
            {
                From = From,
                South = block1
            };
            From.East = rightDown;

            var downRightUpLeft = new DownRightUpLeftConnector
            {
                From = block2,
                South = South
            };
            block2.South = downRightUpLeft;
            ((LoopFlowConnector)South).EastInput = downRightUpLeft;

            FlowChart.Instance.Controls.Remove(this);
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2, Globals.BlockSize.Height / 2 + Globals.ConnectorBendRadius - 1,
                Globals.BlockSize.Width / 2, Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius + 1);
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius + 1, Globals.BlockSize.Height / 2,
                0, Globals.BlockSize.Height / 2);
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius + 1, Height - Globals.BlockSize.Height / 2,
                0, Height - Globals.BlockSize.Height / 2);

            DrawBendInTheMiddle(g, SidesFlags.South | SidesFlags.East);
            DrawBendInTheMiddle(g, SidesFlags.North | SidesFlags.East);

            if (South is not Connector)
            {
                var arrowHead = new Point[] {
                new Point(Globals.BlockSize.Width / 9, Globals.BlockSize.Height / 2 - Globals.BlockSize.Width / 18),
                new Point(0, Globals.BlockSize.Height / 2),
                new Point(Globals.BlockSize.Width / 9, Globals.BlockSize.Height / 2 + Globals.BlockSize.Width / 18)
                };

                g.FillPolygon(Brush, arrowHead);
                g.DrawPolygon(Pen, arrowHead);
            }
        }
    }
}
