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
        public event EventHandler<TCPClient_OnDisconnectArgs> OnClientDisconnected;
        public event EventHandler<TCPClient_OnMessageReceived> OnClientMessageReceived;
        public event EventHandler<TCPClient_OnLoggerArgs> OnLoggerCalled;

        internal void CallClientConnected(object sender, TCPClient_OnConnectedArgs args)
        {
            OnClientConnected?.Invoke(sender, args);
        }
        internal void CallClientDisconnected(object sender, TCPClient_OnDisconnectArgs args)
        {
            OnClientDisconnected?.Invoke(sender, args);
        }
        internal void CallClientMessageReceived(object sender, TCPClient_OnMessageReceived args)
        {
            OnClientMessageReceived?.Invoke(sender, args);
        }
        internal void CallLoggerCalled(object sender, TCPClient_OnLoggerArgs args)
        {
            OnLoggerCalled?.Invoke(sender, args);
        }
    }
}
