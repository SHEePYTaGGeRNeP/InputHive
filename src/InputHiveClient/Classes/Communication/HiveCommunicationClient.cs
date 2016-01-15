using System;
using System.Collections.Generic;
using Hik.Communication.Scs.Client;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Communication.Messages;

namespace InputHiveClient.Classes.Communication
{
    using System.Windows.Forms;

    class HiveCommunicationClient
    {
        public delegate void NewMessageHandler(ScsTextMessage pMessage);
        public event NewMessageHandler NewMessage;



        public IScsClient ClientInformation { get; set; }
        public string Username { get; set; }
        public bool UsernameConfirmed { get; set; }

        public bool AllowInput { get; set; }

        private bool _connected;

        /// <summary>
        /// List of all allowed Keys.ToString()
        /// </summary>
        public List<Keys> AllowedKeys { get; private set; }

        public HiveCommunicationClient()
        {
            this.AllowedKeys = new List<Keys>();
        }

        public void Connect(string pIp, int pPort)       // succes = true,  error = false
        {
            this.ClientInformation = ScsClientFactory.CreateClient(new ScsTcpEndPoint(pIp, pPort));
            this.ClientInformation.Connect();
            this._connected = true;
            this.ClientInformation.MessageReceived += this.Client_MessageReceived;
            //this.Text += " verbonden met: " + p_ip;
        }

        public void Disconnect()
        {
            if (this._connected == true)
                this.ClientInformation.Disconnect();
        }
        private void Client_MessageReceived(object sender, MessageEventArgs e)
        {
            var lvMessage = e.Message as ScsTextMessage; //Server only accepts text messages
            if (lvMessage != null)
                if (this.NewMessage != null)
                    this.NewMessage.Invoke(lvMessage);
        }

        public void SendMessage(string pText)
        {
            if (this.ClientInformation != null)
                this.ClientInformation.SendMessage(new ScsTextMessage(pText));
            else
                throw new Exception("Clientinformation cannot be null");
        }


    }
}
