namespace WinFlows.Blocks.Connectors
{
    public partial class DoubleBendedConnector : Connector
    {
        public DoubleBendedConnector()
        {
            InitializeComponent();
        }

        public override void ComputeSize()
        {
            Size = new Size(
                Globals.BlockSize.Width,
                Globals.BlockSize.Height
                * (South!.Row - Row + 1)
                );
        }
    }
}
