using System.Text;

namespace WinFlows.Blocks.Connectors
{
    public partial class SplitFlowConnector : Connector
    {
        public Block MergeParent { get; set; }

        public SplitFlowConnector()
        {
            InitializeComponent();
            MergeParent = this;
        }

        public override void Repaint(Graphics g)
        {
            g.DrawLine(Pen,
                0, Height / 2,
                Globals.BlockSize.Width / 2 - Globals.ConnectorBendRadius + 1, Height / 2);
            g.DrawLine(Pen,
                Width, Height / 2,
                Globals.BlockSize.Width / 2 + Globals.ConnectorBendRadius - 1, Height / 2);
            g.DrawLine(Pen,
                Width / 2, Height / 2 + Globals.ConnectorBendRadius - 1,
                Width / 2, Height);

            DrawBendInTheMiddle(g, SidesFlags.North | SidesFlags.West);
            DrawBendInTheMiddle(g, SidesFlags.North | SidesFlags.East);
        }

        public override string Save()
        {
            var sb = new StringBuilder(base.Save());

            sb.AppendLine($"MERGE_PARENT:{MergeParent.Id}");

            return sb.ToString();
        }
    }
}
