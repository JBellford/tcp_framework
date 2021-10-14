using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Server.TCPServer_EventArgs
{
    public class TCPServer_OnLoggerArgs
    {
        private string _logNote;
        private TCPServer_LogType _logType;

        public string LogNote
        {
            get
            {
                return _logNote;
            }
            set
            {
                _logNote = value;
            }
        }

        public TCPServer_LogType LogType
        {
            get
            {
                return _logType;
            }
            set
            {
                _logType = value;
            }
        }
    }
    public enum TCPServer_LogType
    {
        Error,
        ServerObjectCreated,
        ServerStarted,
        ServerStopped,
        ClientConnected,
        ClientDisconnected
    }
}
