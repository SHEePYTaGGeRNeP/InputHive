using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Hik.Communication.Scs.Communication;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Server;

namespace InputHive.Classes.Communication
{
    internal class HiveCommunicationServer
    {
        public delegate void NewMessageHandler(ScsTextMessage pMessage, IScsServerClient pClient);
        public event NewMessageHandler NewMessage;


        public delegate void UpdateClientListHandler();
        public event UpdateClientListHandler UpdateClientEvent;



        public IScsServer Server { get; private set; }
        public int ServerPort { get; set; }
        public string IpAdres { get; set; }
        public bool AllowConnections { get; set; }
        public int MaximumClients { get; set; }


        public int DefaultMinimumTime { get; set; }
        public bool DefaultAllowInput { get; set; }

        public List<HiveCommunicationServerClient> Clients { get; set; }
        public List<string> BannedIps { get; set; } 

        private bool ServerStarted { get; set; }

        public HiveCommunicationServer(int pDefaultMinimumTime, bool pDefaultAllowInput)
        {
            DefaultMinimumTime = pDefaultMinimumTime;
            DefaultAllowInput = pDefaultAllowInput;
            Clients = new List<HiveCommunicationServerClient>();
            BannedIps = new List<string>();
        }


        public void TurnServerOn()
        {
            if (String.IsNullOrEmpty(IpAdres))
            {
                IPHostEntry lvHost = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress lvIp in lvHost.AddressList)
                {
                    if (lvIp.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IpAdres = lvIp.ToString();
                        break;
                    }
                }
            }
            Server = ScsServerFactory.CreateServer(new ScsTcpEndPoint(IpAdres, ServerPort));

            //Creeër eventhandlers
            Server.ClientConnected += Server_ClientConnected;
            Server.ClientDisconnected += Server_ClientDisconnected;

            // start de server
            Server.Start();
            ServerStarted = true;
            InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                "{0} Started server succesfully on:\t{1} : {2}",DateTime.Now, IpAdres, ServerPort));
        }
        public void TurnServerOff()
        {
            foreach (HiveCommunicationServerClient lvC in Clients)
                lvC.ClientInformation.SendMessage(new ScsTextMessage("kick"));
            Clients.Clear();
            if (ServerStarted == true)
                Server.Stop();
        }

        private void Server_ClientConnected(object sender, ServerClientEventArgs e)
        {
            try
            {
                InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                    "{0} A new client tried to connect. ClientID = {1} {2}",
                    DateTime.Now, e.Client.ClientId, e.Client.RemoteEndPoint));
                if (Clients.Count >= MaximumClients && MaximumClients != 0)
                {
                    InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                        "{0} Server is full. DISCONNECTED WITH ClientID: {1}", DateTime.Now, e.Client.ClientId));
                    e.Client.SendMessage(new ScsTextMessage("full"));
                    e.Client.Disconnect();
                }
                else
                {
                    if (BannedIps.Contains(e.Client.RemoteEndPoint.ToString()))
                    {
                        e.Client.SendMessage(new ScsTextMessage("ban"));
                        e.Client.Disconnect();
                    }
                    else if (AllowConnections == true)
                    {
                        Clients.Add(new HiveCommunicationServerClient(e.Client,DefaultMinimumTime,DefaultAllowInput ));
                        // eventhandler
                        e.Client.MessageReceived += Client_MessageReceived;
                    }
                    else
                    {
                        InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                            "{0} Not allowing connections. DISCONNECTED WITH ClientID: {1}",DateTime.Now, e.Client.ClientId));
                        e.Client.SendMessage(new ScsTextMessage("notallow"));
                        e.Client.Disconnect();
                    }
                }
            }
            catch (Exception lvEx)
            {
                InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                    "{0} !-!-! ERROR: Error on new client connection: {1}",DateTime.Now, lvEx.Message));
                throw new Exception("Error on new client connection:\n" + lvEx.Message);
            }
        }
        private void Server_ClientDisconnected(object sender, ServerClientEventArgs e)
        {
            try
            {
                HiveCommunicationServerClient lvClient = FindClient(e.Client.ClientId);
                if (lvClient != null)
                {
                    InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                        "{0} {1} disconnected. ID: {2} IP: {3}", DateTime.Now,lvClient.Username, 
                        lvClient.ClientInformation.ClientId, lvClient.ClientInformation.RemoteEndPoint));
                    ChatToAllClients(String.Format("{0} disconnected.", lvClient.Username));
                    foreach (HiveCommunicationServerClient lvC in Clients)
                        if (lvC.ClientInformation.ClientId == e.Client.ClientId)
                        {
                            Clients.Remove(lvC);
                            break;
                        }
                    if (UpdateClientEvent != null) UpdateClientEvent.Invoke();
                }
            }
            catch (Exception lvEx)
            { throw new Exception("Error when a client disconnected: " + lvEx.Message); }
        }

        private void Client_MessageReceived(object sender, MessageEventArgs e)
        {
            try
            {
                var lvMessage = e.Message as ScsTextMessage; //Server only accepts text messages
                if (lvMessage != null)
                {
                    IScsServerClient lvClient = (IScsServerClient)sender;
                    if (NewMessage != null) NewMessage.Invoke(lvMessage, lvClient);
                }
            }
            catch (Exception lvEx)
            {
                InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                    "ERROR: Client_MessageReceived: " + lvEx.Message));
            }
        }

        public void ChatToAllClients(string pText)
        {
            InputHiveServerForm.ChatQueue.Enqueue(pText);
            MessageToAllClients(string.Format("chat:{0}", pText));
        }
        public void MessageToAllClients(string pText)
        {
            foreach (HiveCommunicationServerClient lvClient in Clients)
                if (lvClient != null && lvClient.ClientInformation.CommunicationState == CommunicationStates.Connected
                    && !String.IsNullOrEmpty(lvClient.Username))
                {
                    lvClient.ClientInformation.SendMessage(new ScsTextMessage(pText));
                }
        }


        public void KickClient(HiveCommunicationServerClient pClient)
        {
            InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                            "{0} Kicked client: {1}", DateTime.Now, pClient));
            pClient.ClientInformation.SendMessage(new ScsTextMessage("kick"));
            pClient.ClientInformation.Disconnect();
            if (UpdateClientEvent != null) UpdateClientEvent.Invoke();
        }

        public void BanClient(HiveCommunicationServerClient pClient)
        {
            BannedIps.Add(pClient.ClientInformation.RemoteEndPoint.ToString());
            InputHiveServerForm.LoggingQueue.Enqueue(String.Format(
                            "{0} Banned client: {1}", DateTime.Now, pClient));
            pClient.ClientInformation.SendMessage(new ScsTextMessage("ban"));
            pClient.ClientInformation.Disconnect();
            if (UpdateClientEvent != null) UpdateClientEvent.Invoke();
        }

        public HiveCommunicationServerClient FindClient(string pUsername)
        {
            return Clients.Find(pC => String.Equals(pC.Username, pUsername, StringComparison.CurrentCultureIgnoreCase));
        }
        public HiveCommunicationServerClient FindClientByString(string pToString)
        {
            return Clients.Find(pC => pC.ToString() == pToString);
        }
        public HiveCommunicationServerClient FindClient(long pId)
        {
            return Clients.Find(pC => pC.ClientInformation.ClientId == pId);
        }
    }
}
