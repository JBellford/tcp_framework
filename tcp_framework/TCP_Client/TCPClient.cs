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

        private bool _clientConnected;

        public TCPClient(TCPClient_Data clientData)
        {
            _clientData = clientData;
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _eventManager = new TCPClient_EventManager();

            new Thread(Listener).Start();
        }

        public void Connect()
        {
            try
            {
                ClientSocket.Connect(_clientData.ServerIP, _clientData.ServerPort);
                ClientConnected = true;
            }
            catch
            {
                ClientConnected = false;
            }
        }
        public void Disconnect(bool reuseClient = false)
        {
            if (ClientConnected)
                ClientConnected = false;

            ClientSocket.Disconnect(reuseClient);
        }
        public void SendMessage(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            ClientSocket.Send(messageBytes);
        }

        private void Listener()
        {
            while (true)
            {
                try
                {
                    if (ClientConnected && SocketConnected && ClientSocket.Available > 0)
                    {
                        byte[] buffer = new byte[1024];
                        int size = ClientSocket.Receive(buffer, 0);

                        string incomingMessage = Encoding.ASCII.GetString(buffer, 0, size);

                        if (incomingMessage.Count() > 0)
                        {
                            Data.TotalBytesReceived += size;
                            Data.TotalMessagesSent++;
                            EventManager.CallClientMessageReceived(this, new TCPClient_EventArgs.TCPClient_OnMessageReceived() { Message = incomingMessage, MessageBytes = buffer });
                        }
                    }
                }
                catch
                {

                }
                Thread.Sleep(_clientData.ListenerDelay);
            }
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
        public TCPClient_Data Data
        {
            get
            {
                return _clientData;
            }
            set
            {
                _clientData = value;
            }
        }

        public bool ClientConnected
        {
            get
            {
                return _clientConnected;
            }
            set
            {
                _clientConnected = value;
            }
        }
        public bool SocketConnected
        {
            get
            {
                if (ClientSocket.Poll(1000, SelectMode.SelectRead) && ClientSocket.Available == 0)
                    return false;
                else
                    return true;
            }
        }
    }
}
