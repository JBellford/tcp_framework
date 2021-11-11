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
    public class TCPClient
    {
        private Socket _clientSocket;
        private TCPClient_Data _clientData;
        private TCPClient_EventManager _eventManager;

        private bool _clientIsConnected;

        public TCPClient(TCPClient_Data clientData)
        {
            _clientData = clientData;
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _eventManager = new TCPClient_EventManager();
        }

        public void Connect()
        {
            ClientSocket.Connect(_clientData.ServerIP, _clientData.ServerPort);
        }
        public void Disconnect(bool reuseClient = false)
        {
            ClientSocket.Disconnect(reuseClient);
        }

        public Socket ClientSocket
        {
            get
            {
                return _clientSocket;
            }
            set
            {
                _clientSocket = value;
            }
        }
        public TCPClient_EventManager EventManager
        {
            get
            {
                return _eventManager;
            }
            set
            {
                _eventManager = value;
            }
        }
    }
}
