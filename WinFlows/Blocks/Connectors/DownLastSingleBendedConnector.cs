namespace WinFlows.Blocks.Connectors
{
    public partial class DownLastSingleBendedConnector : SingleBendedConnector
    {
        public DownLastSingleBendedConnector()
        {
            InitializeComponent();
        }

        public override void Insert(Block block1, Block block2)
        {
            var newConn = new DownConnector
            {
                From = block2,
                South = South
            };
            block2.South = newConn;
            South = block1;
        }
    }
}
