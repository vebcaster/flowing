using WinFlows.Blocks.Connectors;

namespace WinFlows.Blocks
{
    public partial class Block : UserControl
    {
        public Block()
        {
            InitializeComponent();

            Size = new Size(Globals.BlockSize.Width, Globals.BlockSize.Height);

            FlowChart.Instance.Controls.Add(this);
        }

        // Position on the chart table
        public int Row { get; set; }
        public int Column { get; set; }
        public string CodeColumnName { get; set; } = string.Empty;
        public virtual int SouthOffset => 1;

        // Neighbouring blocks
        public Block? South { get; set; }
        public Block? West { get; set; }
        public Block? East { get; set; }

        // Size and position
        public virtual void ComputeSize()
        {
            Size = new Size(Globals.BlockSize.Width, Globals.BlockSize.Height);
        }

        public virtual void ComputeLocation()
        {
            Left =
                Globals.BlockSize.Width / 2
                + Globals.BlockSize.Width * Column;
            Top = Globals.BlockSize.Height * Row;
        }

        // Virtual methods
        public virtual void Repaint(Graphics g)
        {
            g.DrawLine(Pens.Red, 0, 0, Width, Height);
            g.DrawLine(Pens.Red, Width, 0, 0, Height);
        }

        public virtual void DoubleClicked()
        {
        }

        public virtual Block? Execute()
        {
            return South;
        }

        // Handlers
        private void Block_DoubleClick(object sender, EventArgs e)
        {
            DoubleClicked();
        }

        private void Block_Paint(object sender, PaintEventArgs e)
        {
            Repaint(e.Graphics);

            PaintDebugInfo(e);
        }

        // Debug helpers
        protected void PaintDebugInfo(PaintEventArgs e)
        {
            if (!Globals.IsDebugEnabled)
                return;

            e.Graphics.DrawString(
                $"r:{Row} c:{Column} w:{Width} h:{Height}",
                new Font("Verdana", 9), Brushes.Red, 0, 0);
        }
    }
}
