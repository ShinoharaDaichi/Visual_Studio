namespace be_isib_kuka

{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpY1 = new System.Windows.Forms.GroupBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.gpX1 = new System.Windows.Forms.GroupBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.stack = new System.Windows.Forms.DataGridView();
            this.btnSendMTP = new System.Windows.Forms.Button();
            this.positionBar = new System.Windows.Forms.TrackBar();
            this.positionValueLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.gpYLineStart = new System.Windows.Forms.GroupBox();
            this.textBoxYLineStart = new System.Windows.Forms.TextBox();
            this.gpXLineStart = new System.Windows.Forms.GroupBox();
            this.textBoxXLineStart = new System.Windows.Forms.TextBox();
            this.buttonAddLine = new System.Windows.Forms.Button();
            this.btnSendStack = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMoveToPoint = new System.Windows.Forms.GroupBox();
            this.groupBoxLine = new System.Windows.Forms.GroupBox();
            this.labelArrowLine = new System.Windows.Forms.Label();
            this.gpYLineEnd = new System.Windows.Forms.GroupBox();
            this.textBoxYLineEnd = new System.Windows.Forms.TextBox();
            this.gpXLineEnd = new System.Windows.Forms.GroupBox();
            this.textBoxXLineEnd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gpY1.SuspendLayout();
            this.gpX1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).BeginInit();
            this.gpYLineStart.SuspendLayout();
            this.gpXLineStart.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxMoveToPoint.SuspendLayout();
            this.groupBoxLine.SuspendLayout();
            this.gpYLineEnd.SuspendLayout();
            this.gpXLineEnd.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpY1
            // 
            this.gpY1.Controls.Add(this.tbY);
            this.gpY1.Location = new System.Drawing.Point(113, 21);
            this.gpY1.Name = "gpY1";
            this.gpY1.Size = new System.Drawing.Size(99, 50);
            this.gpY1.TabIndex = 26;
            this.gpY1.TabStop = false;
            this.gpY1.Text = "Y";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(6, 23);
            this.tbY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(87, 22);
            this.tbY.TabIndex = 10;
            // 
            // gpX1
            // 
            this.gpX1.Controls.Add(this.tbX);
            this.gpX1.Location = new System.Drawing.Point(8, 21);
            this.gpX1.Name = "gpX1";
            this.gpX1.Size = new System.Drawing.Size(99, 50);
            this.gpX1.TabIndex = 25;
            this.gpX1.TabStop = false;
            this.gpX1.Text = "X";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(6, 23);
            this.tbX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(87, 22);
            this.tbX.TabIndex = 9;
            // 
            // stack
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.stack.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.stack.BackgroundColor = System.Drawing.Color.White;
            this.stack.CausesValidation = false;
            this.stack.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.stack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stack.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stack.DefaultCellStyle = dataGridViewCellStyle3;
            this.stack.GridColor = System.Drawing.Color.White;
            this.stack.Location = new System.Drawing.Point(3, 3);
            this.stack.Name = "stack";
            this.stack.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.stack.RowHeadersVisible = false;
            this.stack.RowTemplate.Height = 24;
            this.stack.RowTemplate.ReadOnly = true;
            this.stack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stack.ShowEditingIcon = false;
            this.stack.Size = new System.Drawing.Size(272, 408);
            this.stack.TabIndex = 24;
            // 
            // btnSendMTP
            // 
            this.btnSendMTP.Location = new System.Drawing.Point(8, 76);
            this.btnSendMTP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMTP.Name = "btnSendMTP";
            this.btnSendMTP.Size = new System.Drawing.Size(204, 48);
            this.btnSendMTP.TabIndex = 23;
            this.btnSendMTP.Text = "SEND";
            this.btnSendMTP.UseVisualStyleBackColor = true;
            this.btnSendMTP.Click += new System.EventHandler(this.btnSendMTP_Click);
            // 
            // positionBar
            // 
            this.positionBar.LargeChange = 1;
            this.positionBar.Location = new System.Drawing.Point(225, 27);
            this.positionBar.Maximum = 1;
            this.positionBar.Name = "positionBar";
            this.positionBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.positionBar.Size = new System.Drawing.Size(56, 112);
            this.positionBar.TabIndex = 27;
            this.positionBar.Scroll += new System.EventHandler(this.positionBar_Scroll);
            // 
            // positionValueLabel
            // 
            this.positionValueLabel.AutoSize = true;
            this.positionValueLabel.Location = new System.Drawing.Point(281, 87);
            this.positionValueLabel.Name = "positionValueLabel";
            this.positionValueLabel.Size = new System.Drawing.Size(52, 17);
            this.positionValueLabel.TabIndex = 28;
            this.positionValueLabel.Text = "DOWN";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(281, 41);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(58, 17);
            this.positionLabel.TabIndex = 29;
            this.positionLabel.Text = "Position";
            // 
            // gpYLineStart
            // 
            this.gpYLineStart.Controls.Add(this.textBoxYLineStart);
            this.gpYLineStart.Location = new System.Drawing.Point(111, 21);
            this.gpYLineStart.Name = "gpYLineStart";
            this.gpYLineStart.Size = new System.Drawing.Size(99, 53);
            this.gpYLineStart.TabIndex = 32;
            this.gpYLineStart.TabStop = false;
            this.gpYLineStart.Text = "Y (Start)";
            // 
            // textBoxYLineStart
            // 
            this.textBoxYLineStart.Location = new System.Drawing.Point(6, 20);
            this.textBoxYLineStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxYLineStart.Name = "textBoxYLineStart";
            this.textBoxYLineStart.Size = new System.Drawing.Size(87, 22);
            this.textBoxYLineStart.TabIndex = 10;
            // 
            // gpXLineStart
            // 
            this.gpXLineStart.Controls.Add(this.textBoxXLineStart);
            this.gpXLineStart.Location = new System.Drawing.Point(6, 21);
            this.gpXLineStart.Name = "gpXLineStart";
            this.gpXLineStart.Size = new System.Drawing.Size(99, 53);
            this.gpXLineStart.TabIndex = 31;
            this.gpXLineStart.TabStop = false;
            this.gpXLineStart.Text = "X (Start)";
            // 
            // textBoxXLineStart
            // 
            this.textBoxXLineStart.Location = new System.Drawing.Point(6, 20);
            this.textBoxXLineStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxXLineStart.Name = "textBoxXLineStart";
            this.textBoxXLineStart.Size = new System.Drawing.Size(87, 22);
            this.textBoxXLineStart.TabIndex = 9;
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Location = new System.Drawing.Point(1, 90);
            this.buttonAddLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(449, 48);
            this.buttonAddLine.TabIndex = 30;
            this.buttonAddLine.Text = "ADD";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            this.buttonAddLine.Click += new System.EventHandler(this.buttonAddLine_Click);
            // 
            // btnSendStack
            // 
            this.btnSendStack.Location = new System.Drawing.Point(3, 416);
            this.btnSendStack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendStack.Name = "btnSendStack";
            this.btnSendStack.Size = new System.Drawing.Size(272, 48);
            this.btnSendStack.TabIndex = 34;
            this.btnSendStack.Text = "SEND";
            this.btnSendStack.UseVisualStyleBackColor = true;
            this.btnSendStack.Click += new System.EventHandler(this.btnSendStack_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.62626F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.37374F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.7027F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.2973F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(775, 472);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxMoveToPoint, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxLine, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(473, 466);
            this.tableLayoutPanel2.TabIndex = 39;
            // 
            // groupBoxMoveToPoint
            // 
            this.groupBoxMoveToPoint.Controls.Add(this.positionLabel);
            this.groupBoxMoveToPoint.Controls.Add(this.gpX1);
            this.groupBoxMoveToPoint.Controls.Add(this.positionBar);
            this.groupBoxMoveToPoint.Controls.Add(this.btnSendMTP);
            this.groupBoxMoveToPoint.Controls.Add(this.positionValueLabel);
            this.groupBoxMoveToPoint.Controls.Add(this.gpY1);
            this.groupBoxMoveToPoint.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMoveToPoint.Name = "groupBoxMoveToPoint";
            this.groupBoxMoveToPoint.Size = new System.Drawing.Size(339, 141);
            this.groupBoxMoveToPoint.TabIndex = 37;
            this.groupBoxMoveToPoint.TabStop = false;
            this.groupBoxMoveToPoint.Text = "MoveToPoint";
            // 
            // groupBoxLine
            // 
            this.groupBoxLine.Controls.Add(this.labelArrowLine);
            this.groupBoxLine.Controls.Add(this.gpYLineEnd);
            this.groupBoxLine.Controls.Add(this.gpXLineEnd);
            this.groupBoxLine.Controls.Add(this.gpYLineStart);
            this.groupBoxLine.Controls.Add(this.gpXLineStart);
            this.groupBoxLine.Controls.Add(this.buttonAddLine);
            this.groupBoxLine.Location = new System.Drawing.Point(3, 236);
            this.groupBoxLine.Name = "groupBoxLine";
            this.groupBoxLine.Size = new System.Drawing.Size(462, 148);
            this.groupBoxLine.TabIndex = 38;
            this.groupBoxLine.TabStop = false;
            this.groupBoxLine.Text = "WriteLine";
            // 
            // labelArrowLine
            // 
            this.labelArrowLine.AutoSize = true;
            this.labelArrowLine.Location = new System.Drawing.Point(216, 44);
            this.labelArrowLine.Name = "labelArrowLine";
            this.labelArrowLine.Size = new System.Drawing.Size(24, 17);
            this.labelArrowLine.TabIndex = 30;
            this.labelArrowLine.Text = "=>";
            // 
            // gpYLineEnd
            // 
            this.gpYLineEnd.Controls.Add(this.textBoxYLineEnd);
            this.gpYLineEnd.Location = new System.Drawing.Point(351, 21);
            this.gpYLineEnd.Name = "gpYLineEnd";
            this.gpYLineEnd.Size = new System.Drawing.Size(99, 53);
            this.gpYLineEnd.TabIndex = 34;
            this.gpYLineEnd.TabStop = false;
            this.gpYLineEnd.Text = "Y (End)";
            // 
            // textBoxYLineEnd
            // 
            this.textBoxYLineEnd.Location = new System.Drawing.Point(6, 20);
            this.textBoxYLineEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxYLineEnd.Name = "textBoxYLineEnd";
            this.textBoxYLineEnd.Size = new System.Drawing.Size(87, 22);
            this.textBoxYLineEnd.TabIndex = 10;
            // 
            // gpXLineEnd
            // 
            this.gpXLineEnd.Controls.Add(this.textBoxXLineEnd);
            this.gpXLineEnd.Location = new System.Drawing.Point(246, 21);
            this.gpXLineEnd.Name = "gpXLineEnd";
            this.gpXLineEnd.Size = new System.Drawing.Size(99, 53);
            this.gpXLineEnd.TabIndex = 33;
            this.gpXLineEnd.TabStop = false;
            this.gpXLineEnd.Text = "X (End)";
            // 
            // textBoxXLineEnd
            // 
            this.textBoxXLineEnd.Location = new System.Drawing.Point(6, 20);
            this.textBoxXLineEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxXLineEnd.Name = "textBoxXLineEnd";
            this.textBoxXLineEnd.Size = new System.Drawing.Size(87, 22);
            this.textBoxXLineEnd.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.stack);
            this.panel2.Controls.Add(this.btnSendStack);
            this.panel2.Location = new System.Drawing.Point(488, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 466);
            this.panel2.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 503);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gpY1.ResumeLayout(false);
            this.gpY1.PerformLayout();
            this.gpX1.ResumeLayout(false);
            this.gpX1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).EndInit();
            this.gpYLineStart.ResumeLayout(false);
            this.gpYLineStart.PerformLayout();
            this.gpXLineStart.ResumeLayout(false);
            this.gpXLineStart.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxMoveToPoint.ResumeLayout(false);
            this.groupBoxMoveToPoint.PerformLayout();
            this.groupBoxLine.ResumeLayout(false);
            this.groupBoxLine.PerformLayout();
            this.gpYLineEnd.ResumeLayout(false);
            this.gpYLineEnd.PerformLayout();
            this.gpXLineEnd.ResumeLayout(false);
            this.gpXLineEnd.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gpY1;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.GroupBox gpX1;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.DataGridView stack;
        private System.Windows.Forms.Button btnSendMTP;
        private System.Windows.Forms.TrackBar positionBar;
        private System.Windows.Forms.Label positionValueLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.GroupBox gpYLineStart;
        private System.Windows.Forms.TextBox textBoxYLineStart;
        private System.Windows.Forms.GroupBox gpXLineStart;
        private System.Windows.Forms.TextBox textBoxXLineStart;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.Button btnSendStack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBoxMoveToPoint;
        private System.Windows.Forms.GroupBox groupBoxLine;
        private System.Windows.Forms.GroupBox gpYLineEnd;
        private System.Windows.Forms.TextBox textBoxYLineEnd;
        private System.Windows.Forms.GroupBox gpXLineEnd;
        private System.Windows.Forms.TextBox textBoxXLineEnd;
        private System.Windows.Forms.Label labelArrowLine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

