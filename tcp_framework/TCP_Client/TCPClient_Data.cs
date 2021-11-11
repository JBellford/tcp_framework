using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace tcp_framework.TCP_Client
{
    public class TCPClient_Data
    {
        private Socket _clientSocket;
        private string _serverIP;
        private int _serverPort;

        private double _totalBytesSent;
        private double _totalByteReceived;

        public TCPClient_Data(string serverIP, int serverPort)
        {

        }

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

    

    }
}
