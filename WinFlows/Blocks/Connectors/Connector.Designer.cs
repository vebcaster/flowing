﻿namespace WinFlows.Blocks.Connectors
{
    partial class Connector
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
            // Connector
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Connector";
            this.Size = new System.Drawing.Size(171, 200);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Connector_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Connector_DragEnter);
            this.DragLeave += new System.EventHandler(this.Connector_DragLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
