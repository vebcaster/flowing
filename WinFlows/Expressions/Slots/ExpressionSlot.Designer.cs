namespace WinFlows.Expressions.Slots
{
    partial class ExpressionSlot
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
            this.SuspendLayout();
            // 
            // ExpressionSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ExpressionSlot";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExpressionSlot_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExpressionSlot_DragEnter);
            this.DragLeave += new System.EventHandler(this.ExpressionSlot_DragLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ExpressionSlot_Paint);
            this.DoubleClick += new System.EventHandler(this.ExpressionSlot_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
