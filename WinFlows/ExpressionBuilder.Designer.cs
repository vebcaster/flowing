namespace WinFlows
{
    partial class ExpressionBuilder
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.variablesPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dragLogicalOperator1 = new WinFlows.Draggables.Operators.DragLogicalOperator();
            this.dragLogicalOperator2 = new WinFlows.Draggables.Operators.DragLogicalOperator();
            this.dragLogicalOperator3 = new WinFlows.Draggables.Operators.DragLogicalOperator();
            this.dragLogicalOperator4 = new WinFlows.Draggables.Operators.DragLogicalOperator();
            this.dragLogicalOperator5 = new WinFlows.Draggables.Operators.DragLogicalOperator();
            this.dragNumberOperator1 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragNumberOperator2 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragNumberOperator3 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragNumberOperator4 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragNumberOperator5 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragNumberOperator6 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragNumberOperator7 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragNumberOperator8 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragStringOperator1 = new WinFlows.Draggables.Operators.DragStringOperator();
            this.dragLogicalOperator6 = new WinFlows.Draggables.Operators.DragLogicalOperator();
            this.dragNumberOperator9 = new WinFlows.Draggables.Operators.DragNumberOperator();
            this.dragStringOperator2 = new WinFlows.Draggables.Operators.DragStringOperator();
            this.dragLogicalOperator7 = new WinFlows.Draggables.Operators.DragLogicalOperator();
            this.variablesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // variablesPanel
            // 
            this.variablesPanel.AutoScroll = true;
            this.variablesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.variablesPanel.Controls.Add(this.label1);
            this.variablesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.variablesPanel.Location = new System.Drawing.Point(0, 0);
            this.variablesPanel.Name = "variablesPanel";
            this.variablesPanel.Size = new System.Drawing.Size(250, 561);
            this.variablesPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variables";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(268, 12);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(143, 40);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(417, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dragLogicalOperator1
            // 
            this.dragLogicalOperator1.DisplayText = "XOR";
            this.dragLogicalOperator1.Location = new System.Drawing.Point(566, 76);
            this.dragLogicalOperator1.LogicalOperation = "XOR";
            this.dragLogicalOperator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragLogicalOperator1.Name = "dragLogicalOperator1";
            this.dragLogicalOperator1.Size = new System.Drawing.Size(143, 41);
            this.dragLogicalOperator1.TabIndex = 6;
            // 
            // dragLogicalOperator2
            // 
            this.dragLogicalOperator2.DisplayText = "OR";
            this.dragLogicalOperator2.Location = new System.Drawing.Point(417, 76);
            this.dragLogicalOperator2.LogicalOperation = "OR";
            this.dragLogicalOperator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragLogicalOperator2.Name = "dragLogicalOperator2";
            this.dragLogicalOperator2.Size = new System.Drawing.Size(143, 41);
            this.dragLogicalOperator2.TabIndex = 7;
            // 
            // dragLogicalOperator3
            // 
            this.dragLogicalOperator3.DisplayText = "AND";
            this.dragLogicalOperator3.Location = new System.Drawing.Point(268, 76);
            this.dragLogicalOperator3.LogicalOperation = "AND";
            this.dragLogicalOperator3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragLogicalOperator3.Name = "dragLogicalOperator3";
            this.dragLogicalOperator3.Size = new System.Drawing.Size(143, 41);
            this.dragLogicalOperator3.TabIndex = 8;
            // 
            // dragLogicalOperator4
            // 
            this.dragLogicalOperator4.DisplayText = "NOT";
            this.dragLogicalOperator4.Location = new System.Drawing.Point(715, 76);
            this.dragLogicalOperator4.LogicalOperation = "NOT";
            this.dragLogicalOperator4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragLogicalOperator4.Name = "dragLogicalOperator4";
            this.dragLogicalOperator4.Size = new System.Drawing.Size(143, 41);
            this.dragLogicalOperator4.TabIndex = 9;
            // 
            // dragLogicalOperator5
            // 
            this.dragLogicalOperator5.DisplayText = "N == N";
            this.dragLogicalOperator5.Location = new System.Drawing.Point(268, 125);
            this.dragLogicalOperator5.LogicalOperation = "NUMBERS_ARE_EQUAL";
            this.dragLogicalOperator5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragLogicalOperator5.Name = "dragLogicalOperator5";
            this.dragLogicalOperator5.Size = new System.Drawing.Size(143, 41);
            this.dragLogicalOperator5.TabIndex = 10;
            // 
            // dragNumberOperator1
            // 
            this.dragNumberOperator1.DisplayText = "N + N";
            this.dragNumberOperator1.Location = new System.Drawing.Point(268, 174);
            this.dragNumberOperator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator1.Name = "dragNumberOperator1";
            this.dragNumberOperator1.NumberOperation = "PLUS";
            this.dragNumberOperator1.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator1.TabIndex = 11;
            // 
            // dragNumberOperator2
            // 
            this.dragNumberOperator2.DisplayText = "FLOOR";
            this.dragNumberOperator2.Location = new System.Drawing.Point(268, 223);
            this.dragNumberOperator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator2.Name = "dragNumberOperator2";
            this.dragNumberOperator2.NumberOperation = "FLOOR";
            this.dragNumberOperator2.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator2.TabIndex = 12;
            // 
            // dragNumberOperator3
            // 
            this.dragNumberOperator3.DisplayText = "N / N";
            this.dragNumberOperator3.Location = new System.Drawing.Point(715, 174);
            this.dragNumberOperator3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator3.Name = "dragNumberOperator3";
            this.dragNumberOperator3.NumberOperation = "DIVIDE";
            this.dragNumberOperator3.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator3.TabIndex = 13;
            // 
            // dragNumberOperator4
            // 
            this.dragNumberOperator4.DisplayText = "N * N";
            this.dragNumberOperator4.Location = new System.Drawing.Point(566, 174);
            this.dragNumberOperator4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator4.Name = "dragNumberOperator4";
            this.dragNumberOperator4.NumberOperation = "MULTIPLY";
            this.dragNumberOperator4.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator4.TabIndex = 14;
            // 
            // dragNumberOperator5
            // 
            this.dragNumberOperator5.DisplayText = "N - N";
            this.dragNumberOperator5.Location = new System.Drawing.Point(417, 174);
            this.dragNumberOperator5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator5.Name = "dragNumberOperator5";
            this.dragNumberOperator5.NumberOperation = "MINUS";
            this.dragNumberOperator5.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator5.TabIndex = 15;
            // 
            // dragNumberOperator6
            // 
            this.dragNumberOperator6.DisplayText = "N mod N";
            this.dragNumberOperator6.Location = new System.Drawing.Point(864, 174);
            this.dragNumberOperator6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator6.Name = "dragNumberOperator6";
            this.dragNumberOperator6.NumberOperation = "MODULO";
            this.dragNumberOperator6.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator6.TabIndex = 16;
            // 
            // dragNumberOperator7
            // 
            this.dragNumberOperator7.DisplayText = "CEILING";
            this.dragNumberOperator7.Location = new System.Drawing.Point(417, 223);
            this.dragNumberOperator7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator7.Name = "dragNumberOperator7";
            this.dragNumberOperator7.NumberOperation = "CEILING";
            this.dragNumberOperator7.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator7.TabIndex = 17;
            // 
            // dragNumberOperator8
            // 
            this.dragNumberOperator8.DisplayText = "ROUND";
            this.dragNumberOperator8.Location = new System.Drawing.Point(566, 223);
            this.dragNumberOperator8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator8.Name = "dragNumberOperator8";
            this.dragNumberOperator8.NumberOperation = "ROUND";
            this.dragNumberOperator8.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator8.TabIndex = 18;
            // 
            // dragStringOperator1
            // 
            this.dragStringOperator1.DisplayText = "CONCAT";
            this.dragStringOperator1.Location = new System.Drawing.Point(268, 272);
            this.dragStringOperator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragStringOperator1.Name = "dragStringOperator1";
            this.dragStringOperator1.Size = new System.Drawing.Size(143, 41);
            this.dragStringOperator1.StringOperation = "CONCAT";
            this.dragStringOperator1.TabIndex = 19;
            // 
            // dragLogicalOperator6
            // 
            this.dragLogicalOperator6.DisplayText = "S == S";
            this.dragLogicalOperator6.Location = new System.Drawing.Point(417, 125);
            this.dragLogicalOperator6.LogicalOperation = "STRINGS_ARE_EQUAL";
            this.dragLogicalOperator6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragLogicalOperator6.Name = "dragLogicalOperator6";
            this.dragLogicalOperator6.Size = new System.Drawing.Size(143, 41);
            this.dragLogicalOperator6.TabIndex = 20;
            // 
            // dragNumberOperator9
            // 
            this.dragNumberOperator9.DisplayText = "ELEMENT OF LIST";
            this.dragNumberOperator9.Location = new System.Drawing.Point(715, 223);
            this.dragNumberOperator9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragNumberOperator9.Name = "dragNumberOperator9";
            this.dragNumberOperator9.NumberOperation = "NUMBER_ELEMENT_OF_LIST";
            this.dragNumberOperator9.Size = new System.Drawing.Size(143, 41);
            this.dragNumberOperator9.TabIndex = 21;
            // 
            // dragStringOperator2
            // 
            this.dragStringOperator2.DisplayText = "ELEMENT OF LIST";
            this.dragStringOperator2.Location = new System.Drawing.Point(417, 272);
            this.dragStringOperator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragStringOperator2.Name = "dragStringOperator2";
            this.dragStringOperator2.Size = new System.Drawing.Size(143, 41);
            this.dragStringOperator2.StringOperation = "STRING_ELEMENT_OF_LIST";
            this.dragStringOperator2.TabIndex = 22;
            // 
            // dragLogicalOperator7
            // 
            this.dragLogicalOperator7.DisplayText = "ELEMENT OF LIST";
            this.dragLogicalOperator7.Location = new System.Drawing.Point(566, 125);
            this.dragLogicalOperator7.LogicalOperation = "LOGICAL_ELEMENT_OF_LIST";
            this.dragLogicalOperator7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragLogicalOperator7.Name = "dragLogicalOperator7";
            this.dragLogicalOperator7.Size = new System.Drawing.Size(143, 41);
            this.dragLogicalOperator7.TabIndex = 23;
            // 
            // ExpressionBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1019, 561);
            this.Controls.Add(this.dragLogicalOperator7);
            this.Controls.Add(this.dragStringOperator2);
            this.Controls.Add(this.dragNumberOperator9);
            this.Controls.Add(this.dragLogicalOperator6);
            this.Controls.Add(this.dragStringOperator1);
            this.Controls.Add(this.dragNumberOperator8);
            this.Controls.Add(this.dragNumberOperator7);
            this.Controls.Add(this.dragNumberOperator6);
            this.Controls.Add(this.dragNumberOperator5);
            this.Controls.Add(this.dragNumberOperator4);
            this.Controls.Add(this.dragNumberOperator3);
            this.Controls.Add(this.dragNumberOperator2);
            this.Controls.Add(this.dragNumberOperator1);
            this.Controls.Add(this.dragLogicalOperator5);
            this.Controls.Add(this.dragLogicalOperator4);
            this.Controls.Add(this.dragLogicalOperator3);
            this.Controls.Add(this.dragLogicalOperator2);
            this.Controls.Add(this.dragLogicalOperator1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.variablesPanel);
            this.Name = "ExpressionBuilder";
            this.Text = "ExpressionBuilder";
            this.Load += new System.EventHandler(this.ExpressionBuilder_Load);
            this.variablesPanel.ResumeLayout(false);
            this.variablesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel variablesPanel;
        private Label label1;
        private Button btnSaveAndClose;
        private Button btnCancel;
        private Draggables.Operators.DragLogicalOperator dragLogicalOperator1;
        private Draggables.Operators.DragLogicalOperator dragLogicalOperator2;
        private Draggables.Operators.DragLogicalOperator dragLogicalOperator3;
        private Draggables.Operators.DragLogicalOperator dragLogicalOperator4;
        private Draggables.Operators.DragLogicalOperator dragLogicalOperator5;
        private Draggables.Operators.DragNumberOperator dragNumberOperator1;
        private Draggables.Operators.DragNumberOperator dragNumberOperator2;
        private Draggables.Operators.DragNumberOperator dragNumberOperator3;
        private Draggables.Operators.DragNumberOperator dragNumberOperator4;
        private Draggables.Operators.DragNumberOperator dragNumberOperator5;
        private Draggables.Operators.DragNumberOperator dragNumberOperator6;
        private Draggables.Operators.DragNumberOperator dragNumberOperator7;
        private Draggables.Operators.DragNumberOperator dragNumberOperator8;
        private Draggables.Operators.DragStringOperator dragStringOperator1;
        private Draggables.Operators.DragLogicalOperator dragLogicalOperator6;
        private Draggables.Operators.DragNumberOperator dragNumberOperator9;
        private Draggables.Operators.DragStringOperator dragStringOperator2;
        private Draggables.Operators.DragLogicalOperator dragLogicalOperator7;
    }
}