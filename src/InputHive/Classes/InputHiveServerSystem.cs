using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Server;
using InputHive.Classes.Communication;

namespace InputHive.Classes
{
    /// <summary>
    /// Gebruikt voor InputHiveServerForm
    /// </summary>
    class InputHiveServerSystem
    {
        public delegate void UpdateClientListHandler();
        public event UpdateClientListHandler UpdateClientEvent;

        public HiveCommunicationServer Server { get; private set; }

        /// <summary>
        /// Window / process in Windows
        /// </summary>
        public NativeWin32.ProcessWindow Window { get; set; }
        public bool LogAll { get; set; }
        public bool AllowInput { get; set; }

        /// <summary>
        /// List of all allowed Keys.ToString()
        /// </summary>
        public List<string> DefaultAllowedKeys { get; private set; }


        /// <summary>
        /// Empty InputHiveServerSystem constructor
        /// </summary>
        public InputHiveServerSystem(bool pLogAll, bool pAllowInput, int pDefaultMinimumTime, bool pDefaultAllowInput)
        {
            this.LogAll = pLogAll;
            this.AllowInput = pAllowInput;

            this.Server = new HiveCommunicationServer(pDefaultMinimumTime, pDefaultAllowInput);
            this.Server.NewMessage += this.ServerOnNewMessage;
            this.Server.UpdateClientEvent += delegate { if (this.UpdateClientEvent != null) this.UpdateClientEvent.Invoke(); };
            this.DefaultAllowedKeys = new List<string>();
        }

        private void ServerOnNewMessage(ScsTextMessage pMessage, IScsServerClient pClient)
        {
            try
            {
                if (this.LogAll == true)
                    InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                        "{0} Received message from: {1} - {2} ", DateTime.Now, this.Server.FindClient(pClient.ClientId), pMessage.Text));
                string[] lvSplit = pMessage.Text.Split(':');
                switch (lvSplit[0].ToLower())
                {
                    case "username":
                        if (this.Server.FindClient(lvSplit[1]) == null && lvSplit[1].ToLower() != "server"
                            && !String.IsNullOrEmpty(lvSplit[1]))
                        {
                            this.Server.FindClient(pClient.ClientId).Username = lvSplit[1];
                            pClient.SendMessage(new ScsTextMessage("username:ok"));
                            this.Server.ChatToAllClients(lvSplit[1] + " joined the server.");
                            InputHiveServerForm.LoggingQueue.Enqueue(String.Format("{0} {1} joined the server.",
                                DateTime.Now, lvSplit[1]));
                            if (this.UpdateClientEvent != null) this.UpdateClientEvent.Invoke();
                            this.UpdateKeyListToClient(this.Server.FindClient(pClient.ClientId), this.DefaultAllowedKeys.ToArray());
                            this.Server.FindClient(pClient.ClientId).AllowedKeys = new List<string>(this.DefaultAllowedKeys);
                        }
                        else
                            pClient.SendMessage(new ScsTextMessage("username:error"));
                        break;
                    case "chat":
                        this.Server.ChatToAllClients(string.Format("{0} {1}: {2}", DateTime.Now, this.Server.FindClient(pClient.ClientId).Username, pMessage.Text.Remove(0, 5)));
                        break;
                    case "key":
                        this.SendKey(lvSplit[1].Trim(), this.Server.FindClient(pClient.ClientId));
                        break;
                    default: throw new Exception();
                }
            }
            catch (Exception lvException)
            {
                InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                    "{0} !-!-! ERROR: Error processing message: {1} from {2}\t\nERROR MESSAGE: {3}", DateTime.Now,
                    pMessage.Text, this.Server.FindClient(pClient.ClientId), lvException.Message));
                //throw new Exception("Error processing message:\n" + pMessage.Text + "\n\n" + lvException.Message);
            }
        }


        /// <summary>
        /// Turn server on
        /// </summary>
        public void TurnServerOn(int pPort, string pIp, int pMaxclients, bool pAllowConnections)
        {
            this.Server.ServerPort = pPort;
            this.Server.IpAdres = pIp;
            this.Server.MaximumClients = pMaxclients;
            this.Server.AllowConnections = pAllowConnections;
            this.Server.TurnServerOn();
        }
        /// <summary>
        /// Turn server off
        /// </summary>
        public void TurnServerOff()
        {
            this.Server.TurnServerOff();
        }


        /// <summary>
        /// Sends keys to a window
        /// </summary>
        /// <param name="pKey">Keys.ToString()</param>
        /// <param name="pClient"></param>
        public void SendKey(string pKey, HiveCommunicationServerClient pClient)
        {
            if (this.IsClientAllowedToSendKey(pKey, pClient))
            {
                InputHiveServerForm.LoggingQueue.Enqueue(String.Format("{0} Send key {1} from {2}",
                    DateTime.Now, pKey, pClient));
                
                // setting active might clear selected element?
                string lvTitle = NativeWin32.GetActiveProcessWindow().Title;
                if (lvTitle != this.Window.Title)
                    NativeWin32.SetForegroundWindow(this.Window.HWnd.ToInt32());

                //IntPtr child = NativeWin32.FindWindowEx(Window.hWnd, new IntPtr(0), "Edit", null);
                SendKeys.SendWait(pKey);
                pClient.ResetCountdown();
            }
        }

        public bool IsClientAllowedToSendKey(string pKey, HiveCommunicationServerClient pClient)
        {
            if (this.AllowInput == true)
            {
                if (pClient.AllowInput == true)
                {
                    // Check if key is allowed in client.AllowedKeys list
                    if (pClient.AllowedKeys.Find(pK => pK == pKey) != null)
                    {
                        if (pClient.MinimumTimeCountdown == 0)
                        {
                            if (this.Window.Title != "nowindowselectedinputhive" && !String.IsNullOrEmpty(this.Window.Title))
                            {
                                return true;
                            }
                            InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                                "{0} A key was sent from {1} but no window was set.", DateTime.Now, pClient));
                        }
                        else
                        {
                            InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                                "{0} Key {1} was sent from {2} but client is not allowed to send yet.",
                                DateTime.Now, pKey, pClient));
                            pClient.SendMessage("sendnotallowedcooldown");
                        }
                    }
                    else
                    {
                        InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                            "{0} Key {1} was sent from {2} but client is not allowed to send this key.",
                            DateTime.Now, pKey, pClient));
                        pClient.SendMessage("sendnotallowedkey");
                    }
                }
                else
                {
                    InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                        "{0} Key {1} was sent from {2} but client is not allowed to send.",
                        DateTime.Now, pKey, pClient));
                    pClient.SendMessage("sendnotallowed");
                }
            }
            else
            {
                InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                    "{0} Key {1} was sent from {2} but server is not receiving keys.",
                    DateTime.Now, pKey, pClient));
                pClient.SendMessage("nosend");
            }
            return false;
        }

        public void AddAllowedKey(string pKey)
        {
            if (!this.DefaultAllowedKeys.Contains(pKey))
                this.DefaultAllowedKeys.Add(pKey);
        }


        /// <summary>
        /// Updates the allowed keys list to all clients for clientside keys checking
        /// </summary>
        /// <param name="pClient"></param>
        /// <param name="pKeys">List of Keys.ToString()</param>
        public void UpdateKeyListToClient(HiveCommunicationServerClient pClient, string[] pKeys)
        {
            pClient.AllowedKeys.Clear();
            StringBuilder lvKeyBuilder = new StringBuilder();
            foreach (string lvKey in pKeys)
            {
                pClient.AllowedKeys.Add(lvKey);
                lvKeyBuilder.Append(lvKey + ",");
            }
            pClient.ClientInformation.SendMessage(new ScsTextMessage(String.Format("keylist: {0}", lvKeyBuilder)));
            InputHiveServerForm.LoggingQueue.Enqueue(String.Format("{0} Updated keylist for {1}", DateTime.Now, pClient));
        }


    }
}
