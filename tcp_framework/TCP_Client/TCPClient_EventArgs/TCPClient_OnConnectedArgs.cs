using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Client.TCPClient_EventArgs
{
    public class TCPClient_OnConnectedArgs
    {
        private string _serverIP;
        private int _serverPort;
        private DateTime _startTime;

        public string ServerIP
        {
            get
            {
                return _serverIP;
            }
            set
            {
                _serverIP = value;
            }
        }
        public int ServerPort
        {
            get
            {
                return _serverPort;
            }
            set
            {
                _serverPort = value;
            }
        }
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

    }
}
