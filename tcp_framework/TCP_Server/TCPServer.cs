﻿using System;
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
        private TCPServer_Data _data;

        public TCPServer(TCPServer_Data data)
        {
            _data = data;
            _eventManager = new TCPServer_EventManager();
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(_data.InternalIP, _data.Port));

            ConnectedClients = new List<Socket>();
            EventManager.CallServerObjectCreated(_serverSocket, new TCPServer_OnServerObjectCreatedArgs() { PreSetData = _data, StartTime = DateTime.Now });

            _serverSocket.Listen(_data.MaximumBackloggedClients);
        }

        public void Start()
        {
            EventManager.CallServerStarted(_serverSocket, new TCPServer_OnServerStartedArgs() { StartTime = DateTime.Now, Port = _data.Port });

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

        private void AcceptCallback(IAsyncResult result)
        {
            Socket socket = _serverSocket.EndAccept(result);

            ConnectedClients.Add(socket);
            EventManager.CallClientConnected(_serverSocket, socket);
        }
    }
}