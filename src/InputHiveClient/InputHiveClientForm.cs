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

        private const string _VERSION = "V 1.0";

        public InputHiveClientForm()
        {
            InitializeComponent();
            this.Text = "Input Hive " + _VERSION;
            Timer lvTimer = new Timer { Interval = 500 };
            lvTimer.Tick += TimerOnTick;
            lvTimer.Start();
            _hiveClientSystem = new InputHiveClientSystem(new HiveCommunicationClient());
            _hiveClientSystem.OnUsernameConfirmed += HiveClientSystemOnOnUsernameConfirmed;
            _hiveClientSystem.OnKeylistUpdate += HiveClientSystemOnOnKeylistUpdate;
        }



        private void TimerOnTick(object pSender, EventArgs pEventArgs)
        {
            while (LoggingQueue.Count > 0)
            {
                rtbxLog.AppendText(LoggingQueue.Dequeue() + "\n");
                rtbxLog.SelectionStart = rtbxLog.Text.Length;
                rtbxLog.ScrollToCaret();
            }
            while (ChatQueue.Count > 0)
            {
                rtbxChat.AppendText(ChatQueue.Dequeue() + "\n");
                rtbxChat.SelectionStart = rtbxChat.Text.Length;
                rtbxChat.ScrollToCaret();
            }
        }


        private void HiveClientSystemOnOnUsernameConfirmed()
        {
            UpdateUiConnected();
        }

        private void InputHiveClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hiveClientSystem.Client.Disconnect();
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
                if (String.IsNullOrEmpty(tbxServerIp.Text))
                {
                    MessageBox.Show("IP Address cannot be empty", "Not all fields are filled in", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                if (String.IsNullOrEmpty(tbxUsername.Text))
                    MessageBox.Show("Username cannot be empty", "Not all fields are filled in", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else if (tbxUsername.Text.ToLower() == "server")
                    MessageBox.Show("Server is not allowed as a username", "Cheeky bastard", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                {
                    _hiveClientSystem.Connect(tbxServerIp.Text, (int)numServerPort.Value, tbxUsername.Text);
                    _hiveClientSystem.Client.ClientInformation.Disconnected += delegate { UpdateUiDisconnected(); };
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
                _hiveClientSystem.Disconnect();
                UpdateUiDisconnected();
            }
            catch (Exception lvException)
            {
                MessageBox.Show("Error trying to disconnect from the server:\n" + lvException.Message, "Connection error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxChatMessage.Text))
            {
                _hiveClientSystem.SendChatMessage(tbxChatMessage.Text);
                tbxChatMessage.Clear();
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
            AddKeyToList(cbxAllowedKeys.Text);
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (var lvKey in cbxAllowedKeys.Items)
                AddKeyToList(lvKey.ToString());
        }

        private void btnAllowedKeysRemoveAll_Click(object sender, EventArgs e)
        {
            lbxSendingKeys.Items.Clear();
        }
        private void btnAllowedKeysRemove_Click(object sender, EventArgs e)
        {
            List<string> lvList = new List<string>();
            if (lbxSendingKeys.SelectedItems.Count > 0)
                foreach (string lvKey in lbxSendingKeys.SelectedItems)
                    lvList.Add(lvKey);
            foreach (string lvKey in lvList)
            {
                lbxSendingKeys.Items.Remove(lvKey);

            }
        }


        private void tbxSendKey_KeyDown(object sender, KeyEventArgs e)
        {
            string lvKeyString = char.ToUpper((char)e.KeyCode).ToString();
            SendKey(lvKeyString);
            tbxSendKey.Clear();
        }

        #endregion

        private void AddKeyToList(string pKey)
        {
            if (!String.IsNullOrEmpty(pKey) && !lbxSendingKeys.Items.Contains(pKey))
                lbxSendingKeys.Items.Add(pKey);
        }

        private void HiveClientSystemOnOnKeylistUpdate()
        {
            cbxAllowedKeys.Invoke((MethodInvoker)(() =>
            {
                cbxAllowedKeys.Items.Clear();
                foreach (string lvKey in _hiveClientSystem.Client.AllowedKeys)
                    cbxAllowedKeys.Items.Add(lvKey);
            }));

        }
        #endregion


        #region # # # # # # # # # # # # # # # #   U s e r   I n t e r f a c e   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e nt s   # # # # # # # # # # # # # # # #



        private void btnClearLog_Click(object sender, System.EventArgs e)
        {
            rtbxLog.Clear();
        }
        private void btnClearChat_Click(object sender, System.EventArgs e)
        {
            rtbxChat.Clear();
        }


        #endregion

        /// <summary>
        /// TODO: Kijken hoe het zit met muis
        /// </summary>
        /// <param name="e"></param>
        private void SendKey(string pKey)
        {
            if (_hiveClientSystem.Client.UsernameConfirmed == true)
            {
                if (lbxSendingKeys.Items.Contains(pKey.ToString()))
                {
                    _hiveClientSystem.SendKey(pKey);
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
            lblConnectionStatus.Invoke((MethodInvoker)(() =>
            {
                lblConnectionStatus.ForeColor = Color.Green;
                lblConnectionStatus.Text = string.Format("Connected to: IP:{0} | Port: {1}",
                    tbxServerIp.Text, numServerPort.Value);
            }));
            btnSendMessage.Invoke((MethodInvoker)(() =>
            { btnSendMessage.Enabled = true; }));
            btnClearChat.Invoke((MethodInvoker)(() =>
            { btnClearChat.Enabled = true; }));
            btnDisconnect.Invoke((MethodInvoker)(() =>
            { btnDisconnect.Enabled = true; }));
            btnConnect.Invoke((MethodInvoker)(() =>
            { btnConnect.Enabled = false; }));
            tbxChatMessage.Invoke((MethodInvoker)(() =>
            { tbxChatMessage.ReadOnly = false; }));
            tbxUsername.Invoke((MethodInvoker)(() =>
            { tbxUsername.Enabled = true; }));
            tbxServerIp.Invoke((MethodInvoker)(() =>
            { tbxServerIp.ReadOnly = true; }));
            tbxUsername.Invoke((MethodInvoker)(() =>
            { tbxUsername.ReadOnly = true; }));
            numServerPort.Invoke((MethodInvoker)(() =>
            { numServerPort.ReadOnly = true; }));
            tbxSendKey.Invoke((MethodInvoker)(() =>
            {
                tbxSendKey.Enabled = true;
                tbxSendKey.BackColor = Color.LawnGreen;
            }));
            this.Invoke((MethodInvoker) (() =>
            {
                this.Text = String.Format("Input Hive Client {0} - Connected with: {1} as {2}",
                   _VERSION, tbxServerIp.Text,_hiveClientSystem.Client.Username);
            }));
        }
        private void UpdateUiDisconnected()
        {
            lblConnectionStatus.Invoke((MethodInvoker)(() =>
            {
                lblConnectionStatus.ForeColor = Color.DarkRed;
                lblConnectionStatus.Text = "Offline";
            }));
            btnSendMessage.Invoke((MethodInvoker)(() =>
            { btnSendMessage.Enabled = false; }));
            btnClearChat.Invoke((MethodInvoker)(() =>
            { btnClearChat.Enabled = false; }));
            btnDisconnect.Invoke((MethodInvoker)(() =>
            { btnDisconnect.Enabled = false; }));
            btnConnect.Invoke((MethodInvoker)(() =>
            { btnConnect.Enabled = true; }));
            tbxChatMessage.Invoke((MethodInvoker)(() =>
            { tbxChatMessage.ReadOnly = true; }));
            tbxUsername.Invoke((MethodInvoker)(() =>
            { tbxUsername.Enabled = false; }));
            tbxServerIp.Invoke((MethodInvoker)(() =>
            { tbxServerIp.ReadOnly = false; }));
            tbxUsername.Invoke((MethodInvoker)(() =>
            { tbxUsername.ReadOnly = false; }));
            numServerPort.Invoke((MethodInvoker)(() =>
            { numServerPort.ReadOnly = false; }));
            tbxSendKey.Invoke((MethodInvoker)(() =>
            {
                tbxSendKey.Enabled = false;
                tbxSendKey.BackColor = Color.DarkRed;
            }));
            this.Invoke((MethodInvoker)(() =>
            {
                this.Text = "Input Hive Client " + _VERSION;
            }));
        }


        #endregion







    }
}
