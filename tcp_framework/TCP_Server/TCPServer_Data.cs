using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcp_framework.TCP_Server
{
    public class TCPServer_Data
    {
        private IPAddress _internalIP = IPAddress.Any;
        private int _port = 8080;

        private bool _verbose = false;

        private DateTime _startTime = DateTime.Now;

        private int _maxConnectedClients = 300;
        private int _maxBackloggedClients = 50;
        private int _maxDelayAcceptingClients = 3;

        private int _keepAliveRetries = 5;
        private int _keepAliveTimeout = 10;
        private int _keepAliveInterval = 1;

        private List<Socket> _connectClients = new List<Socket>();

        public TCPServer_Data(IPAddress internalIP, int port, int maxConnectedClients, int maxBackloggedClients, int maxDelayAcceptingClients, int keepAliveRetries, int keepAliveTimeout, int keepAliveInterval, bool verbose)
        {
            InternalIP = internalIP;
            Port = port;
            StartTime = DateTime.Now;
            MaximumConnectedClients = maxConnectedClients;
            MaximumBackloggedClients = maxBackloggedClients;
            MaximumDelayAcceptingClients = maxDelayAcceptingClients;
            KeepAliveRetries = keepAliveRetries;
            KeepAliveTimeout = keepAliveTimeout;
            KeepAliveInterval = keepAliveInterval;
            Verbose = verbose;
        }
        
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
        
        public TimeSpan UpTime
        {
            get
            {
                return DateTime.Now - _startTime;
            }
        }

        public IPAddress InternalIP
        {
            get
            {
                return _internalIP;
            }
            set
            {
                _internalIP = value;
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

        public int MaximumConnectedClients
        {
            get
            {
                return _maxConnectedClients;
            }
            set
            {
                _maxConnectedClients = value;
            }
        }

        public int MaximumBackloggedClients
        {
            get
            {
                return _maxBackloggedClients;
            }
            set
            {
                _maxBackloggedClients = value;
            }
        }

        public int MaximumDelayAcceptingClients
        {
            get
            {
                return _maxDelayAcceptingClients;
            }
            set
            {
                _maxDelayAcceptingClients = value;
            }
        }

        public int KeepAliveRetries
        {
            get
            {
                return _keepAliveRetries;
            }
            set
            {
                _keepAliveRetries = value;
            }
        }

        public int KeepAliveTimeout
        {
            get
            {
                return _keepAliveTimeout;
            }
            set
            {
                _keepAliveTimeout = value;
            }
        }

        public int KeepAliveInterval
        {
            get
            {
                return _keepAliveInterval;
            }
            set
            {
                _keepAliveInterval = value;
            }
        }

        public bool Verbose
        {
            get
            {
                return _verbose;
            }
            set
            {
                _verbose = value;
            }
        }

        public List<Socket> ConnectedClients
        {
            get
            {
                return _connectClients;
            }
        }

        public void Reset()
        {
            InternalIP = IPAddress.Any;
            Port = 3829;
            StartTime = DateTime.Now;
            MaximumConnectedClients = 300;
            MaximumBackloggedClients = 50;
            MaximumDelayAcceptingClients = 3;
            KeepAliveRetries = 5;
            KeepAliveTimeout = 10;
            KeepAliveInterval = 1;
            Verbose = false;
        }

    }
}
