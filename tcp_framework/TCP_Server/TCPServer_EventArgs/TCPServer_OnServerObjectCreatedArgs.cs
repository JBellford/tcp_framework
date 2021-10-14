using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Server.TCPServer_EventArgs
{
    public class TCPServer_OnServerObjectCreatedArgs
    {
        private DateTime _startTime;
        private TCPServer_Data _preSetData;

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

        public TCPServer_Data PreSetData
        {
            get
            {
                return _preSetData;
            }
            set
            {
                _preSetData = value;
            }
        }
    }
}
