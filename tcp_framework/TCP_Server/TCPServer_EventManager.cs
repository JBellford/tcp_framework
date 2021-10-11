using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using tcp_framework.TCP_Client;

namespace tcp_framework.TCP_Server
{
    public class TCPServer_EventManager
    {
        public event EventHandler<Socket> OnClientConnected;

        internal void CallClientConnected(object sender, Socket args)
        {
            OnClientConnected?.Invoke(sender, args);
        }
    }
}
