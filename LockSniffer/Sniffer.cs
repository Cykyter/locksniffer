using System;
using System.Linq;
using Microsoft.Win32;

namespace LockSniffer
{
    public class Sniffer
    {
        private static readonly SessionSwitchReason[] LockReasons = { SessionSwitchReason.SessionLogoff, SessionSwitchReason.SessionLock, SessionSwitchReason.RemoteDisconnect, SessionSwitchReason.ConsoleDisconnect };
        private static readonly SessionSwitchReason[] UnlockReasons = { SessionSwitchReason.SessionLogon, SessionSwitchReason.SessionUnlock, SessionSwitchReason.RemoteConnect, SessionSwitchReason.ConsoleConnect };
        private readonly L�gger _l�g;

        public Sniffer(L�gger l�g)
        {
            _l�g = l�g;
        }

        public void StartSniffing()
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        public void StopSniffing()
        {
            SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
        }

        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (LockReasons.Contains(e.Reason))
            {
                _l�g.L�g(new L�gEntry { Locked = true, Timestamp = DateTime.Now, Message = e.Reason.ToString() });
            }

            if (UnlockReasons.Contains(e.Reason))
            {
                _l�g.L�g(new L�gEntry { Locked = false, Timestamp = DateTime.Now, Message = e.Reason.ToString() });
            }
        }
    }
}