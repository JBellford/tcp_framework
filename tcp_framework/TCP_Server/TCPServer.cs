using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using tcp_framework.TCP_Server.TCPServer_EventArgs;

namespace tcp_framework.TCP_Server
{
    public class TCPServer
    {

        private Socket _serverSocket;

        public List<Socket> ConnectedClients;

        private bool _shouldAcceptConnections;

        private TCPServer_EventManager _eventManager;
        private TCPServer_Data _serverData;

        public TCPServer(TCPServer_Data data)
        {
            _serverData = data;
            _eventManager = new TCPServer_EventManager();
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(_serverData.InternalIP, _serverData.Port));

            ConnectedClients = new List<Socket>();
            EventManager.CallServerObjectCreated(_serverSocket, new TCPServer_OnServerObjectCreatedArgs() { PreSetData = _serverData, StartTime = DateTime.Now });

            _serverSocket.Listen(_serverData.MaximumBackloggedClients);
        }
        
        public void Start()
        {
            EventManager.CallServerStarted(_serverSocket, new TCPServer_OnServerStartedArgs() { StartTime = DateTime.Now, Port = _serverData.Port });

            _shouldAcceptConnections = true;

            while (true)
            {
                if (!_shouldAcceptConnections)
                    continue;

                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), _serverSocket);

                Thread.Sleep(150);
            }
        }
        public void Stop()
        {
            _shouldAcceptConnections = false;

            foreach (var socket in ConnectedClients)
            {
                try
                {
                    socket.Disconnect(false);
                    EventManager.CallClientDisconnected(_serverSocket, socket);
                }
                catch
                {

                }
                Thread.Sleep(250);
            }

            ConnectedClients = new List<Socket>();
            EventManager.CallServerStopped(_serverSocket, new TCPServer_OnServerStoppedArgs() { TimeStopped = DateTime.Now, });
        }   

        public void SendMessage(Socket socket, string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            socket.Send(messageBytes);
        }
        public void SendMessage(Socket socket, byte[] message)
        {
            socket.Send(message);
        }
        public void SendGroupMessage(List<Socket> socketGroup, string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            foreach (var client in socketGroup)
            {
                client.Send(messageBytes);
            }
        }
        public void SendGroupMessage(List<Socket> socketGroup, byte[] message)
        {
            foreach (var client in socketGroup)
            {
                client.Send(message);
            }
        }
        public void SendGlobalMessage(string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            foreach (var client in ConnectedClients)
            {
                client.Send(messageBytes);
            }
        }
        public void SendGlobalMessage(byte[] message)
        {
            foreach (var client in ConnectedClients)
            {
                client.Send(message);
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
        public bool IsListening
        {
            get
            {
                return _shouldAcceptConnections;
            }
            set
            {
                _shouldAcceptConnections = value;
            }
        }
        public Socket ServerSocket
        {
            get
            {
                return _serverSocket;
            }
            set
            {
                _serverSocket = value;
            }
        }
        public TCPServer_Data Data
        {
            get
            {
                return _serverData;
            }
            set
            {
                _serverData = value;
            }
        }
        private void AcceptCallback(IAsyncResult result)
        {
            Socket socket = _serverSocket.EndAccept(result);

            ConnectedClients.Add(socket);
            EventManager.CallClientConnected(_serverSocket, socket);
        }
    }
}