namespace WinFlows.Blocks
{
    partial class Block
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.blockContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.blockContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // blockContextMenu
            // 
            this.blockContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.blockContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteBlock});
            this.blockContextMenu.Name = "contextMenu";
            this.blockContextMenu.Size = new System.Drawing.Size(211, 56);
            // 
            // menuDeleteBlock
            // 
            this.menuDeleteBlock.Name = "menuDeleteBlock";
            this.menuDeleteBlock.Size = new System.Drawing.Size(210, 24);
            this.menuDeleteBlock.Text = "Delete block";
            this.menuDeleteBlock.Click += new System.EventHandler(this.menuDeleteBlock_Click);
            // 
            // Block
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.blockContextMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Block";
            this.Size = new System.Drawing.Size(171, 200);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Block_Paint);
            this.DoubleClick += new System.EventHandler(this.Block_DoubleClick);
            this.blockContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip blockContextMenu;
        private ToolStripMenuItem menuDeleteBlock;
    }
}
