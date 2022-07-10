namespace WinFlows.Blocks.Connectors
{
    public partial class DownConnector : Connector
    {
        public DownConnector()
        {
            InitializeComponent();
        }

        public override void ComputeSize()
        {
            Size = new Size(
                    Globals.BlockSize.Width,
                    Globals.BlockSize.Height
                    * (South!.Row - From.Row - 1)
                );
        }

        public override void ComputeLocation()
        {
            Left =
                Globals.BlockSize.Width / 2
                + Globals.BlockSize.Width * Column;
            Top = Globals.BlockSize.Height * (From.Row + 1);
        }

        public override void Insert(Block block1, Block block2)
        {
            var finalDestination = South;
            var newDownConnector = new DownConnector()
            {
                From = block2,
                South = finalDestination
            };

            South = block1;
            block2.South = newDownConnector;
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                Globals.BlockSize.Width / 2, 0,
                Globals.BlockSize.Width / 2, Height);

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
