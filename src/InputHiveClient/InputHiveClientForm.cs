using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InputHiveClient.Classes;
using InputHiveClient.Classes.Communication;

namespace InputHiveClient
{
    public partial class InputHiveClientForm : Form
    {
        public static Queue<string> LoggingQueue = new Queue<string>();
        public static Queue<string> ChatQueue = new Queue<string>();
        private readonly InputHiveClientSystem _hiveClientSystem;

        private const string _VERSION = "V 1.1";

        public InputHiveClientForm()
        {
            this.InitializeComponent();
            this.Text = "Input Hive Client " + _VERSION;
            Timer lvTimer = new Timer { Interval = 500 };
            lvTimer.Tick += this.TimerOnTick;
            lvTimer.Start();
            this._hiveClientSystem = new InputHiveClientSystem(new HiveCommunicationClient());
            this._hiveClientSystem.OnUsernameConfirmed += this.HiveClientSystemOnOnUsernameConfirmed;
            this._hiveClientSystem.OnKeylistUpdate += this.HiveClientSystemOnOnKeylistUpdate;
        }



        private void TimerOnTick(object pSender, EventArgs pEventArgs)
        {
            while (LoggingQueue.Count > 0)
            {
                this.rtbxLog.AppendText(LoggingQueue.Dequeue() + "\n");
                this.rtbxLog.SelectionStart = this.rtbxLog.Text.Length;
                this.rtbxLog.ScrollToCaret();
            }
            while (ChatQueue.Count > 0)
            {
                this.rtbxChat.AppendText(ChatQueue.Dequeue() + "\n");
                this.rtbxChat.SelectionStart = this.rtbxChat.Text.Length;
                this.rtbxChat.ScrollToCaret();
            }
        }


        private void HiveClientSystemOnOnUsernameConfirmed()
        {
            this.UpdateUiConnected();
        }

        private void InputHiveClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._hiveClientSystem.Client.Disconnect();
        }

        private void InputHiveClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Keydown works !?");
            //SendKey(e);
        }

        public static void ShowMessageBox(string pText, string pTitle, MessageBoxButtons pButtons, MessageBoxIcon pIcon)
        {
            MessageBox.Show(pText, pTitle, pButtons, pIcon);
        }

        #region # # # # # # # # # # # # # # # #   C l i e n t   # # # # # # # # # # # # # # # #


        #region # # # # # # # # # # # # # # # #   E v e n t s   # # # # # # # # # # # # # # # #

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (String.IsNullOrEmpty(this.tbxServerIp.Text))
                {
                    MessageBox.Show("IP Address cannot be empty", "Not all fields are filled in", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                if (String.IsNullOrEmpty(this.tbxUsername.Text))
                    MessageBox.Show("Username cannot be empty", "Not all fields are filled in", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else if (this.tbxUsername.Text.ToLower() == "server")
                    MessageBox.Show("Server is not allowed as a username", "Cheeky bastard", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                {
                    this._hiveClientSystem.Connect(this.tbxServerIp.Text, (int)this.numServerPort.Value, this.tbxUsername.Text);
                    this._hiveClientSystem.Client.ClientInformation.Disconnected += delegate { this.UpdateUiDisconnected(); };
                }
            }
            catch (Exception lvException)
            {
                MessageBox.Show("Error trying to connect to the server:\n" + lvException.Message, "Connection error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                this._hiveClientSystem.Disconnect();
                this.UpdateUiDisconnected();
            }
            catch (Exception lvException)
            {
                MessageBox.Show("Error trying to disconnect from the server:\n" + lvException.Message, "Connection error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbxChatMessage.Text))
            {
                this._hiveClientSystem.SendChatMessage(this.tbxChatMessage.Text);
                this.tbxChatMessage.Clear();
            }
            else
                MessageBox.Show("Please fill in your message.", "Empty message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        #endregion

        #endregion

        #region # # # # # # # # # # # # # # # #   K e y s   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e n t s   # # # # # # # # # # # # # # # #
        private void btnAllowedKeysAdd_Click(object sender, EventArgs e)
        {
            this.AddKeyToList(this.cbxAllowedKeys.Text);
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (var lvKey in this.cbxAllowedKeys.Items)
                this.AddKeyToList(lvKey.ToString());
        }

        private void btnAllowedKeysRemoveAll_Click(object sender, EventArgs e)
        {
            this.lbxSendingKeys.Items.Clear();
        }
        private void btnAllowedKeysRemove_Click(object sender, EventArgs e)
        {
            List<string> lvList = new List<string>();
            if (this.lbxSendingKeys.SelectedItems.Count > 0)
                foreach (string lvKey in this.lbxSendingKeys.SelectedItems)
                    lvList.Add(lvKey);
            foreach (string lvKey in lvList)
            {
                this.lbxSendingKeys.Items.Remove(lvKey);

            }
        }


        private void tbxSendKey_KeyDown(object sender, KeyEventArgs e)
        {
            string lvKeyString = char.ToUpper((char)e.KeyCode).ToString();
            this.SendKey(lvKeyString);
            this.tbxSendKey.Clear();
        }

        #endregion

        private void AddKeyToList(string pKey)
        {
            if (!String.IsNullOrEmpty(pKey) && !this.lbxSendingKeys.Items.Contains(pKey))
                this.lbxSendingKeys.Items.Add(pKey);
        }

        private void HiveClientSystemOnOnKeylistUpdate()
        {
            this.cbxAllowedKeys.Invoke((MethodInvoker)(() =>
            {
                this.cbxAllowedKeys.Items.Clear();
                foreach (string lvKey in this._hiveClientSystem.Client.AllowedKeys)
                    this.cbxAllowedKeys.Items.Add(lvKey);
            }));

        }
        #endregion


        #region # # # # # # # # # # # # # # # #   U s e r   I n t e r f a c e   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e nt s   # # # # # # # # # # # # # # # #



        private void btnClearLog_Click(object sender, System.EventArgs e)
        {
            this.rtbxLog.Clear();
        }
        private void btnClearChat_Click(object sender, System.EventArgs e)
        {
            this.rtbxChat.Clear();
        }


        #endregion

        /// <summary>
        /// TODO: Kijken hoe het zit met muis
        /// </summary>
        /// <param name="e"></param>
        private void SendKey(string pKey)
        {
            if (this._hiveClientSystem.Client.UsernameConfirmed == true)
            {
                if (this.lbxSendingKeys.Items.Contains(pKey.ToString()))
                {
                    this._hiveClientSystem.SendKey(pKey);
                }
                else
                    LoggingQueue.Enqueue(String.Format("{0} failed to send key {1} - You did not add this key to the list yet.",
                        DateTime.Now, pKey));
            }
            else
                LoggingQueue.Enqueue(String.Format("{0} failed to send key {1} - Username not confirmed.",
                    DateTime.Now, pKey));
        }

        private void UpdateUiConnected()
        {
            this.lblConnectionStatus.Invoke((MethodInvoker)(() =>
            {
                this.lblConnectionStatus.ForeColor = Color.Green;
                this.lblConnectionStatus.Text = string.Format("Connected to: IP:{0} | Port: {1}", this.tbxServerIp.Text, this.numServerPort.Value);
            }));
            this.btnSendMessage.Invoke((MethodInvoker)(() =>
            { this.btnSendMessage.Enabled = true; }));
            this.btnClearChat.Invoke((MethodInvoker)(() =>
            { this.btnClearChat.Enabled = true; }));
            this.btnDisconnect.Invoke((MethodInvoker)(() =>
            { this.btnDisconnect.Enabled = true; }));
            this.btnConnect.Invoke((MethodInvoker)(() =>
            { this.btnConnect.Enabled = false; }));
            this.tbxChatMessage.Invoke((MethodInvoker)(() =>
            { this.tbxChatMessage.ReadOnly = false; }));
            this.tbxUsername.Invoke((MethodInvoker)(() =>
            { this.tbxUsername.Enabled = true; }));
            this.tbxServerIp.Invoke((MethodInvoker)(() =>
            { this.tbxServerIp.ReadOnly = true; }));
            this.tbxUsername.Invoke((MethodInvoker)(() =>
            { this.tbxUsername.ReadOnly = true; }));
            this.numServerPort.Invoke((MethodInvoker)(() =>
            { this.numServerPort.ReadOnly = true; }));
            this.tbxSendKey.Invoke((MethodInvoker)(() =>
            {
                this.tbxSendKey.Enabled = true;
                this.tbxSendKey.BackColor = Color.LawnGreen;
            }));
            this.Invoke((MethodInvoker) (() =>
            {
                this.Text = String.Format("Input Hive Client {0} - Connected with: {1} as {2}",
                   _VERSION, this.tbxServerIp.Text, this._hiveClientSystem.Client.Username);
            }));
        }
        private void UpdateUiDisconnected()
        {
            this.lblConnectionStatus.Invoke((MethodInvoker)(() =>
            {
                this.lblConnectionStatus.ForeColor = Color.DarkRed;
                this.lblConnectionStatus.Text = "Offline";
            }));
            this.btnSendMessage.Invoke((MethodInvoker)(() =>
            { this.btnSendMessage.Enabled = false; }));
            this.btnClearChat.Invoke((MethodInvoker)(() =>
            { this.btnClearChat.Enabled = false; }));
            this.btnDisconnect.Invoke((MethodInvoker)(() =>
            { this.btnDisconnect.Enabled = false; }));
            this.btnConnect.Invoke((MethodInvoker)(() =>
            { this.btnConnect.Enabled = true; }));
            this.tbxChatMessage.Invoke((MethodInvoker)(() =>
            { this.tbxChatMessage.ReadOnly = true; }));
            this.tbxUsername.Invoke((MethodInvoker)(() =>
            { this.tbxUsername.Enabled = false; }));
            this.tbxServerIp.Invoke((MethodInvoker)(() =>
            { this.tbxServerIp.ReadOnly = false; }));
            this.tbxUsername.Invoke((MethodInvoker)(() =>
            { this.tbxUsername.ReadOnly = false; }));
            this.numServerPort.Invoke((MethodInvoker)(() =>
            { this.numServerPort.ReadOnly = false; }));
            this.tbxSendKey.Invoke((MethodInvoker)(() =>
            {
                this.tbxSendKey.Enabled = false;
                this.tbxSendKey.BackColor = Color.DarkRed;
            }));
            this.Invoke((MethodInvoker)(() =>
            {
                this.Text = "Input Hive Client " + _VERSION;
            }));
        }


        #endregion







    }
}
