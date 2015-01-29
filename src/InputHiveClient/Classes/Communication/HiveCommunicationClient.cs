using System;
using System.Collections.Generic;
using Hik.Communication.Scs.Client;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Communication.Messages;

namespace InputHiveClient.Classes.Communication
{
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
        public List<string> AllowedKeys { get; private set; }

        public HiveCommunicationClient()
        {
            AllowedKeys = new List<string>();
        }

        public void Connect(string pIp, int pPort)       // succes = true,  error = false
        {
            ClientInformation = ScsClientFactory.CreateClient(new ScsTcpEndPoint(pIp, pPort));
            ClientInformation.Connect();
            _connected = true;
            ClientInformation.MessageReceived += Client_MessageReceived;
            //this.Text += " verbonden met: " + p_ip;
        }

        public void Disconnect()
        {
            if (_connected == true)
                ClientInformation.Disconnect();
        }
        private void Client_MessageReceived(object sender, MessageEventArgs e)
        {
            var lvMessage = e.Message as ScsTextMessage; //Server only accepts text messages
            if (lvMessage != null)
                if (NewMessage != null) NewMessage.Invoke(lvMessage);
        }

        public void SendMessage(string pText)
        {
            if (ClientInformation != null)
                ClientInformation.SendMessage(new ScsTextMessage(pText));
            else
                throw new Exception("Clientinformation cannot be null");
        }


    }
}
