namespace Shooter
{
    partial class Setup
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHost = new System.Windows.Forms.TabPage();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnHost = new System.Windows.Forms.Button();
            this.tabJoin = new System.Windows.Forms.TabPage();
            this.btnJoin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPortClient = new System.Windows.Forms.TextBox();
            this.lblPortClient = new System.Windows.Forms.Label();
            this.tbIpClient = new System.Windows.Forms.TextBox();
            this.lblIpClient = new System.Windows.Forms.Label();
            this.btnLocal = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.tbPlayers = new System.Windows.Forms.RichTextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.labelChat = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabHost.SuspendLayout();
            this.tabJoin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHost);
            this.tabControl.Controls.Add(this.tabJoin);
            this.tabControl.Location = new System.Drawing.Point(12, 55);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(478, 86);
            this.tabControl.TabIndex = 0;
            // 
            // tabHost
            // 
            this.tabHost.Controls.Add(this.btnStart);
            this.tabHost.Controls.Add(this.btnHost);
            this.tabHost.Location = new System.Drawing.Point(4, 22);
            this.tabHost.Name = "tabHost";
            this.tabHost.Padding = new System.Windows.Forms.Padding(3);
            this.tabHost.Size = new System.Drawing.Size(470, 60);
            this.tabHost.TabIndex = 0;
            this.tabHost.Text = "Host";
            this.tabHost.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(243, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(221, 46);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnHost
            // 
            this.btnHost.Location = new System.Drawing.Point(6, 8);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(231, 46);
            this.btnHost.TabIndex = 5;
            this.btnHost.Text = "Host";
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // tabJoin
            // 
            this.tabJoin.Controls.Add(this.btnJoin);
            this.tabJoin.Controls.Add(this.label1);
            this.tabJoin.Controls.Add(this.tbPortClient);
            this.tabJoin.Controls.Add(this.lblPortClient);
            this.tabJoin.Controls.Add(this.tbIpClient);
            this.tabJoin.Controls.Add(this.lblIpClient);
            this.tabJoin.Location = new System.Drawing.Point(4, 22);
            this.tabJoin.Name = "tabJoin";
            this.tabJoin.Padding = new System.Windows.Forms.Padding(3);
            this.tabJoin.Size = new System.Drawing.Size(470, 60);
            this.tabJoin.TabIndex = 1;
            this.tabJoin.Text = "Join";
            this.tabJoin.UseVisualStyleBackColor = true;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(270, 8);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(95, 46);
            this.btnJoin.TabIndex = 12;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Status";
            // 
            // tbPortClient
            // 
            this.tbPortClient.Location = new System.Drawing.Point(64, 34);
            this.tbPortClient.Name = "tbPortClient";
            this.tbPortClient.Size = new System.Drawing.Size(200, 20);
            this.tbPortClient.TabIndex = 10;
            this.tbPortClient.Text = "2000";
            // 
            // lblPortClient
            // 
            this.lblPortClient.AutoSize = true;
            this.lblPortClient.Location = new System.Drawing.Point(6, 37);
            this.lblPortClient.Name = "lblPortClient";
            this.lblPortClient.Size = new System.Drawing.Size(26, 13);
            this.lblPortClient.TabIndex = 9;
            this.lblPortClient.Text = "Port";
            // 
            // tbIpClient
            // 
            this.tbIpClient.Location = new System.Drawing.Point(64, 8);
            this.tbIpClient.Name = "tbIpClient";
            this.tbIpClient.Size = new System.Drawing.Size(200, 20);
            this.tbIpClient.TabIndex = 8;
            this.tbIpClient.Text = "127.0.0.1";
            // 
            // lblIpClient
            // 
            this.lblIpClient.AutoSize = true;
            this.lblIpClient.Location = new System.Drawing.Point(6, 11);
            this.lblIpClient.Name = "lblIpClient";
            this.lblIpClient.Size = new System.Drawing.Size(55, 13);
            this.lblIpClient.TabIndex = 7;
            this.lblIpClient.Text = "IPAddress";
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(423, 14);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(60, 46);
            this.btnLocal.TabIndex = 7;
            this.btnLocal.Text = "LOCAL";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 147);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(268, 141);
            this.tbLog.TabIndex = 5;
            this.tbLog.Text = "";
            // 
            // tbPlayers
            // 
            this.tbPlayers.Location = new System.Drawing.Point(286, 147);
            this.tbPlayers.Name = "tbPlayers";
            this.tbPlayers.Size = new System.Drawing.Size(204, 141);
            this.tbPlayers.TabIndex = 6;
            this.tbPlayers.Text = "";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 28);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(125, 20);
            this.tbName.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Username";
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(143, 28);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(193, 20);
            this.chatBox.TabIndex = 8;
            this.chatBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatBox_KeyDown);
            // 
            // labelChat
            // 
            this.labelChat.AutoSize = true;
            this.labelChat.Location = new System.Drawing.Point(140, 9);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(50, 13);
            this.labelChat.TabIndex = 9;
            this.labelChat.Text = "Message";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(342, 14);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 46);
            this.btnSendMessage.TabIndex = 10;
            this.btnSendMessage.Text = "SEND";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 298);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.labelChat);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbPlayers);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.tabControl);
            this.Name = "Setup";
            this.Text = "Setup Game";
            this.tabControl.ResumeLayout(false);
            this.tabHost.ResumeLayout(false);
            this.tabJoin.ResumeLayout(false);
            this.tabJoin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHost;
        private System.Windows.Forms.TabPage tabJoin;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPortClient;
        private System.Windows.Forms.Label lblPortClient;
        private System.Windows.Forms.TextBox tbIpClient;
        private System.Windows.Forms.Label lblIpClient;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.RichTextBox tbPlayers;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Button btnSendMessage;

    }
}