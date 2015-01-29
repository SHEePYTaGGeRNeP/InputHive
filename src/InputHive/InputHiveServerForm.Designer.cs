namespace InputHive
{
    partial class InputHiveServerForm
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
            this.rtbxLog = new System.Windows.Forms.RichTextBox();
            this.gbxServer = new System.Windows.Forms.GroupBox();
            this.chbxLogAll = new System.Windows.Forms.CheckBox();
            this.gbxSetupAllowedKeys = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numSetupDefaultMinimumTime = new System.Windows.Forms.NumericUpDown();
            this.chbxSetupDefaultKeysAllowInput = new System.Windows.Forms.CheckBox();
            this.btnSetupDefaultKeysAddAll = new System.Windows.Forms.Button();
            this.btnSetupAllowedKeysRemoveAll = new System.Windows.Forms.Button();
            this.btnSetupAllowedKeysRemove = new System.Windows.Forms.Button();
            this.btnSetupDefaultKeysAdd = new System.Windows.Forms.Button();
            this.lbxSetupDefaultKeys = new System.Windows.Forms.ListBox();
            this.cbxSetupDefaultKeys = new System.Windows.Forms.ComboBox();
            this.chbxAllowConnections = new System.Windows.Forms.CheckBox();
            this.numMaxClients = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxIpAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.btnTurnServerOff = new System.Windows.Forms.Button();
            this.btnTurnServerOn = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.tabView = new System.Windows.Forms.TabPage();
            this.btnClearWindow = new System.Windows.Forms.Button();
            this.gbxAllowedKeys = new System.Windows.Forms.GroupBox();
            this.gbxViewClient = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numClientMinimumTime = new System.Windows.Forms.NumericUpDown();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnUpdateKeyList = new System.Windows.Forms.Button();
            this.btnAllowedKeysRemoveAll = new System.Windows.Forms.Button();
            this.btnAllowedKeysRemove = new System.Windows.Forms.Button();
            this.btnAllowedKeysAdd = new System.Windows.Forms.Button();
            this.lbxAllowedKeys = new System.Windows.Forms.ListBox();
            this.cbxAllowedKeys = new System.Windows.Forms.ComboBox();
            this.btnKick = new System.Windows.Forms.Button();
            this.chbxAllowInput = new System.Windows.Forms.CheckBox();
            this.lbxClients = new System.Windows.Forms.ListBox();
            this.lblCurrentWindow = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectWindow = new System.Windows.Forms.Button();
            this.chbxStopAllInput = new System.Windows.Forms.CheckBox();
            this.btnClearChat = new System.Windows.Forms.Button();
            this.rtbxChat = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.gbxServer.SuspendLayout();
            this.gbxSetupAllowedKeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetupDefaultMinimumTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabView.SuspendLayout();
            this.gbxAllowedKeys.SuspendLayout();
            this.gbxViewClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClientMinimumTime)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbxLog
            // 
            this.rtbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxLog.Location = new System.Drawing.Point(4, 390);
            this.rtbxLog.Name = "rtbxLog";
            this.rtbxLog.ReadOnly = true;
            this.rtbxLog.Size = new System.Drawing.Size(805, 133);
            this.rtbxLog.TabIndex = 0;
            this.rtbxLog.Text = "";
            // 
            // gbxServer
            // 
            this.gbxServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxServer.Controls.Add(this.chbxLogAll);
            this.gbxServer.Controls.Add(this.gbxSetupAllowedKeys);
            this.gbxServer.Controls.Add(this.chbxAllowConnections);
            this.gbxServer.Controls.Add(this.numMaxClients);
            this.gbxServer.Controls.Add(this.label4);
            this.gbxServer.Controls.Add(this.tbxIpAddress);
            this.gbxServer.Controls.Add(this.label2);
            this.gbxServer.Controls.Add(this.numPort);
            this.gbxServer.Controls.Add(this.btnTurnServerOff);
            this.gbxServer.Controls.Add(this.btnTurnServerOn);
            this.gbxServer.Location = new System.Drawing.Point(6, 6);
            this.gbxServer.Name = "gbxServer";
            this.gbxServer.Size = new System.Drawing.Size(793, 317);
            this.gbxServer.TabIndex = 1;
            this.gbxServer.TabStop = false;
            this.gbxServer.Text = "Server";
            // 
            // chbxLogAll
            // 
            this.chbxLogAll.AutoSize = true;
            this.chbxLogAll.Checked = true;
            this.chbxLogAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxLogAll.Location = new System.Drawing.Point(16, 284);
            this.chbxLogAll.Name = "chbxLogAll";
            this.chbxLogAll.Size = new System.Drawing.Size(152, 17);
            this.chbxLogAll.TabIndex = 23;
            this.chbxLogAll.Text = "Log all incoming messages";
            this.chbxLogAll.UseVisualStyleBackColor = true;
            this.chbxLogAll.CheckedChanged += new System.EventHandler(this.chbxLogAll_CheckedChanged);
            // 
            // gbxSetupAllowedKeys
            // 
            this.gbxSetupAllowedKeys.Controls.Add(this.label3);
            this.gbxSetupAllowedKeys.Controls.Add(this.numSetupDefaultMinimumTime);
            this.gbxSetupAllowedKeys.Controls.Add(this.chbxSetupDefaultKeysAllowInput);
            this.gbxSetupAllowedKeys.Controls.Add(this.btnSetupDefaultKeysAddAll);
            this.gbxSetupAllowedKeys.Controls.Add(this.btnSetupAllowedKeysRemoveAll);
            this.gbxSetupAllowedKeys.Controls.Add(this.btnSetupAllowedKeysRemove);
            this.gbxSetupAllowedKeys.Controls.Add(this.btnSetupDefaultKeysAdd);
            this.gbxSetupAllowedKeys.Controls.Add(this.lbxSetupDefaultKeys);
            this.gbxSetupAllowedKeys.Controls.Add(this.cbxSetupDefaultKeys);
            this.gbxSetupAllowedKeys.Location = new System.Drawing.Point(6, 19);
            this.gbxSetupAllowedKeys.Name = "gbxSetupAllowedKeys";
            this.gbxSetupAllowedKeys.Size = new System.Drawing.Size(325, 217);
            this.gbxSetupAllowedKeys.TabIndex = 22;
            this.gbxSetupAllowedKeys.TabStop = false;
            this.gbxSetupAllowedKeys.Text = "Default settings for new clients";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 32;
            this.label3.Text = "Minimum time\r\nin milliseconds";
            // 
            // numSetupDefaultMinimumTime
            // 
            this.numSetupDefaultMinimumTime.Location = new System.Drawing.Point(10, 90);
            this.numSetupDefaultMinimumTime.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.numSetupDefaultMinimumTime.Name = "numSetupDefaultMinimumTime";
            this.numSetupDefaultMinimumTime.Size = new System.Drawing.Size(71, 20);
            this.numSetupDefaultMinimumTime.TabIndex = 31;
            this.numSetupDefaultMinimumTime.ValueChanged += new System.EventHandler(this.numSetupDefaultMinimumTime_ValueChanged);
            // 
            // chbxSetupDefaultKeysAllowInput
            // 
            this.chbxSetupDefaultKeysAllowInput.AutoSize = true;
            this.chbxSetupDefaultKeysAllowInput.Checked = true;
            this.chbxSetupDefaultKeysAllowInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxSetupDefaultKeysAllowInput.Location = new System.Drawing.Point(10, 18);
            this.chbxSetupDefaultKeysAllowInput.Name = "chbxSetupDefaultKeysAllowInput";
            this.chbxSetupDefaultKeysAllowInput.Size = new System.Drawing.Size(78, 17);
            this.chbxSetupDefaultKeysAllowInput.TabIndex = 30;
            this.chbxSetupDefaultKeysAllowInput.Text = "Allow Input";
            this.chbxSetupDefaultKeysAllowInput.UseVisualStyleBackColor = true;
            this.chbxSetupDefaultKeysAllowInput.CheckedChanged += new System.EventHandler(this.chbxSetupDefaultKeysAllowInput_CheckedChanged);
            // 
            // btnSetupDefaultKeysAddAll
            // 
            this.btnSetupDefaultKeysAddAll.Location = new System.Drawing.Point(240, 42);
            this.btnSetupDefaultKeysAddAll.Name = "btnSetupDefaultKeysAddAll";
            this.btnSetupDefaultKeysAddAll.Size = new System.Drawing.Size(75, 23);
            this.btnSetupDefaultKeysAddAll.TabIndex = 29;
            this.btnSetupDefaultKeysAddAll.Text = "Add all";
            this.btnSetupDefaultKeysAddAll.UseVisualStyleBackColor = true;
            this.btnSetupDefaultKeysAddAll.Click += new System.EventHandler(this.btnSetupDefaultKeysAddAll_Click);
            // 
            // btnSetupAllowedKeysRemoveAll
            // 
            this.btnSetupAllowedKeysRemoveAll.Location = new System.Drawing.Point(240, 150);
            this.btnSetupAllowedKeysRemoveAll.Name = "btnSetupAllowedKeysRemoveAll";
            this.btnSetupAllowedKeysRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnSetupAllowedKeysRemoveAll.TabIndex = 27;
            this.btnSetupAllowedKeysRemoveAll.Text = "Remove All";
            this.btnSetupAllowedKeysRemoveAll.UseVisualStyleBackColor = true;
            this.btnSetupAllowedKeysRemoveAll.Click += new System.EventHandler(this.btnSetupAllowedKeysRemoveAll_Click);
            // 
            // btnSetupAllowedKeysRemove
            // 
            this.btnSetupAllowedKeysRemove.Location = new System.Drawing.Point(240, 179);
            this.btnSetupAllowedKeysRemove.Name = "btnSetupAllowedKeysRemove";
            this.btnSetupAllowedKeysRemove.Size = new System.Drawing.Size(75, 23);
            this.btnSetupAllowedKeysRemove.TabIndex = 26;
            this.btnSetupAllowedKeysRemove.Text = "Remove";
            this.btnSetupAllowedKeysRemove.UseVisualStyleBackColor = true;
            this.btnSetupAllowedKeysRemove.Click += new System.EventHandler(this.btnSetupAllowedKeysRemove_Click);
            // 
            // btnSetupDefaultKeysAdd
            // 
            this.btnSetupDefaultKeysAdd.Location = new System.Drawing.Point(240, 15);
            this.btnSetupDefaultKeysAdd.Name = "btnSetupDefaultKeysAdd";
            this.btnSetupDefaultKeysAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSetupDefaultKeysAdd.TabIndex = 25;
            this.btnSetupDefaultKeysAdd.Text = "Add";
            this.btnSetupDefaultKeysAdd.UseVisualStyleBackColor = true;
            this.btnSetupDefaultKeysAdd.Click += new System.EventHandler(this.btnSetupDefaultKeysAdd_Click);
            // 
            // lbxSetupDefaultKeys
            // 
            this.lbxSetupDefaultKeys.FormattingEnabled = true;
            this.lbxSetupDefaultKeys.Location = new System.Drawing.Point(94, 42);
            this.lbxSetupDefaultKeys.Name = "lbxSetupDefaultKeys";
            this.lbxSetupDefaultKeys.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxSetupDefaultKeys.Size = new System.Drawing.Size(140, 160);
            this.lbxSetupDefaultKeys.TabIndex = 23;
            // 
            // cbxSetupDefaultKeys
            // 
            this.cbxSetupDefaultKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSetupDefaultKeys.FormattingEnabled = true;
            this.cbxSetupDefaultKeys.Location = new System.Drawing.Point(94, 16);
            this.cbxSetupDefaultKeys.Name = "cbxSetupDefaultKeys";
            this.cbxSetupDefaultKeys.Size = new System.Drawing.Size(140, 21);
            this.cbxSetupDefaultKeys.TabIndex = 24;
            // 
            // chbxAllowConnections
            // 
            this.chbxAllowConnections.AutoSize = true;
            this.chbxAllowConnections.Checked = true;
            this.chbxAllowConnections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAllowConnections.Location = new System.Drawing.Point(381, 154);
            this.chbxAllowConnections.Name = "chbxAllowConnections";
            this.chbxAllowConnections.Size = new System.Drawing.Size(112, 17);
            this.chbxAllowConnections.TabIndex = 11;
            this.chbxAllowConnections.Text = "Allow connections";
            this.chbxAllowConnections.UseVisualStyleBackColor = true;
            this.chbxAllowConnections.CheckedChanged += new System.EventHandler(this.chbxAllowConnections_CheckedChanged);
            // 
            // numMaxClients
            // 
            this.numMaxClients.Location = new System.Drawing.Point(462, 113);
            this.numMaxClients.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMaxClients.Name = "numMaxClients";
            this.numMaxClients.Size = new System.Drawing.Size(67, 20);
            this.numMaxClients.TabIndex = 10;
            this.numMaxClients.ValueChanged += new System.EventHandler(this.numMaxClients_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "( can be left empty )";
            // 
            // tbxIpAddress
            // 
            this.tbxIpAddress.Location = new System.Drawing.Point(462, 62);
            this.tbxIpAddress.Name = "tbxIpAddress";
            this.tbxIpAddress.Size = new System.Drawing.Size(142, 20);
            this.tbxIpAddress.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 91);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port:\r\n\r\nIP Address:\r\n\r\n\r\n\r\nMax clients:";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(462, 36);
            this.numPort.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(67, 20);
            this.numPort.TabIndex = 6;
            this.numPort.Value = new decimal(new int[] {
            10085,
            0,
            0,
            0});
            // 
            // btnTurnServerOff
            // 
            this.btnTurnServerOff.Enabled = false;
            this.btnTurnServerOff.Location = new System.Drawing.Point(524, 196);
            this.btnTurnServerOff.Name = "btnTurnServerOff";
            this.btnTurnServerOff.Size = new System.Drawing.Size(80, 40);
            this.btnTurnServerOff.TabIndex = 4;
            this.btnTurnServerOff.Text = "Turn Off";
            this.btnTurnServerOff.UseVisualStyleBackColor = true;
            this.btnTurnServerOff.Click += new System.EventHandler(this.btnTurnServerOff_Click);
            // 
            // btnTurnServerOn
            // 
            this.btnTurnServerOn.Location = new System.Drawing.Point(381, 196);
            this.btnTurnServerOn.Name = "btnTurnServerOn";
            this.btnTurnServerOn.Size = new System.Drawing.Size(80, 40);
            this.btnTurnServerOn.TabIndex = 3;
            this.btnTurnServerOn.Text = "Turn On";
            this.btnTurnServerOn.UseVisualStyleBackColor = true;
            this.btnTurnServerOn.Click += new System.EventHandler(this.btnTurnServerOn_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(565, 361);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(244, 23);
            this.btnClearLog.TabIndex = 5;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
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
            this.tabControl.Size = new System.Drawing.Size(813, 355);
            this.tabControl.TabIndex = 2;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.gbxServer);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(805, 329);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.btnClearWindow);
            this.tabView.Controls.Add(this.gbxAllowedKeys);
            this.tabView.Controls.Add(this.lblCurrentWindow);
            this.tabView.Controls.Add(this.label5);
            this.tabView.Controls.Add(this.btnSelectWindow);
            this.tabView.Controls.Add(this.chbxStopAllInput);
            this.tabView.Controls.Add(this.btnClearChat);
            this.tabView.Controls.Add(this.rtbxChat);
            this.tabView.Location = new System.Drawing.Point(4, 22);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(3);
            this.tabView.Size = new System.Drawing.Size(805, 329);
            this.tabView.TabIndex = 1;
            this.tabView.Text = "View";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // btnClearWindow
            // 
            this.btnClearWindow.Location = new System.Drawing.Point(125, 300);
            this.btnClearWindow.Name = "btnClearWindow";
            this.btnClearWindow.Size = new System.Drawing.Size(111, 23);
            this.btnClearWindow.TabIndex = 18;
            this.btnClearWindow.Text = "Clear window";
            this.btnClearWindow.UseVisualStyleBackColor = true;
            this.btnClearWindow.Click += new System.EventHandler(this.btnClearWindow_Click);
            // 
            // gbxAllowedKeys
            // 
            this.gbxAllowedKeys.Controls.Add(this.gbxViewClient);
            this.gbxAllowedKeys.Controls.Add(this.lbxClients);
            this.gbxAllowedKeys.Location = new System.Drawing.Point(8, 33);
            this.gbxAllowedKeys.Name = "gbxAllowedKeys";
            this.gbxAllowedKeys.Size = new System.Drawing.Size(547, 241);
            this.gbxAllowedKeys.TabIndex = 17;
            this.gbxAllowedKeys.TabStop = false;
            this.gbxAllowedKeys.Text = "Allowed Keys";
            // 
            // gbxViewClient
            // 
            this.gbxViewClient.Controls.Add(this.label6);
            this.gbxViewClient.Controls.Add(this.numClientMinimumTime);
            this.gbxViewClient.Controls.Add(this.btnBan);
            this.gbxViewClient.Controls.Add(this.btnAddAll);
            this.gbxViewClient.Controls.Add(this.btnUpdateKeyList);
            this.gbxViewClient.Controls.Add(this.btnAllowedKeysRemoveAll);
            this.gbxViewClient.Controls.Add(this.btnAllowedKeysRemove);
            this.gbxViewClient.Controls.Add(this.btnAllowedKeysAdd);
            this.gbxViewClient.Controls.Add(this.lbxAllowedKeys);
            this.gbxViewClient.Controls.Add(this.cbxAllowedKeys);
            this.gbxViewClient.Controls.Add(this.btnKick);
            this.gbxViewClient.Controls.Add(this.chbxAllowInput);
            this.gbxViewClient.Enabled = false;
            this.gbxViewClient.Location = new System.Drawing.Point(187, 18);
            this.gbxViewClient.Name = "gbxViewClient";
            this.gbxViewClient.Size = new System.Drawing.Size(348, 217);
            this.gbxViewClient.TabIndex = 21;
            this.gbxViewClient.TabStop = false;
            this.gbxViewClient.Text = "Client";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 26);
            this.label6.TabIndex = 34;
            this.label6.Text = "Minimum time\r\nin milliseconds";
            // 
            // numClientMinimumTime
            // 
            this.numClientMinimumTime.Location = new System.Drawing.Point(17, 85);
            this.numClientMinimumTime.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.numClientMinimumTime.Name = "numClientMinimumTime";
            this.numClientMinimumTime.Size = new System.Drawing.Size(71, 20);
            this.numClientMinimumTime.TabIndex = 33;
            this.numClientMinimumTime.ValueChanged += new System.EventHandler(this.numClientMinimumTime_ValueChanged);
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(6, 188);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(75, 23);
            this.btnBan.TabIndex = 30;
            this.btnBan.Text = "Ban";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(252, 51);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 23);
            this.btnAddAll.TabIndex = 29;
            this.btnAddAll.Text = "Add all";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnUpdateKeyList
            // 
            this.btnUpdateKeyList.Location = new System.Drawing.Point(252, 80);
            this.btnUpdateKeyList.Name = "btnUpdateKeyList";
            this.btnUpdateKeyList.Size = new System.Drawing.Size(75, 73);
            this.btnUpdateKeyList.TabIndex = 28;
            this.btnUpdateKeyList.Text = "Update to Client";
            this.btnUpdateKeyList.UseVisualStyleBackColor = true;
            this.btnUpdateKeyList.Click += new System.EventHandler(this.btnUpdateKeyList_Click);
            // 
            // btnAllowedKeysRemoveAll
            // 
            this.btnAllowedKeysRemoveAll.Location = new System.Drawing.Point(252, 159);
            this.btnAllowedKeysRemoveAll.Name = "btnAllowedKeysRemoveAll";
            this.btnAllowedKeysRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnAllowedKeysRemoveAll.TabIndex = 27;
            this.btnAllowedKeysRemoveAll.Text = "Remove All";
            this.btnAllowedKeysRemoveAll.UseVisualStyleBackColor = true;
            this.btnAllowedKeysRemoveAll.Click += new System.EventHandler(this.btnAllowedKeysRemoveAll_Click);
            // 
            // btnAllowedKeysRemove
            // 
            this.btnAllowedKeysRemove.Location = new System.Drawing.Point(252, 188);
            this.btnAllowedKeysRemove.Name = "btnAllowedKeysRemove";
            this.btnAllowedKeysRemove.Size = new System.Drawing.Size(75, 23);
            this.btnAllowedKeysRemove.TabIndex = 26;
            this.btnAllowedKeysRemove.Text = "Remove";
            this.btnAllowedKeysRemove.UseVisualStyleBackColor = true;
            this.btnAllowedKeysRemove.Click += new System.EventHandler(this.btnAllowedKeysRemove_Click);
            // 
            // btnAllowedKeysAdd
            // 
            this.btnAllowedKeysAdd.Location = new System.Drawing.Point(252, 24);
            this.btnAllowedKeysAdd.Name = "btnAllowedKeysAdd";
            this.btnAllowedKeysAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAllowedKeysAdd.TabIndex = 25;
            this.btnAllowedKeysAdd.Text = "Add";
            this.btnAllowedKeysAdd.UseVisualStyleBackColor = true;
            this.btnAllowedKeysAdd.Click += new System.EventHandler(this.btnAllowedKeysAdd_Click);
            // 
            // lbxAllowedKeys
            // 
            this.lbxAllowedKeys.FormattingEnabled = true;
            this.lbxAllowedKeys.Location = new System.Drawing.Point(106, 51);
            this.lbxAllowedKeys.Name = "lbxAllowedKeys";
            this.lbxAllowedKeys.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxAllowedKeys.Size = new System.Drawing.Size(140, 160);
            this.lbxAllowedKeys.TabIndex = 23;
            // 
            // cbxAllowedKeys
            // 
            this.cbxAllowedKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAllowedKeys.FormattingEnabled = true;
            this.cbxAllowedKeys.Location = new System.Drawing.Point(106, 25);
            this.cbxAllowedKeys.Name = "cbxAllowedKeys";
            this.cbxAllowedKeys.Size = new System.Drawing.Size(140, 21);
            this.cbxAllowedKeys.TabIndex = 24;
            // 
            // btnKick
            // 
            this.btnKick.Location = new System.Drawing.Point(6, 159);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(75, 23);
            this.btnKick.TabIndex = 22;
            this.btnKick.Text = "Kick";
            this.btnKick.UseVisualStyleBackColor = true;
            this.btnKick.Click += new System.EventHandler(this.btnKick_Click);
            // 
            // chbxAllowInput
            // 
            this.chbxAllowInput.AutoSize = true;
            this.chbxAllowInput.Location = new System.Drawing.Point(10, 27);
            this.chbxAllowInput.Name = "chbxAllowInput";
            this.chbxAllowInput.Size = new System.Drawing.Size(78, 17);
            this.chbxAllowInput.TabIndex = 21;
            this.chbxAllowInput.Text = "Allow Input";
            this.chbxAllowInput.UseVisualStyleBackColor = true;
            this.chbxAllowInput.CheckedChanged += new System.EventHandler(this.chbxAllowInput_CheckedChanged);
            // 
            // lbxClients
            // 
            this.lbxClients.FormattingEnabled = true;
            this.lbxClients.Location = new System.Drawing.Point(6, 23);
            this.lbxClients.Name = "lbxClients";
            this.lbxClients.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxClients.Size = new System.Drawing.Size(175, 212);
            this.lbxClients.TabIndex = 3;
            this.lbxClients.SelectedIndexChanged += new System.EventHandler(this.lbxClients_SelectedIndexChanged);
            // 
            // lblCurrentWindow
            // 
            this.lblCurrentWindow.AutoSize = true;
            this.lblCurrentWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentWindow.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCurrentWindow.Location = new System.Drawing.Point(134, 277);
            this.lblCurrentWindow.Name = "lblCurrentWindow";
            this.lblCurrentWindow.Size = new System.Drawing.Size(47, 20);
            this.lblCurrentWindow.TabIndex = 12;
            this.lblCurrentWindow.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Current window:";
            // 
            // btnSelectWindow
            // 
            this.btnSelectWindow.Location = new System.Drawing.Point(8, 300);
            this.btnSelectWindow.Name = "btnSelectWindow";
            this.btnSelectWindow.Size = new System.Drawing.Size(111, 23);
            this.btnSelectWindow.TabIndex = 10;
            this.btnSelectWindow.Text = "Select window";
            this.btnSelectWindow.UseVisualStyleBackColor = true;
            this.btnSelectWindow.Click += new System.EventHandler(this.btnSelectWindow_Click);
            // 
            // chbxStopAllInput
            // 
            this.chbxStopAllInput.AutoSize = true;
            this.chbxStopAllInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxStopAllInput.Location = new System.Drawing.Point(8, 6);
            this.chbxStopAllInput.Name = "chbxStopAllInput";
            this.chbxStopAllInput.Size = new System.Drawing.Size(120, 24);
            this.chbxStopAllInput.TabIndex = 9;
            this.chbxStopAllInput.Text = "Stop all input";
            this.chbxStopAllInput.UseVisualStyleBackColor = true;
            this.chbxStopAllInput.CheckedChanged += new System.EventHandler(this.chbxStopAllInput_CheckedChanged);
            // 
            // btnClearChat
            // 
            this.btnClearChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearChat.Location = new System.Drawing.Point(561, 7);
            this.btnClearChat.Name = "btnClearChat";
            this.btnClearChat.Size = new System.Drawing.Size(238, 23);
            this.btnClearChat.TabIndex = 8;
            this.btnClearChat.Text = "Clear";
            this.btnClearChat.UseVisualStyleBackColor = true;
            this.btnClearChat.Click += new System.EventHandler(this.btnClearChat_Click);
            // 
            // rtbxChat
            // 
            this.rtbxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxChat.Location = new System.Drawing.Point(561, 33);
            this.rtbxChat.Name = "rtbxChat";
            this.rtbxChat.ReadOnly = true;
            this.rtbxChat.Size = new System.Drawing.Size(238, 291);
            this.rtbxChat.TabIndex = 8;
            this.rtbxChat.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server status:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblServerStatus.Location = new System.Drawing.Point(132, 367);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(55, 20);
            this.lblServerStatus.TabIndex = 7;
            this.lblServerStatus.Text = "Offline";
            // 
            // InputHiveServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 527);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.rtbxLog);
            this.Controls.Add(this.btnClearLog);
            this.Name = "InputHiveServerForm";
            this.Text = "Input Hive Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputHiveServerForm_FormClosing);
            this.gbxServer.ResumeLayout(false);
            this.gbxServer.PerformLayout();
            this.gbxSetupAllowedKeys.ResumeLayout(false);
            this.gbxSetupAllowedKeys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetupDefaultMinimumTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabView.ResumeLayout(false);
            this.tabView.PerformLayout();
            this.gbxAllowedKeys.ResumeLayout(false);
            this.gbxViewClient.ResumeLayout(false);
            this.gbxViewClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClientMinimumTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbxLog;
        private System.Windows.Forms.GroupBox gbxServer;
        private System.Windows.Forms.Button btnTurnServerOff;
        private System.Windows.Forms.Button btnTurnServerOn;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.ListBox lbxClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxIpAddress;
        private System.Windows.Forms.Button btnClearChat;
        private System.Windows.Forms.RichTextBox rtbxChat;
        private System.Windows.Forms.CheckBox chbxAllowConnections;
        private System.Windows.Forms.NumericUpDown numMaxClients;
        private System.Windows.Forms.CheckBox chbxStopAllInput;
        private System.Windows.Forms.Label lblCurrentWindow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectWindow;
        private System.Windows.Forms.GroupBox gbxAllowedKeys;
        private System.Windows.Forms.GroupBox gbxViewClient;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnUpdateKeyList;
        private System.Windows.Forms.Button btnAllowedKeysRemoveAll;
        private System.Windows.Forms.Button btnAllowedKeysRemove;
        private System.Windows.Forms.Button btnAllowedKeysAdd;
        private System.Windows.Forms.ListBox lbxAllowedKeys;
        private System.Windows.Forms.ComboBox cbxAllowedKeys;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.CheckBox chbxAllowInput;
        private System.Windows.Forms.GroupBox gbxSetupAllowedKeys;
        private System.Windows.Forms.Button btnSetupDefaultKeysAddAll;
        private System.Windows.Forms.Button btnSetupAllowedKeysRemoveAll;
        private System.Windows.Forms.Button btnSetupAllowedKeysRemove;
        private System.Windows.Forms.Button btnSetupDefaultKeysAdd;
        private System.Windows.Forms.ListBox lbxSetupDefaultKeys;
        private System.Windows.Forms.ComboBox cbxSetupDefaultKeys;
        private System.Windows.Forms.CheckBox chbxSetupDefaultKeysAllowInput;
        private System.Windows.Forms.CheckBox chbxLogAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSetupDefaultMinimumTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numClientMinimumTime;
        private System.Windows.Forms.Button btnClearWindow;
    }
}

