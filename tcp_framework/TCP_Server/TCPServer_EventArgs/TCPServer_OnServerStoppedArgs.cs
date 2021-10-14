using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Server.TCPServer_EventArgs
{
    public class TCPServer_OnServerStoppedArgs
    {
        private DateTime _timeStopped;

        public DateTime TimeStopped
        {
            get
            {
                return _timeStopped;
            }
            set
            {
                _timeStopped = value;
            }
        }
    }
}
