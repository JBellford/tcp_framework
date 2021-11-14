using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcp_framework.TCP_Client.TCPClient_EventArgs;
namespace tcp_framework.TCP_Client
{
    public class TCPClient_EventManager
    {
        public event EventHandler<TCPClient_OnConnectedArgs> OnClientConnected;
        public event EventHandler<TCPClient_OnDisconnectArgs> OnClientDClientConnected;
        public event EventHandler<TCPClient_OnMessageReceived> OnClientMessageReceived;

        internal void CallOnClientConnected(object sender, TCPClient_OnConnectedArgs args)
        {
            OnClientConnected?.Invoke(sender, args);
        }
        internal void CallOnClientDClientConnected(object sender, TCPClient_OnDisconnectArgs args)
        {
            OnClientDClientConnected?.Invoke(sender, args);
        }
        internal void CallOnClientMessageReceived(object sender, TCPClient_OnMessageReceived args)
        {
            OnClientMessageReceived?.Invoke(sender, args);
        }
    }
}
