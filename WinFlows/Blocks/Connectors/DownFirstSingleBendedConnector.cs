namespace WinFlows.Blocks.Connectors
{
    public partial class DownFirstSingleBendedConnector : SingleBendedConnector
    {
        public DownFirstSingleBendedConnector()
        {
            InitializeComponent();
        }

        public override void Insert(Block block1, Block block2)
        {
            var from = From;
            
            var downConn = new DownConnector
            {
                From = from,
                South = block1
            };
            
            from.South = downConn;
            From = block2;
            block2.South = this;
        }
    }
}
