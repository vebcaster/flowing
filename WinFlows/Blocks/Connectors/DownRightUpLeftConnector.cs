namespace WinFlows.Blocks.Connectors
{
    public partial class DownRightUpLeftConnector : Connector
    {
        public DownRightUpLeftConnector()
        {
            InitializeComponent();
        }

        public override void ComputeSize()
        {
            if (From is not WhileBlock)
                Size = new Size(
                    Globals.BlockSize.Width * (FlowChart.Instance.CodeCols[South.South.East.CodeColumnName].FullWingspan),
                    Globals.BlockSize.Height * (From.Row - South.Row + 2)
                    );
            else
                Size = new Size(
                    Globals.BlockSize.Width * (FlowChart.Instance.CodeCols[South.South.East.CodeColumnName].FullWingspan),
                    Globals.BlockSize.Height * (((WhileBlock)From).LoopFlowConnector.EastInput.Row - South.Row + 2)
                    );
        }

        public override void ComputeLocation()
        {
            Left =
                Globals.BlockSize.Width / 2
                + Globals.BlockSize.Width * (South.Column + 1);
            Top = Globals.BlockSize.Height * South.Row;
        }

        public override void Insert(Block block1, Block block2)
        {
            var downConn = new DownConnector
            {
                From = From,
                South = block1
            };
            From.South = downConn;

            From = block2;
            block2.South = this;
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Globals.BlockSize.Width * (From.Column - South.Column - 1) + Globals.BlockSize.Width / 2,
                Globals.BlockSize.Height * (From.Row - South.Row + 1),
                Globals.BlockSize.Width * (From.Column - South.Column - 1) + Globals.BlockSize.Width / 2,
                Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius + 1);
            g.DrawLine(Pen,
                Globals.BlockSize.Width * (From.Column - South.Column - 1) + Globals.BlockSize.Width / 2 + Globals.ConnectorBendRadius - 1,
                Height - Globals.BlockSize.Height / 2,
                Width - Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius + 1,
                Height - Globals.BlockSize.Height / 2);
            g.DrawLine(Pen,
                Width - Globals.BlockSize.Width / 2,
                Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius + 1,
                Width - Globals.BlockSize.Width / 2,
                Globals.BlockSize.Height / 2 + Globals.ConnectorBendRadius - 1);
            g.DrawLine(Pen,
                Width - Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius + 1, Globals.BlockSize.Height / 2,
                0, Globals.BlockSize.Height / 2);

            DrawBendInTheMiddle(g, SidesFlags.South | SidesFlags.East);
            DrawBendInTheMiddle(g, SidesFlags.East | SidesFlags.North);

            var size = new Size(Globals.ConnectorBendRadius * 2, Globals.ConnectorBendRadius * 2);

            var x = Globals.BlockSize.Width * (From.Column - South.Column - 1) + Globals.BlockSize.Width / 2;
            var y = Height - Globals.BlockSize.Height / 2 - Globals.ConnectorBendRadius * 2;

            var rect = new Rectangle(x, y, size.Width, size.Height);

            g.DrawArc(Pen, rect, 90, 90);

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
