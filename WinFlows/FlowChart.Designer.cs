namespace WinFlows
{
    partial class FlowChart
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
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // zoomBar
            // 
            this.zoomBar.Location = new System.Drawing.Point(3, 3);
            this.zoomBar.Maximum = 1000;
            this.zoomBar.Minimum = 5;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(210, 45);
            this.zoomBar.TabIndex = 0;
            this.toolTip1.SetToolTip(this.zoomBar, "Zoom");
            this.zoomBar.Value = 100;
            this.zoomBar.Scroll += new System.EventHandler(this.zoomBar_Scroll);
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(230, 3);
            this.speedBar.Maximum = 5;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(210, 45);
            this.speedBar.TabIndex = 1;
            this.toolTip1.SetToolTip(this.speedBar, "Speed");
            this.speedBar.Value = 2;
            // 
            // FlowChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.zoomBar);
            this.Name = "FlowChart";
            this.Size = new System.Drawing.Size(443, 51);
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrackBar zoomBar;
        private TrackBar speedBar;
        private ToolTip toolTip1;
    }
}
