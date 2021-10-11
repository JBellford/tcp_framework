using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace tcp_framework.TCP_Server
{
    public class TCPServer
    {
        private Socket _serverSocket;

        private TCPServer_EventManager _eventManager;

        private bool _shouldAcceptConnections;

        private TCPServer_Data _data;
        
        public TCPServer(TCPServer_Data data)
        {
            _data = data;
            _eventManager = new TCPServer_EventManager();
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(_data.InternalIP, _data.Port));
            _serverSocket.Listen(_data.MaximumBackloggedClients);
        }

        public void Start()
        {
            _shouldAcceptConnections = true;
            while (true)
            {
                if (!_shouldAcceptConnections)
                    return;

                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), _serverSocket);

                Thread.Sleep(150);
            }
        }

        public TCPServer_EventManager EventManager
        {
            get
            {
                if (_eventManager != null)
                    return _eventManager;
                else
                {
                    _eventManager = new TCPServer_EventManager();
                    return _eventManager;
                }
            }
        }

        private void AcceptCallback(IAsyncResult result)
        {
            Socket socket = (Socket)result;
            EventManager.CallClientConnected(_serverSocket, socket);
        }
    }
}