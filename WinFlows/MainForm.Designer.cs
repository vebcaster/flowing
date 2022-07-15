namespace WinFlows
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowChart = new WinFlows.FlowChart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dragAssignBlock1 = new WinFlows.Draggables.Blocks.DragAssignBlock();
            this.dragWhileBlock1 = new WinFlows.Draggables.Blocks.DragWhileBlock();
            this.dragIfBlock1 = new WinFlows.Draggables.Blocks.DragIfBlock();
            this.dragOutBlock1 = new WinFlows.Draggables.Blocks.DragOutBlock();
            this.btnExecute = new System.Windows.Forms.Button();
            this.dragInBlock1 = new WinFlows.Draggables.Blocks.DragInBlock();
            this.btnVariables = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowChart
            // 
            this.flowChart.AutoScroll = true;
            this.flowChart.AutoSize = true;
            this.flowChart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowChart.BackColor = System.Drawing.Color.White;
            this.flowChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowChart.Location = new System.Drawing.Point(0, 0);
            this.flowChart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.flowChart.Name = "flowChart";
            this.flowChart.Size = new System.Drawing.Size(635, 465);
            this.flowChart.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowChart);
            this.splitContainer1.Size = new System.Drawing.Size(635, 648);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer2.Panel1.Controls.Add(this.btnLoad);
            this.splitContainer2.Panel1.Controls.Add(this.btnSave);
            this.splitContainer2.Panel1.Controls.Add(this.dragAssignBlock1);
            this.splitContainer2.Panel1.Controls.Add(this.dragWhileBlock1);
            this.splitContainer2.Panel1.Controls.Add(this.dragIfBlock1);
            this.splitContainer2.Panel1.Controls.Add(this.dragOutBlock1);
            this.splitContainer2.Panel1.Controls.Add(this.btnExecute);
            this.splitContainer2.Panel1.Controls.Add(this.dragInBlock1);
            this.splitContainer2.Panel1.Controls.Add(this.btnVariables);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Silver;
            this.splitContainer2.Panel2.Controls.Add(this.console);
            this.splitContainer2.Size = new System.Drawing.Size(635, 178);
            this.splitContainer2.SplitterDistance = 267;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(175, 16);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(32, 31);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "L";
            this.toolTip.SetToolTip(this.btnLoad, "Run program / Next step");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(119, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "S";
            this.toolTip.SetToolTip(this.btnSave, "Run program / Next step");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dragAssignBlock1
            // 
            this.dragAssignBlock1.BackColor = System.Drawing.Color.White;
            this.dragAssignBlock1.Location = new System.Drawing.Point(175, 55);
            this.dragAssignBlock1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragAssignBlock1.Name = "dragAssignBlock1";
            this.dragAssignBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragAssignBlock1.TabIndex = 6;
            // 
            // dragWhileBlock1
            // 
            this.dragWhileBlock1.BackColor = System.Drawing.Color.White;
            this.dragWhileBlock1.Location = new System.Drawing.Point(98, 105);
            this.dragWhileBlock1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragWhileBlock1.Name = "dragWhileBlock1";
            this.dragWhileBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragWhileBlock1.TabIndex = 5;
            // 
            // dragIfBlock1
            // 
            this.dragIfBlock1.BackColor = System.Drawing.Color.White;
            this.dragIfBlock1.Location = new System.Drawing.Point(12, 105);
            this.dragIfBlock1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dragIfBlock1.Name = "dragIfBlock1";
            this.dragIfBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragIfBlock1.TabIndex = 4;
            // 
            // dragOutBlock1
            // 
            this.dragOutBlock1.BackColor = System.Drawing.Color.White;
            this.dragOutBlock1.Location = new System.Drawing.Point(98, 55);
            this.dragOutBlock1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dragOutBlock1.Name = "dragOutBlock1";
            this.dragOutBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragOutBlock1.TabIndex = 3;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(66, 16);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(32, 31);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "R";
            this.toolTip.SetToolTip(this.btnExecute, "Run program / Next step");
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // dragInBlock1
            // 
            this.dragInBlock1.BackColor = System.Drawing.Color.White;
            this.dragInBlock1.Location = new System.Drawing.Point(16, 55);
            this.dragInBlock1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dragInBlock1.Name = "dragInBlock1";
            this.dragInBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragInBlock1.TabIndex = 1;
            // 
            // btnVariables
            // 
            this.btnVariables.Location = new System.Drawing.Point(14, 16);
            this.btnVariables.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVariables.Name = "btnVariables";
            this.btnVariables.Size = new System.Drawing.Size(32, 31);
            this.btnVariables.TabIndex = 0;
            this.btnVariables.Text = "V";
            this.toolTip.SetToolTip(this.btnVariables, "Variables");
            this.btnVariables.UseVisualStyleBackColor = true;
            this.btnVariables.Click += new System.EventHandler(this.btnVariables_Click);
            // 
            // console
            // 
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(363, 178);
            this.console.TabIndex = 0;
            this.console.Text = "CONSOLE";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 648);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "WinFlows";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowChart flowChart;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button btnVariables;
        private Draggables.Blocks.DragInBlock dragInBlock1;
        private Button btnExecute;
        private ToolTip toolTip;
        private Draggables.Blocks.DragOutBlock dragOutBlock1;
        private TextBox console;
        private Draggables.Blocks.DragIfBlock dragIfBlock1;
        private Draggables.Blocks.DragWhileBlock dragWhileBlock1;
        private Draggables.Blocks.DragAssignBlock dragAssignBlock1;
        private Button btnLoad;
        private Button btnSave;
    }
}