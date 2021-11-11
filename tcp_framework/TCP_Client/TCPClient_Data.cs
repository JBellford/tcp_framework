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

        private int _totalMessagesSent;
        private double _totalBytesSent;
        private double _totalByteReceived;

        public TCPClient_Data()
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
        public int TotalMessagesSent
        {
            get
            {
                return _totalMessagesSent;
            }
            set
            {
                _totalMessagesSent = value;
            }
        }
        public double TotalBytesSent
        {
            get
            {
                return _totalBytesSent;
            }
            set
            {
                _totalBytesSent = value;
            }
        }
        public double TotalBytesReceived
        {
            get
            {
                return _totalByteReceived;
            }
            set
            {
                _totalByteReceived = value;
            }
        }

        public void Reset()
        {

        }
    }
}
