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

        private const string _VERSION = "V 1.1";

        private void InputHiveServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._hiveServerSystem.TurnServerOff();
        }
        public InputHiveServerForm()
        {
            this.InitializeComponent();
            this.Text = "Input Hive Server " + _VERSION;
            Timer lvThreadTimer = new Timer { Interval = 500 };
            lvThreadTimer.Tick += this.ThreadTimerOnTick;
            lvThreadTimer.Start();
            this.FillAllowedKeys();
            this._hiveServerSystem = new InputHiveServerSystem(this.chbxLogAll.Checked,
                !this.chbxStopAllInput.Checked,(int)this.numSetupDefaultMinimumTime.Value, this.chbxSetupDefaultKeysAllowInput.Checked );
            this._hiveServerSystem.UpdateClientEvent += this.HiveServerSystemOnUpdateClientEvent;
        }

        private void HiveServerSystemOnUpdateClientEvent()
        {
            this.lbxClients.Invoke((MethodInvoker)(() =>
            {
                this.lbxClients.Items.Clear();
                foreach (HiveCommunicationServerClient lvClient in this._hiveServerSystem.Server.Clients)
                    this.lbxClients.Items.Add(lvClient.ToString());
            }));
        }


        private void ThreadTimerOnTick(object pSender, EventArgs pEventArgs)
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

        private void FillAllowedKeys()
        {
            foreach (Keys lvK in Enum.GetValues(typeof(Keys)))
            {
                this.cbxAllowedKeys.Items.Add(lvK);
                this.cbxSetupDefaultKeys.Items.Add(lvK);
            }
        }


        #region # # # # # # # # # # # # # # # #   S e t u p   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e n t s   # # # # # # # # # # # # # # # #
        private void btnTurnServerOn_Click(object sender, EventArgs e)
        {
            try
            {
                this._hiveServerSystem.TurnServerOn((int)this.numPort.Value, this.tbxIpAddress.Text, (int)this.numMaxClients.Value, this.chbxAllowConnections.Checked);
                this.UpdateUiServerOn();
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
                this._hiveServerSystem.TurnServerOff();
                this.UpdateUiServerOff();
            }
            catch (Exception lvException)
            {
                MessageBox.Show("Error when turning server off:\n" + lvException.Message, "Server error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numMaxClients_ValueChanged(object sender, EventArgs e)
        {
            this._hiveServerSystem.Server.MaximumClients = (int)this.numMaxClients.Value;
        }
        private void chbxAllowConnections_CheckedChanged(object sender, EventArgs e)
        {
            this._hiveServerSystem.Server.AllowConnections = this.chbxAllowConnections.Checked;
        }

        private void btnSetupDefaultKeysAdd_Click(object sender, EventArgs e)
        {
            this.AddKeyToDefaultList(this.cbxSetupDefaultKeys.Text);
        }
        private void btnSetupDefaultKeysAddAll_Click(object sender, EventArgs e)
        {
            foreach (var lvKey in this.cbxSetupDefaultKeys.Items)
                this.AddKeyToDefaultList(lvKey.ToString());
        }
        private void btnSetupAllowedKeysRemoveAll_Click(object sender, EventArgs e)
        {
            this.lbxSetupDefaultKeys.Items.Clear();
            this._hiveServerSystem.DefaultAllowedKeys.Clear();
        }
        private void btnSetupAllowedKeysRemove_Click(object sender, EventArgs e)
        {
            List<string> lvList = new List<string>();
            if (this.lbxSetupDefaultKeys.SelectedItems.Count > 0)
                foreach (string lvKey in this.lbxSetupDefaultKeys.SelectedItems)
                    lvList.Add(lvKey);
            foreach (string lvKey in lvList)
            {
                this.lbxSetupDefaultKeys.Items.Remove(lvKey);
                this._hiveServerSystem.DefaultAllowedKeys.Remove(lvKey);
            }
        }
        
        private void chbxLogAll_CheckedChanged(object sender, EventArgs e)
        {
            this._hiveServerSystem.LogAll = this.chbxLogAll.Checked;
        }
        private void numSetupDefaultMinimumTime_ValueChanged(object sender, EventArgs e)
        {
            this._hiveServerSystem.Server.DefaultMinimumTime = (int)this.numSetupDefaultMinimumTime.Value;
        }
        private void chbxSetupDefaultKeysAllowInput_CheckedChanged(object sender, EventArgs e)
        {
            this._hiveServerSystem.Server.DefaultAllowInput = this.chbxSetupDefaultKeysAllowInput.Checked;
        }
        #endregion

        private void AddKeyToDefaultList(string pKey)
        {
            if (!String.IsNullOrEmpty(pKey) && !this.lbxSetupDefaultKeys.Items.Contains(pKey))
            {
                this.lbxSetupDefaultKeys.Items.Add(pKey);
                this._hiveServerSystem.AddAllowedKey(pKey);
            }
        }

        #endregion

        #region # # # # # # # # # # # # # # # #   C l i e n t   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e n t s   # # # # # # # # # # # # # # # #

        private void btnAllowedKeysAdd_Click(object sender, EventArgs e)
        {
            this.AddKeyToClientList(this.cbxAllowedKeys.Text);
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (var lvKey in this.cbxAllowedKeys.Items)
                this.AddKeyToClientList(lvKey.ToString());
        }

        private void btnUpdateKeyList_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lvKeys = new string[this.lbxAllowedKeys.Items.Count];
                for (int lvIndex = 0; lvIndex < lvKeys.Length; lvIndex++)
                    lvKeys[lvIndex] = this.lbxAllowedKeys.Items[lvIndex].ToString();
                this._hiveServerSystem.UpdateKeyListToClient(this._selectedClient, lvKeys);
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
            if (this.lbxAllowedKeys.SelectedItems.Count > 0)
                foreach (string lvKey in this.lbxAllowedKeys.SelectedItems)
                    lvList.Add(lvKey);
            foreach (string lvKey in lvList)
            {
                this.lbxAllowedKeys.Items.Remove(lvKey);
                this._selectedClient.AllowedKeys.Remove(lvKey);
            }
        }
        private void btnAllowedKeysRemoveAll_Click(object sender, EventArgs e)
        {
            this.lbxAllowedKeys.Items.Clear();
            this._selectedClient.AllowedKeys.Clear();
        }


        private void btnSelectWindow_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK ==
                MessageBox.Show(
                    "After you click \"OK\" this dialog you'll have 3 seconds to select the window the keys will be send to",
                    "Select your desired window", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                Thread.Sleep(3000);
                this._hiveServerSystem.Window = NativeWin32.GetActiveProcessWindow();
                this.lblCurrentWindow.Text = this._hiveServerSystem.Window.Title;
                if (DialogResult.Yes !=
                    MessageBox.Show("Is " + this._hiveServerSystem.Window.Title + " the window you want?",
                        "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    this._hiveServerSystem.Window = new NativeWin32.ProcessWindow(new IntPtr(), "nowindowselectedinputhive");
                    this.lblCurrentWindow.ForeColor = Color.DarkRed;
                    this.lblCurrentWindow.Text = "None";
                }
                else
                {
                    this.lblCurrentWindow.ForeColor = Color.Green;
                    this.lblCurrentWindow.Text = this._hiveServerSystem.Window.Title;
                }
            }
        }
        private void btnClearWindow_Click(object sender, EventArgs e)
        {
            this._hiveServerSystem.Window = new NativeWin32.ProcessWindow(new IntPtr(), "nowindowselectedinputhive");
            this.lblCurrentWindow.ForeColor = Color.DarkRed;
            this.lblCurrentWindow.Text = "None";
        }

        private void chbxStopAllInput_CheckedChanged(object sender, EventArgs e)
        {
            this._hiveServerSystem.AllowInput = !this.chbxStopAllInput.Checked;
        }

        private void chbxAllowInput_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedClient.AllowInput = this.chbxAllowInput.Checked;
        }

        private void btnKick_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to kick this client?\n"
                + this._selectedClient, "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                this._hiveServerSystem.Server.KickClient(this._selectedClient);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to ban this client?\n"
                + this._selectedClient, "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                if (DialogResult.Yes == MessageBox.Show("There is no unbanning feature at the moment.\nAre you very sure?",
                    "Are you very sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                    this._hiveServerSystem.Server.BanClient(this._selectedClient);
        }

        private void lbxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbxAllowedKeys.Items.Clear();
            if (this.lbxClients.SelectedItem != null)
            {
                this._selectedClient = this._hiveServerSystem.Server.FindClientByString(this.lbxClients.SelectedItem.ToString());
                this.UpdateUiSelectedClient();
            }
            else
            {
                this._selectedClient = null;
                this.gbxViewClient.Enabled = false;
            }
        }

        private void numClientMinimumTime_ValueChanged(object sender, EventArgs e)
        {
            this._selectedClient.MinimumTime = (int)this.numClientMinimumTime.Value;
        }

        #endregion


        private void AddKeyToClientList(string pKey)
        {
            if (!String.IsNullOrEmpty(pKey) && !this.lbxAllowedKeys.Items.Contains(pKey))
            {
                this.lbxAllowedKeys.Items.Add(pKey);
                this._selectedClient.AddAllowedKey(pKey);
            }
        }




        #endregion


        #region # # # # # # # # # # # # # # # #   U s e r   I n t e r f a c e   # # # # # # # # # # # # # # # #

        #region # # # # # # # # # # # # # # # #   E v e nt s   # # # # # # # # # # # # # # # #

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.rtbxLog.Clear();
        }
        private void btnClearChat_Click(object sender, EventArgs e)
        {
            this.rtbxChat.Clear();
        }

        #endregion

        private void UpdateUiServerOn()
        {
            this.lblServerStatus.ForeColor = Color.Green;
            this.lblServerStatus.Text = string.Format("Online on: IP:{0} | Port: {1}", this._hiveServerSystem.Server.IpAdres, this._hiveServerSystem.Server.ServerPort);
            this.btnTurnServerOn.Enabled = false;
            this.btnTurnServerOff.Enabled = true;
            this.numPort.ReadOnly = true;
            this.tbxIpAddress.ReadOnly = true;
            this.tbxIpAddress.Text = this._hiveServerSystem.Server.IpAdres;
        }
        private void UpdateUiServerOff()
        {
            this.lblServerStatus.ForeColor = Color.DarkRed;
            this.lblServerStatus.Text = "Offline";
            this.btnTurnServerOn.Enabled = true;
            this.btnTurnServerOff.Enabled = false;
            this.numPort.ReadOnly = false;
            this.tbxIpAddress.ReadOnly = false;
        }

        private void UpdateUiSelectedClient()
        {
            this.gbxViewClient.Invoke((MethodInvoker)(() =>
            { this.gbxViewClient.Enabled = true; }));
            this.chbxAllowInput.Invoke((MethodInvoker)(() =>
            { this.chbxAllowInput.Checked = this._selectedClient.AllowInput; }));
            this.lbxAllowedKeys.Invoke((MethodInvoker)(() =>
            {
                foreach (string lvKey in this._selectedClient.AllowedKeys)
                    this.lbxAllowedKeys.Items.Add(lvKey);
            }));
            this.numClientMinimumTime.Invoke((MethodInvoker) (() =>
            {
                this.numClientMinimumTime.Value = this._selectedClient.MinimumTime;
            }));

        }

        #endregion





























    }
}
