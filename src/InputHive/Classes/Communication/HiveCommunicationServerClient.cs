using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Server;

namespace InputHive.Classes.Communication
{
    class HiveCommunicationServerClient
    {
        public IScsServerClient ClientInformation { get; set; }
        public string Username { get; set; }
        public bool AllowInput { get; set; }

        /// <summary>
        /// Use MinimumTimeCountdown for timer
        /// </summary>
        public int MinimumTime { get; set; }
        /// <summary>
        /// Used for counting down ( 0, or MinimumTime )
        /// </summary>
        public int MinimumTimeCountdown { get; set; }

        /// <summary>
        /// List of all allowed Keys.ToString()
        /// </summary>
        public List<string> AllowedKeys { get; set; }

        private readonly System.Windows.Forms.Timer _countdownTimer;

        public HiveCommunicationServerClient(IScsServerClient pClientInformation, int pMinimumTime, bool pAllowInput)
        {
            ClientInformation = pClientInformation;
            MinimumTime = pMinimumTime;
            AllowInput = pAllowInput;
            AllowedKeys = new List<string>();
            _countdownTimer = new Timer();
            _countdownTimer.Tick += CountdownTimerOnTick;
        }

        private void CountdownTimerOnTick(object pSender, EventArgs pEventArgs)
        {
            MinimumTimeCountdown = 0;
        }

        public override string ToString()
        {
            return Username + " " + ClientInformation.RemoteEndPoint;
        }

        public void AddAllowedKey(string pKey)
        {
            if (!AllowedKeys.Contains(pKey))
                AllowedKeys.Add(pKey);
        }

        public void SendMessage(string pText)
        {
            if (ClientInformation != null)
                ClientInformation.SendMessage(new ScsTextMessage(pText));
            else
                throw new Exception("Clientinformation cannot be null");
        }

        public void ResetCountdown()
        {
            if (MinimumTime > 0)
            {
                MinimumTimeCountdown = MinimumTime;
                _countdownTimer.Stop();
                _countdownTimer.Interval = MinimumTimeCountdown;
                _countdownTimer.Start();
            }
        }
    }
}
