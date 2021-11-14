using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using tcp_framework.TCP_Client;
using tcp_framework.TCP_Server.TCPServer_EventArgs;

namespace tcp_framework.TCP_Server
{
    public class TCPServer_EventManager
    {
        public event EventHandler<TCPServer_OnLoggerArgs> OnLoggerCalled;
        public event EventHandler<TCPServer_OnServerObjectCreatedArgs> OnServerObjectCreated;
        public event EventHandler<TCPServer_OnServerStartedArgs> OnServerStarted;
        public event EventHandler<TCPServer_OnServerStoppedArgs> OnServerStopped;
        public event EventHandler<Socket> OnClientConnected;
        public event EventHandler<Socket> OnClientDClientConnected;

        internal void CallLogger(object sender, TCPServer_OnLoggerArgs args)
        {
            OnLoggerCalled?.Invoke(sender, args);
        }

        internal void CallServerObjectCreated(object sender, TCPServer_OnServerObjectCreatedArgs args)
        {
            OnServerObjectCreated?.Invoke(sender, args);
        }

        internal void CallServerStarted(object sender, TCPServer_OnServerStartedArgs args)
        {
            OnServerStarted?.Invoke(sender, args);
        }

        internal void CallServerStopped(object sender, TCPServer_OnServerStoppedArgs args)
        {
            OnServerStopped?.Invoke(sender, args);
        }

        internal void CallClientConnected(object sender, Socket args)
        {
            OnClientConnected?.Invoke(sender, args);
        }

        internal void CallClientDClientConnected(object sender, Socket args)
        {
            OnClientDClientConnected?.Invoke(sender, args);
        }
    }
}
