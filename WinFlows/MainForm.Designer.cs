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
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
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
            this.flowChart.MinimumSize = new System.Drawing.Size(100, 100);
            this.flowChart.Name = "flowChart";
            this.flowChart.Size = new System.Drawing.Size(819, 463);
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
            this.splitContainer1.Size = new System.Drawing.Size(819, 715);
            this.splitContainer1.SplitterDistance = 247;
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
            this.splitContainer2.Panel1.Controls.Add(this.btnRedo);
            this.splitContainer2.Panel1.Controls.Add(this.btnUndo);
            this.splitContainer2.Panel1.Controls.Add(this.btnStop);
            this.splitContainer2.Panel1.Controls.Add(this.speedBar);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
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
            this.splitContainer2.Size = new System.Drawing.Size(819, 247);
            this.splitContainer2.SplitterDistance = 344;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.Location = new System.Drawing.Point(63, 41);
            this.btnRedo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(32, 31);
            this.btnRedo.TabIndex = 13;
            this.btnRedo.Text = "R";
            this.toolTip.SetToolTip(this.btnRedo, "Redo");
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(14, 41);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(32, 31);
            this.btnUndo.TabIndex = 12;
            this.btnUndo.Text = "U";
            this.toolTip.SetToolTip(this.btnUndo, "Undo");
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(112, 7);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(32, 31);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "S";
            this.toolTip.SetToolTip(this.btnStop, "Stop program");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(86, 188);
            this.speedBar.Maximum = 5;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(146, 56);
            this.speedBar.TabIndex = 10;
            this.speedBar.Value = 3;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Speed:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(210, 7);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(32, 31);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "L";
            this.toolTip.SetToolTip(this.btnLoad, "Load program");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(161, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "S";
            this.toolTip.SetToolTip(this.btnSave, "Save program");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dragAssignBlock1
            // 
            this.dragAssignBlock1.BackColor = System.Drawing.Color.White;
            this.dragAssignBlock1.Location = new System.Drawing.Point(175, 77);
            this.dragAssignBlock1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragAssignBlock1.Name = "dragAssignBlock1";
            this.dragAssignBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragAssignBlock1.TabIndex = 6;
            // 
            // dragWhileBlock1
            // 
            this.dragWhileBlock1.BackColor = System.Drawing.Color.White;
            this.dragWhileBlock1.Location = new System.Drawing.Point(98, 127);
            this.dragWhileBlock1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragWhileBlock1.Name = "dragWhileBlock1";
            this.dragWhileBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragWhileBlock1.TabIndex = 5;
            // 
            // dragIfBlock1
            // 
            this.dragIfBlock1.BackColor = System.Drawing.Color.White;
            this.dragIfBlock1.Location = new System.Drawing.Point(12, 127);
            this.dragIfBlock1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dragIfBlock1.Name = "dragIfBlock1";
            this.dragIfBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragIfBlock1.TabIndex = 4;
            // 
            // dragOutBlock1
            // 
            this.dragOutBlock1.BackColor = System.Drawing.Color.White;
            this.dragOutBlock1.Location = new System.Drawing.Point(98, 77);
            this.dragOutBlock1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dragOutBlock1.Name = "dragOutBlock1";
            this.dragOutBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragOutBlock1.TabIndex = 3;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(63, 7);
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
            this.dragInBlock1.Location = new System.Drawing.Point(16, 77);
            this.dragInBlock1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dragInBlock1.Name = "dragInBlock1";
            this.dragInBlock1.Size = new System.Drawing.Size(57, 40);
            this.dragInBlock1.TabIndex = 1;
            // 
            // btnVariables
            // 
            this.btnVariables.Location = new System.Drawing.Point(14, 7);
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
            this.console.Size = new System.Drawing.Size(470, 247);
            this.console.TabIndex = 0;
            this.console.Text = "CONSOLE";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 715);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "WinFlows";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
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
        private Label label1;
        private TrackBar speedBar;
        private Button btnStop;
        private Button btnRedo;
        private Button btnUndo;
    }
}