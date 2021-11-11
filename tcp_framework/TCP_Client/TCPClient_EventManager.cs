using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcp_framework.TCP_Client.TCPClient_EventArgs;
namespace tcp_framework.TCP_Client
{
    class TCPClient_EventManager
    {
        public event EventHandler<TCPClient_OnConnectedArgs> OnClientConnected;
        public event EventHandler<TCPClient_OnDisconnectArgs> OnClientDisconnected;

        internal void CallOnClientConnected(object sender, TCPClient_OnConnectedArgs args)
        {
            OnClientConnected?.Invoke(sender, args);
        }
        internal void CallOnClientDisconnected(object sender, TCPClient_OnDisconnectArgs args)
        {
            OnClientDisconnected?.Invoke(sender, args);
        }
    }
}
