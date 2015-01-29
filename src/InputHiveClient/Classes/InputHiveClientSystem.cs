using System;
using System.Linq;
using System.Windows.Forms;
using Hik.Communication.Scs.Communication.Messages;
using InputHiveClient.Classes.Communication;

namespace InputHiveClient.Classes
{
    /// <summary>
    /// Gebruikt voor InputHiveClientForm
    /// </summary>
    class InputHiveClientSystem
    {
        public HiveCommunicationClient Client { get; set; }

        public delegate void UsernameConfirmedHandler();
        public event UsernameConfirmedHandler OnUsernameConfirmed;

        public delegate void KeylistUpdateHandler();
        public event KeylistUpdateHandler OnKeylistUpdate;


        public InputHiveClientSystem(HiveCommunicationClient pClient)
        {
            Client = pClient;
            Client.NewMessage += ClientOnNewMessage;
        }


        public void Connect(string pIp, int pPort, string pUsername)
        {
            Client.Connect(pIp, pPort);
            Client.Username = pUsername.Trim();
            Client.SendMessage("username:" + Client.Username);
        }
        public void Disconnect()
        {
            Client.Disconnect();
        }

        /// <summary>
        /// Event invoked from HiveCommunicationClient Client
        /// </summary>
        /// <param name="pMessage"></param>
        private void ClientOnNewMessage(ScsTextMessage pMessage)
        {
            string[] lvSplit = pMessage.Text.Split(':');
            switch (lvSplit[0].ToLower())
            {
                case "username":
                    if (lvSplit[1].ToLower() == "ok")
                    {
                        Client.UsernameConfirmed = true;
                        if (OnUsernameConfirmed != null) OnUsernameConfirmed.Invoke();
                    }
                    else if (lvSplit[1].ToLower() == "error")
                        InputHiveClientForm.ShowMessageBox("Username is not valid.", "Username is not valid",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "chat":
                    string lvText = pMessage.Text.Remove(0, 5);
                    InputHiveClientForm.ChatQueue.Enqueue(lvText);
                    break;
                case "full":
                    Client.Disconnect();
                    InputHiveClientForm.ShowMessageBox("The server is full.", "Server is full",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "notallow":
                    Client.Disconnect();
                    InputHiveClientForm.ShowMessageBox("The server is not allowing any new clients.",
                    "Not allowed to join", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "kick":
                    Client.Disconnect();
                    InputHiveClientForm.ShowMessageBox("You have been kicked from the server.",
                    "Kicked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "ban":
                    Client.Disconnect();
                    InputHiveClientForm.ShowMessageBox("You have been banned from the server.",
                    "Banned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "keylist": AddNewKeyList(pMessage.Text.Remove(0, 8));
                    InputHiveClientForm.LoggingQueue.Enqueue(String.Format(
                        "{0} Received keylist update.", DateTime.Now));
                    break;
                case "sendnotallowed": InputHiveClientForm.LoggingQueue.Enqueue(String.Format(
                    "{0} failed to send key. Not allowed to send keys.", DateTime.Now));
                    break;
                case "sendnotallowedkey": InputHiveClientForm.LoggingQueue.Enqueue(String.Format(
                    "{0} failed to send key. Not allowed to send this key.",DateTime.Now));
                    break;
                case "sendnotallowedcooldown": InputHiveClientForm.LoggingQueue.Enqueue(String.Format(
                    "{0} failed to send key. Not allowed to send yet.", DateTime.Now));
                    break;
                case "nosend": InputHiveClientForm.LoggingQueue.Enqueue(String.Format(
                    "{0} failed to send key. Server not allowing keys to be sent.", DateTime.Now));
                    break;
                default:
                    InputHiveClientForm.ShowMessageBox("Unknown message:\n" + pMessage.Text, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void AddNewKeyList(string pKeylist)
        {
            Client.AllowedKeys.Clear();
            string[] lvSplit = pKeylist.Split(',');
            foreach (string lvKey in lvSplit.Where(pKey => !String.IsNullOrEmpty(pKey)))
                Client.AllowedKeys.Add(lvKey.Trim());
            if (OnKeylistUpdate != null) OnKeylistUpdate.Invoke();
        }

        /// <summary>
        /// Send key to server
        /// </summary>
        /// <param name="pKey"></param>
        public void SendKey(string pKey)
        {
            if (Client.AllowedKeys.Contains(pKey))
            {
                Client.SendMessage("key:" + pKey);
                InputHiveClientForm.LoggingQueue.Enqueue(String.Format("{0} sent key {1}.", DateTime.Now, pKey));
            }
            else
                InputHiveClientForm.LoggingQueue.Enqueue(String.Format("{0} failed to send key {1}. Key not allowed.",
                    DateTime.Now, pKey));
        }

        public void SendChatMessage(string pMessage)
        {
            Client.SendMessage("chat:" + DateTime.Now + " " + pMessage);
        }

    }
}
