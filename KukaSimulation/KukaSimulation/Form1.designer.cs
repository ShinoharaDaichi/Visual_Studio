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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.tb = new System.Windows.Forms.RichTextBox();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelXValue = new System.Windows.Forms.Label();
            this.labelYValue = new System.Windows.Forms.Label();
            this.stack = new System.Windows.Forms.DataGridView();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionValueLabel = new System.Windows.Forms.Label();
            this.positionBar = new System.Windows.Forms.TrackBar();
            this.groupBoxY = new System.Windows.Forms.GroupBox();
            this.groupBoxX = new System.Windows.Forms.GroupBox();
            this.groupBoxRadius = new System.Windows.Forms.GroupBox();
            this.tbRadius = new System.Windows.Forms.TextBox();
            this.btnCircle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stack)).BeginInit();
            this.groupBoxControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).BeginInit();
            this.groupBoxY.SuspendLayout();
            this.groupBoxX.SuspendLayout();
            this.groupBoxRadius.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(646, 483);
            this.mainPanel.TabIndex = 0;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(158, 296);
            this.labelSpeedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Size = new System.Drawing.Size(19, 13);
            this.labelSpeedValue.TabIndex = 3;
            this.labelSpeedValue.Text = "50";
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(664, 12);
            this.tb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(342, 150);
            this.tb.TabIndex = 1;
            this.tb.Text = "";
            // 
            // speedBar
            // 
            this.speedBar.LargeChange = 10;
            this.speedBar.Location = new System.Drawing.Point(4, 264);
            this.speedBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.speedBar.Maximum = 100;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(326, 45);
            this.speedBar.TabIndex = 2;
            this.speedBar.Value = 50;
            this.speedBar.Scroll += new System.EventHandler(this.bar_Scroll);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(66, 16);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 19);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(66, 80);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(56, 19);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(10, 49);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(56, 19);
            this.btnLeft.TabIndex = 5;
            this.btnLeft.Text = "LEFT";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(120, 49);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(56, 19);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = "RIGHT";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(4, 30);
            this.tbX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(66, 20);
            this.tbX.TabIndex = 9;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(4, 31);
            this.tbY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(66, 20);
            this.tbY.TabIndex = 10;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(14, 171);
            this.btnMove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(153, 39);
            this.btnMove.TabIndex = 11;
            this.btnMove.Text = "MOVE";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(148, 311);
            this.labelSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(38, 13);
            this.labelSpeed.TabIndex = 12;
            this.labelSpeed.Text = "Speed";
            // 
            // labelXValue
            // 
            this.labelXValue.AutoSize = true;
            this.labelXValue.Location = new System.Drawing.Point(30, 15);
            this.labelXValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelXValue.Name = "labelXValue";
            this.labelXValue.Size = new System.Drawing.Size(13, 13);
            this.labelXValue.TabIndex = 15;
            this.labelXValue.Text = "0";
            // 
            // labelYValue
            // 
            this.labelYValue.AutoSize = true;
            this.labelYValue.Location = new System.Drawing.Point(28, 15);
            this.labelYValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelYValue.Name = "labelYValue";
            this.labelYValue.Size = new System.Drawing.Size(13, 13);
            this.labelYValue.TabIndex = 16;
            this.labelYValue.Text = "0";
            // 
            // stack
            // 
            this.stack.AllowUserToAddRows = false;
            this.stack.AllowUserToResizeColumns = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.stack.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.stack.BackgroundColor = System.Drawing.Color.White;
            this.stack.CausesValidation = false;
            this.stack.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.stack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stack.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stack.DefaultCellStyle = dataGridViewCellStyle9;
            this.stack.GridColor = System.Drawing.Color.White;
            this.stack.Location = new System.Drawing.Point(173, 111);
            this.stack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stack.Name = "stack";
            this.stack.ReadOnly = true;
            this.stack.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.stack.RowHeadersVisible = false;
            this.stack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.stack.RowTemplate.Height = 24;
            this.stack.RowTemplate.ReadOnly = true;
            this.stack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stack.ShowEditingIcon = false;
            this.stack.Size = new System.Drawing.Size(163, 149);
            this.stack.TabIndex = 19;
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.btnCircle);
            this.groupBoxControl.Controls.Add(this.groupBoxRadius);
            this.groupBoxControl.Controls.Add(this.positionLabel);
            this.groupBoxControl.Controls.Add(this.positionValueLabel);
            this.groupBoxControl.Controls.Add(this.positionBar);
            this.groupBoxControl.Controls.Add(this.groupBoxY);
            this.groupBoxControl.Controls.Add(this.groupBoxX);
            this.groupBoxControl.Controls.Add(this.stack);
            this.groupBoxControl.Controls.Add(this.labelSpeed);
            this.groupBoxControl.Controls.Add(this.labelSpeedValue);
            this.groupBoxControl.Controls.Add(this.speedBar);
            this.groupBoxControl.Controls.Add(this.btnMove);
            this.groupBoxControl.Controls.Add(this.btnRight);
            this.groupBoxControl.Controls.Add(this.btnLeft);
            this.groupBoxControl.Controls.Add(this.btnDown);
            this.groupBoxControl.Controls.Add(this.btnUp);
            this.groupBoxControl.Location = new System.Drawing.Point(664, 166);
            this.groupBoxControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxControl.Size = new System.Drawing.Size(340, 329);
            this.groupBoxControl.TabIndex = 20;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "CONTROL";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(248, 38);
            this.positionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(44, 13);
            this.positionLabel.TabIndex = 32;
            this.positionLabel.Text = "Position";
            // 
            // positionValueLabel
            // 
            this.positionValueLabel.AutoSize = true;
            this.positionValueLabel.Location = new System.Drawing.Point(248, 72);
            this.positionValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.positionValueLabel.Name = "positionValueLabel";
            this.positionValueLabel.Size = new System.Drawing.Size(42, 13);
            this.positionValueLabel.TabIndex = 31;
            this.positionValueLabel.Text = "DOWN";
            // 
            // positionBar
            // 
            this.positionBar.LargeChange = 1;
            this.positionBar.Location = new System.Drawing.Point(202, 17);
            this.positionBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.positionBar.Maximum = 1;
            this.positionBar.Name = "positionBar";
            this.positionBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.positionBar.Size = new System.Drawing.Size(45, 81);
            this.positionBar.TabIndex = 30;
            // 
            // groupBoxY
            // 
            this.groupBoxY.Controls.Add(this.labelYValue);
            this.groupBoxY.Controls.Add(this.tbY);
            this.groupBoxY.Location = new System.Drawing.Point(93, 111);
            this.groupBoxY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxY.Name = "groupBoxY";
            this.groupBoxY.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxY.Size = new System.Drawing.Size(74, 56);
            this.groupBoxY.TabIndex = 21;
            this.groupBoxY.TabStop = false;
            this.groupBoxY.Text = "Y";
            // 
            // groupBoxX
            // 
            this.groupBoxX.Controls.Add(this.labelXValue);
            this.groupBoxX.Controls.Add(this.tbX);
            this.groupBoxX.Location = new System.Drawing.Point(14, 111);
            this.groupBoxX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxX.Name = "groupBoxX";
            this.groupBoxX.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxX.Size = new System.Drawing.Size(74, 56);
            this.groupBoxX.TabIndex = 20;
            this.groupBoxX.TabStop = false;
            this.groupBoxX.Text = "X";
            // 
            // groupBoxRadius
            // 
            this.groupBoxRadius.Controls.Add(this.tbRadius);
            this.groupBoxRadius.Location = new System.Drawing.Point(13, 214);
            this.groupBoxRadius.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxRadius.Name = "groupBoxRadius";
            this.groupBoxRadius.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxRadius.Size = new System.Drawing.Size(74, 46);
            this.groupBoxRadius.TabIndex = 22;
            this.groupBoxRadius.TabStop = false;
            this.groupBoxRadius.Text = "RADIUS";
            // 
            // tbRadius
            // 
            this.tbRadius.Location = new System.Drawing.Point(4, 17);
            this.tbRadius.Margin = new System.Windows.Forms.Padding(2);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(66, 20);
            this.tbRadius.TabIndex = 10;
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(92, 214);
            this.btnCircle.Margin = new System.Windows.Forms.Padding(2);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(74, 46);
            this.btnCircle.TabIndex = 33;
            this.btnCircle.Text = "DRAW CIRCLE";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 504);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stack)).EndInit();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).EndInit();
            this.groupBoxY.ResumeLayout(false);
            this.groupBoxY.PerformLayout();
            this.groupBoxX.ResumeLayout(false);
            this.groupBoxX.PerformLayout();
            this.groupBoxRadius.ResumeLayout(false);
            this.groupBoxRadius.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.RichTextBox tb;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelXValue;
        private System.Windows.Forms.Label labelYValue;
        private System.Windows.Forms.DataGridView stack;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.GroupBox groupBoxX;
        private System.Windows.Forms.GroupBox groupBoxY;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label positionValueLabel;
        private System.Windows.Forms.TrackBar positionBar;
        private System.Windows.Forms.GroupBox groupBoxRadius;
        private System.Windows.Forms.TextBox tbRadius;
        private System.Windows.Forms.Button btnCircle;
    }
}

