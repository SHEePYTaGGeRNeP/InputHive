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
        public bool ShareScreens { get; set; }
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

        public HiveCommunicationServerClient(IScsServerClient pClientInformation, int pMinimumTime, bool pAllowInput, bool pShareSceens)
        {
            this.ClientInformation = pClientInformation;
            this.MinimumTime = pMinimumTime;
            this.AllowInput = pAllowInput;
            this.ShareScreens = pShareSceens;
            this.AllowedKeys = new List<string>();
            this._countdownTimer = new Timer();
            this._countdownTimer.Tick += this.CountdownTimerOnTick;
        }

        private void CountdownTimerOnTick(object pSender, EventArgs pEventArgs)
        {
            this.MinimumTimeCountdown = 0;
        }

        public override string ToString()
        {
            return this.Username + " " + this.ClientInformation.RemoteEndPoint;
        }

        public void AddAllowedKey(string pKey)
        {
            if (!this.AllowedKeys.Contains(pKey))
                this.AllowedKeys.Add(pKey);
        }

        public void SendMessage(string pText)
        {
            if (this.ClientInformation != null)
                this.ClientInformation.SendMessage(new ScsTextMessage(pText));
            else
                throw new Exception("Clientinformation cannot be null");
        }

        public void ResetCountdown()
        {
            if (this.MinimumTime > 0)
            {
                this.MinimumTimeCountdown = this.MinimumTime;
                this._countdownTimer.Stop();
                this._countdownTimer.Interval = this.MinimumTimeCountdown;
                this._countdownTimer.Start();
            }
        }
    }
}
