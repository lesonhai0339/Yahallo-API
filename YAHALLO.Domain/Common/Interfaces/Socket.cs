using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.Socket;

namespace YAHALLO.Domain.Common.Interfaces
{
    public class SocketServerInfo
    {
        public SocketServerInfo() { }
        public SocketServerInfo(string servername, List<string> hosts, int port)
        {
            ServerName = servername;
            Hosts = hosts;  
            Port = port;
        }
        public string ServerName { get; set; } = null!;
        public List<string> Hosts { get; set; } = null!;
        public int Port { get; set; }
    }
    public class SocketQueue
    {
        public SocketQueue() { }    
        public SocketQueue(SocketEnums type, byte[]? data) 
        {
            Type = type;
            Data = data;    
        }
        public SocketEnums Type { get; set; }
        public byte[]? Data { get; set; }
    }
}
