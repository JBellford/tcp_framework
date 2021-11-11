using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Client.TCPClient_EventArgs
{
    public class TCPClient_OnMessageReceived
    {
        private string _message;
        private byte[] _messageBytes;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }
        public byte[] MessageBytes
        {
            get
            {
                return _messageBytes;
            }
            set
            {
                _messageBytes = value;
            }
        }

    }
}
