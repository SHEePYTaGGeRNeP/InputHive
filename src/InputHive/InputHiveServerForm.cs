using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using InputHive.Classes;
using InputHive.Classes.Communication;
using Timer = System.Windows.Forms.Timer;

namespace InputHive
{
    public partial class InputHiveServerForm : Form
    {
        private readonly InputHiveServerSystem _hiveServerSystem;
        private HiveCommunicationServerClient _selectedClient;

        public static Queue<string> LoggingQueue = new Queue<string>();
        public static Queue<string> ChatQueue = new Queue<string>();

        private const string _VERSION = "V 1.0";

        private void InputHiveServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hiveServerSystem.TurnServerOff();
        }
        public InputHiveServerForm()
        {
            InitializeComponent();
            this.Text = "Input Hive Server " + _VERSION;
            Timer lvThreadTimer = new Timer { Interval = 500 };
            lvThreadTimer.Tick += ThreadTimerOnTick;
            lvThreadTimer.Start();
            FillAllowedKeys();
            _hiveServerSystem = new InputHiveServerSystem(chbxLogAll.Checked,
                !chbxStopAllInput.Checked,(int)numSetupDefaultMinimumTime.Value, chbxSetupDefaultKeysAllowInput.Checked );
            _hiveServerSystem.UpdateClientEvent += HiveServerSystemOnUpdateClientEvent;
        }

        private void HiveServerSystemOnUpdateClientEvent()
        {
            lbxClients.Invoke((MethodInvoker)(() =>
            {
                lbxClients.Items.Clear();
                foreach (HiveCommunicationServerClient lvClient in _hiveServerSystem.Server.Clients)
                    lbxClients.Items.Add(lvClient.ToString());
            }));
        }


        private void ThreadTimerOnTick(object pSender, EventArgs pEventArgs)
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

        private void FillAllowedKeys()
        {
            foreach (Keys lvK in Enum.GetValues(typeof(Keys)))
            {
                cbxAllowedKeys.Items.Add(lvK);
                cbxSetupDefaultKeys.Items.Add(lvK);
            }
        }


        #region # # # # # # # # # # # # # # # #   S e t u p   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e n t s   # # # # # # # # # # # # # # # #
        private void btnTurnServerOn_Click(object sender, EventArgs e)
        {
            try
            {
                _hiveServerSystem.TurnServerOn((int)numPort.Value, tbxIpAddress.Text, (int)numMaxClients.Value,
                    chbxAllowConnections.Checked);
                UpdateUiServerOn();
            }
            catch (Exception lvException)
            {
                MessageBox.Show("Error when turning server on:\n" + lvException.Message, "Server error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTurnServerOff_Click(object sender, EventArgs e)
        {
            try
            {
                _hiveServerSystem.TurnServerOff();
                UpdateUiServerOff();
            }
            catch (Exception lvException)
            {
                MessageBox.Show("Error when turning server off:\n" + lvException.Message, "Server error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numMaxClients_ValueChanged(object sender, EventArgs e)
        {
            _hiveServerSystem.Server.MaximumClients = (int)numMaxClients.Value;
        }
        private void chbxAllowConnections_CheckedChanged(object sender, EventArgs e)
        {
            _hiveServerSystem.Server.AllowConnections = chbxAllowConnections.Checked;
        }

        private void btnSetupDefaultKeysAdd_Click(object sender, EventArgs e)
        {
            AddKeyToDefaultList(cbxSetupDefaultKeys.Text);
        }
        private void btnSetupDefaultKeysAddAll_Click(object sender, EventArgs e)
        {
            foreach (var lvKey in cbxSetupDefaultKeys.Items)
                AddKeyToDefaultList(lvKey.ToString());
        }
        private void btnSetupAllowedKeysRemoveAll_Click(object sender, EventArgs e)
        {
            lbxSetupDefaultKeys.Items.Clear();
            _hiveServerSystem.DefaultAllowedKeys.Clear();
        }
        private void btnSetupAllowedKeysRemove_Click(object sender, EventArgs e)
        {
            List<string> lvList = new List<string>();
            if (lbxSetupDefaultKeys.SelectedItems.Count > 0)
                foreach (string lvKey in lbxSetupDefaultKeys.SelectedItems)
                    lvList.Add(lvKey);
            foreach (string lvKey in lvList)
            {
                lbxSetupDefaultKeys.Items.Remove(lvKey);
                _hiveServerSystem.DefaultAllowedKeys.Remove(lvKey);
            }
        }
        
        private void chbxLogAll_CheckedChanged(object sender, EventArgs e)
        {
            _hiveServerSystem.LogAll = chbxLogAll.Checked;
        }
        private void numSetupDefaultMinimumTime_ValueChanged(object sender, EventArgs e)
        {
            _hiveServerSystem.Server.DefaultMinimumTime = (int) numSetupDefaultMinimumTime.Value;
        }
        private void chbxSetupDefaultKeysAllowInput_CheckedChanged(object sender, EventArgs e)
        {
            _hiveServerSystem.Server.DefaultAllowInput = chbxSetupDefaultKeysAllowInput.Checked;
        }
        #endregion

        private void AddKeyToDefaultList(string pKey)
        {
            if (!String.IsNullOrEmpty(pKey) && !lbxSetupDefaultKeys.Items.Contains(pKey))
            {
                lbxSetupDefaultKeys.Items.Add(pKey);
                _hiveServerSystem.AddAllowedKey(pKey);
            }
        }

        #endregion

        #region # # # # # # # # # # # # # # # #   C l i e n t   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e n t s   # # # # # # # # # # # # # # # #

        private void btnAllowedKeysAdd_Click(object sender, EventArgs e)
        {
            AddKeyToClientList(cbxAllowedKeys.Text);
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (var lvKey in cbxAllowedKeys.Items)
                AddKeyToClientList(lvKey.ToString());
        }

        private void btnUpdateKeyList_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lvKeys = new string[lbxAllowedKeys.Items.Count];
                for (int lvIndex = 0; lvIndex < lvKeys.Length; lvIndex++)
                    lvKeys[lvIndex] = lbxAllowedKeys.Items[lvIndex].ToString();
                _hiveServerSystem.UpdateKeyListToClient(_selectedClient, lvKeys);
            }
            catch (Exception lvException)
            {
                MessageBox.Show("Error when turning server on:\n" + lvException.Message, "Server error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAllowedKeysRemove_Click(object sender, EventArgs e)
        {
            List<string> lvList = new List<string>();
            if (lbxAllowedKeys.SelectedItems.Count > 0)
                foreach (string lvKey in lbxAllowedKeys.SelectedItems)
                    lvList.Add(lvKey);
            foreach (string lvKey in lvList)
            {
                lbxAllowedKeys.Items.Remove(lvKey);
                _selectedClient.AllowedKeys.Remove(lvKey);
            }
        }
        private void btnAllowedKeysRemoveAll_Click(object sender, EventArgs e)
        {
            lbxAllowedKeys.Items.Clear();
            _selectedClient.AllowedKeys.Clear();
        }


        private void btnSelectWindow_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK ==
                MessageBox.Show(
                    "After you click \"OK\" this dialog you'll have 3 seconds to select the window the keys will be send to",
                    "Select your desired window", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                Thread.Sleep(3000);
                _hiveServerSystem.Window = NativeWin32.GetActiveProcessWindow();
                lblCurrentWindow.Text = _hiveServerSystem.Window.Title;
                if (DialogResult.Yes !=
                    MessageBox.Show("Is " + _hiveServerSystem.Window.Title + " the window you want?",
                        "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    _hiveServerSystem.Window = new NativeWin32.ProcessWindow(new IntPtr(), "nowindowselectedinputhive");
                    lblCurrentWindow.ForeColor = Color.DarkRed;
                    lblCurrentWindow.Text = "None";
                }
                else
                {
                    lblCurrentWindow.ForeColor = Color.Green;
                    lblCurrentWindow.Text = _hiveServerSystem.Window.Title;
                }
            }
        }
        private void btnClearWindow_Click(object sender, EventArgs e)
        {
            _hiveServerSystem.Window = new NativeWin32.ProcessWindow(new IntPtr(), "nowindowselectedinputhive");
            lblCurrentWindow.ForeColor = Color.DarkRed;
            lblCurrentWindow.Text = "None";
        }

        private void chbxStopAllInput_CheckedChanged(object sender, EventArgs e)
        {
            _hiveServerSystem.AllowInput = !chbxStopAllInput.Checked;
        }

        private void chbxAllowInput_CheckedChanged(object sender, EventArgs e)
        {
            _selectedClient.AllowInput = chbxAllowInput.Checked;
        }

        private void btnKick_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to kick this client?\n"
                + _selectedClient, "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                _hiveServerSystem.Server.KickClient(_selectedClient);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to ban this client?\n"
                + _selectedClient, "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                if (DialogResult.Yes == MessageBox.Show("There is no unbanning feature at the moment.\nAre you very sure?",
                    "Are you very sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                    _hiveServerSystem.Server.BanClient(_selectedClient);
        }

        private void lbxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxAllowedKeys.Items.Clear();
            if (lbxClients.SelectedItem != null)
            {
                _selectedClient = _hiveServerSystem.Server.FindClientByString(lbxClients.SelectedItem.ToString());
                UpdateUiSelectedClient();
            }
            else
            {
                _selectedClient = null;
                gbxViewClient.Enabled = false;
            }
        }

        private void numClientMinimumTime_ValueChanged(object sender, EventArgs e)
        {
            _selectedClient.MinimumTime = (int) numClientMinimumTime.Value;
        }

        #endregion


        private void AddKeyToClientList(string pKey)
        {
            if (!String.IsNullOrEmpty(pKey) && !lbxAllowedKeys.Items.Contains(pKey))
            {
                lbxAllowedKeys.Items.Add(pKey);
                _selectedClient.AddAllowedKey(pKey);
            }
        }




        #endregion


        #region # # # # # # # # # # # # # # # #   U s e r   I n t e r f a c e   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e nt s   # # # # # # # # # # # # # # # #

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbxLog.Clear();
        }
        private void btnClearChat_Click(object sender, EventArgs e)
        {
            rtbxChat.Clear();
        }

        #endregion

        private void UpdateUiServerOn()
        {
            lblServerStatus.ForeColor = Color.Green;
            lblServerStatus.Text = string.Format("Online on: IP:{0} | Port: {1}", _hiveServerSystem.Server.IpAdres,
                _hiveServerSystem.Server.ServerPort);
            btnTurnServerOn.Enabled = false;
            btnTurnServerOff.Enabled = true;
            numPort.ReadOnly = true;
            tbxIpAddress.ReadOnly = true;
            tbxIpAddress.Text = _hiveServerSystem.Server.IpAdres;
        }
        private void UpdateUiServerOff()
        {
            lblServerStatus.ForeColor = Color.DarkRed;
            lblServerStatus.Text = "Offline";
            btnTurnServerOn.Enabled = true;
            btnTurnServerOff.Enabled = false;
            numPort.ReadOnly = false;
            tbxIpAddress.ReadOnly = false;
        }

        private void UpdateUiSelectedClient()
        {
            gbxViewClient.Invoke((MethodInvoker)(() =>
            { gbxViewClient.Enabled = true; }));
            chbxAllowInput.Invoke((MethodInvoker)(() =>
            { chbxAllowInput.Checked = _selectedClient.AllowInput; }));
            lbxAllowedKeys.Invoke((MethodInvoker)(() =>
            {
                foreach (string lvKey in _selectedClient.AllowedKeys)
                    lbxAllowedKeys.Items.Add(lvKey);
            }));
            numClientMinimumTime.Invoke((MethodInvoker) (() =>
            {
                numClientMinimumTime.Value = _selectedClient.MinimumTime;
            }));

        }

        #endregion





























    }
}
