namespace WinFlows.Blocks.Connectors
{
    public partial class SingleBendedConnector : Connector
    {
        public SingleBendedConnector()
        {
            InitializeComponent();
        }

        public override void ComputeSize()
        {
            Size = new Size(
                Globals.BlockSize.Width * Math.Abs(From.Column - South!.Column),
                Globals.BlockSize.Height * Math.Abs(From.Row - South.Row)
                );
        }
    }
}
