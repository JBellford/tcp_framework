using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Client.TCPClient_EventArgs
{
    public class TCPClient_OnDisconnectArgs
    {
        private DateTime _endTime;
        private string _disconnectReason;

        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }
        public string DisconnectReason
        {
            get
            {
                return _disconnectReason;
            }
            set
            {
                _disconnectReason = value;
            }
        }
    }
}
