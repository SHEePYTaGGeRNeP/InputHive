namespace InputHiveClient
{
    partial class InputHiveClientForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.tbxServerIp = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.numServerPort = new System.Windows.Forms.NumericUpDown();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tabView = new System.Windows.Forms.TabPage();
            this.gbxAllowedKeys = new System.Windows.Forms.GroupBox();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnAllowedKeysRemoveAll = new System.Windows.Forms.Button();
            this.btnAllowedKeysRemove = new System.Windows.Forms.Button();
            this.btnAllowedKeysAdd = new System.Windows.Forms.Button();
            this.lbxSendingKeys = new System.Windows.Forms.ListBox();
            this.cbxAllowedKeys = new System.Windows.Forms.ComboBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.tbxChatMessage = new System.Windows.Forms.TextBox();
            this.btnClearChat = new System.Windows.Forms.Button();
            this.rtbxChat = new System.Windows.Forms.RichTextBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbxLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.tbxSendKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numServerPort)).BeginInit();
            this.tabView.SuspendLayout();
            this.gbxAllowedKeys.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 154);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 50);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(130, 154);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(100, 50);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // tbxServerIp
            // 
            this.tbxServerIp.Location = new System.Drawing.Point(104, 6);
            this.tbxServerIp.Name = "tbxServerIp";
            this.tbxServerIp.Size = new System.Drawing.Size(126, 20);
            this.tbxServerIp.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabSetup);
            this.tabControl.Controls.Add(this.tabView);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(594, 300);
            this.tabControl.TabIndex = 4;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.label3);
            this.tabSetup.Controls.Add(this.numServerPort);
            this.tabSetup.Controls.Add(this.tbxUsername);
            this.tabSetup.Controls.Add(this.btnDisconnect);
            this.tabSetup.Controls.Add(this.btnConnect);
            this.tabSetup.Controls.Add(this.tbxServerIp);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(586, 274);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 65);
            this.label3.TabIndex = 7;
            this.label3.Text = "IP Address\r\n\r\nPort\r\n\r\nUsername";
            // 
            // numServerPort
            // 
            this.numServerPort.Location = new System.Drawing.Point(104, 32);
            this.numServerPort.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numServerPort.Name = "numServerPort";
            this.numServerPort.Size = new System.Drawing.Size(100, 20);
            this.numServerPort.TabIndex = 6;
            this.numServerPort.Value = new decimal(new int[] {
            10085,
            0,
            0,
            0});
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(104, 59);
            this.tbxUsername.MaxLength = 20;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(126, 20);
            this.tbxUsername.TabIndex = 5;
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.gbxAllowedKeys);
            this.tabView.Controls.Add(this.btnSendMessage);
            this.tabView.Controls.Add(this.tbxChatMessage);
            this.tabView.Controls.Add(this.btnClearChat);
            this.tabView.Controls.Add(this.rtbxChat);
            this.tabView.Location = new System.Drawing.Point(4, 22);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(3);
            this.tabView.Size = new System.Drawing.Size(586, 274);
            this.tabView.TabIndex = 1;
            this.tabView.Text = "View";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // gbxAllowedKeys
            // 
            this.gbxAllowedKeys.Controls.Add(this.label1);
            this.gbxAllowedKeys.Controls.Add(this.btnAddAll);
            this.gbxAllowedKeys.Controls.Add(this.tbxSendKey);
            this.gbxAllowedKeys.Controls.Add(this.btnAllowedKeysRemoveAll);
            this.gbxAllowedKeys.Controls.Add(this.btnAllowedKeysRemove);
            this.gbxAllowedKeys.Controls.Add(this.btnAllowedKeysAdd);
            this.gbxAllowedKeys.Controls.Add(this.lbxSendingKeys);
            this.gbxAllowedKeys.Controls.Add(this.cbxAllowedKeys);
            this.gbxAllowedKeys.Location = new System.Drawing.Point(8, 31);
            this.gbxAllowedKeys.Name = "gbxAllowedKeys";
            this.gbxAllowedKeys.Size = new System.Drawing.Size(287, 237);
            this.gbxAllowedKeys.TabIndex = 17;
            this.gbxAllowedKeys.TabStop = false;
            this.gbxAllowedKeys.Text = "Keys to send";
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(203, 46);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 23);
            this.btnAddAll.TabIndex = 19;
            this.btnAddAll.Text = "Add all";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnAllowedKeysRemoveAll
            // 
            this.btnAllowedKeysRemoveAll.Location = new System.Drawing.Point(203, 141);
            this.btnAllowedKeysRemoveAll.Name = "btnAllowedKeysRemoveAll";
            this.btnAllowedKeysRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnAllowedKeysRemoveAll.TabIndex = 17;
            this.btnAllowedKeysRemoveAll.Text = "Remove All";
            this.btnAllowedKeysRemoveAll.UseVisualStyleBackColor = true;
            this.btnAllowedKeysRemoveAll.Click += new System.EventHandler(this.btnAllowedKeysRemoveAll_Click);
            // 
            // btnAllowedKeysRemove
            // 
            this.btnAllowedKeysRemove.Location = new System.Drawing.Point(203, 170);
            this.btnAllowedKeysRemove.Name = "btnAllowedKeysRemove";
            this.btnAllowedKeysRemove.Size = new System.Drawing.Size(75, 23);
            this.btnAllowedKeysRemove.TabIndex = 16;
            this.btnAllowedKeysRemove.Text = "Remove";
            this.btnAllowedKeysRemove.UseVisualStyleBackColor = true;
            this.btnAllowedKeysRemove.Click += new System.EventHandler(this.btnAllowedKeysRemove_Click);
            // 
            // btnAllowedKeysAdd
            // 
            this.btnAllowedKeysAdd.Location = new System.Drawing.Point(203, 17);
            this.btnAllowedKeysAdd.Name = "btnAllowedKeysAdd";
            this.btnAllowedKeysAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAllowedKeysAdd.TabIndex = 15;
            this.btnAllowedKeysAdd.Text = "Add";
            this.btnAllowedKeysAdd.UseVisualStyleBackColor = true;
            this.btnAllowedKeysAdd.Click += new System.EventHandler(this.btnAllowedKeysAdd_Click);
            // 
            // lbxSendingKeys
            // 
            this.lbxSendingKeys.FormattingEnabled = true;
            this.lbxSendingKeys.Location = new System.Drawing.Point(7, 46);
            this.lbxSendingKeys.Name = "lbxSendingKeys";
            this.lbxSendingKeys.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxSendingKeys.Size = new System.Drawing.Size(190, 147);
            this.lbxSendingKeys.TabIndex = 12;
            // 
            // cbxAllowedKeys
            // 
            this.cbxAllowedKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAllowedKeys.FormattingEnabled = true;
            this.cbxAllowedKeys.Location = new System.Drawing.Point(6, 19);
            this.cbxAllowedKeys.Name = "cbxAllowedKeys";
            this.cbxAllowedKeys.Size = new System.Drawing.Size(191, 21);
            this.cbxAllowedKeys.TabIndex = 14;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Enabled = false;
            this.btnSendMessage.Location = new System.Drawing.Point(503, 234);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 34);
            this.btnSendMessage.TabIndex = 14;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // tbxChatMessage
            // 
            this.tbxChatMessage.Location = new System.Drawing.Point(323, 234);
            this.tbxChatMessage.MaxLength = 100;
            this.tbxChatMessage.Multiline = true;
            this.tbxChatMessage.Name = "tbxChatMessage";
            this.tbxChatMessage.ReadOnly = true;
            this.tbxChatMessage.Size = new System.Drawing.Size(174, 34);
            this.tbxChatMessage.TabIndex = 13;
            // 
            // btnClearChat
            // 
            this.btnClearChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearChat.Enabled = false;
            this.btnClearChat.Location = new System.Drawing.Point(424, 6);
            this.btnClearChat.Name = "btnClearChat";
            this.btnClearChat.Size = new System.Drawing.Size(156, 23);
            this.btnClearChat.TabIndex = 9;
            this.btnClearChat.Text = "Clear";
            this.btnClearChat.UseVisualStyleBackColor = true;
            this.btnClearChat.Click += new System.EventHandler(this.btnClearChat_Click);
            // 
            // rtbxChat
            // 
            this.rtbxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxChat.Location = new System.Drawing.Point(323, 31);
            this.rtbxChat.Name = "rtbxChat";
            this.rtbxChat.ReadOnly = true;
            this.rtbxChat.Size = new System.Drawing.Size(258, 200);
            this.rtbxChat.TabIndex = 10;
            this.rtbxChat.Text = "";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectionStatus.Location = new System.Drawing.Point(153, 303);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(55, 20);
            this.lblConnectionStatus.TabIndex = 11;
            this.lblConnectionStatus.Text = "Offline";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Connection status:";
            // 
            // rtbxLog
            // 
            this.rtbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxLog.Location = new System.Drawing.Point(4, 332);
            this.rtbxLog.Name = "rtbxLog";
            this.rtbxLog.ReadOnly = true;
            this.rtbxLog.Size = new System.Drawing.Size(590, 149);
            this.rtbxLog.TabIndex = 8;
            this.rtbxLog.Text = "";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(497, 303);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(97, 23);
            this.btnClearLog.TabIndex = 9;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // tbxSendKey
            // 
            this.tbxSendKey.BackColor = System.Drawing.Color.DarkRed;
            this.tbxSendKey.Location = new System.Drawing.Point(70, 211);
            this.tbxSendKey.Name = "tbxSendKey";
            this.tbxSendKey.Size = new System.Drawing.Size(127, 20);
            this.tbxSendKey.TabIndex = 19;
            this.tbxSendKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSendKey_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Send Keys";
            // 
            // InputHiveClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 483);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbxLog);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(546, 522);
            this.Name = "InputHiveClientForm";
            this.Text = "Input Hive Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputHiveClientForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputHiveClientForm_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numServerPort)).EndInit();
            this.tabView.ResumeLayout(false);
            this.tabView.PerformLayout();
            this.gbxAllowedKeys.ResumeLayout(false);
            this.gbxAllowedKeys.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox tbxServerIp;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbxLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnClearChat;
        private System.Windows.Forms.RichTextBox rtbxChat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numServerPort;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox tbxChatMessage;
        private System.Windows.Forms.GroupBox gbxAllowedKeys;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnAllowedKeysRemoveAll;
        private System.Windows.Forms.Button btnAllowedKeysRemove;
        private System.Windows.Forms.Button btnAllowedKeysAdd;
        private System.Windows.Forms.ListBox lbxSendingKeys;
        private System.Windows.Forms.ComboBox cbxAllowedKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSendKey;
    }
}