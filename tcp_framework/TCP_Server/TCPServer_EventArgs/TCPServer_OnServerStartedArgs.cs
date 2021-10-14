using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Server.TCPServer_EventArgs
{
    public class TCPServer_OnServerStartedArgs
    {
        private DateTime _startTime;
        private int _port;

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
    }
}
