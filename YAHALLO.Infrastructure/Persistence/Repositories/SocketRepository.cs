using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.Socket;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class SocketRepository
    {
        public Socket? sck;
        public Socket? received;
        public Queue<SocketQueue> queue = new Queue<SocketQueue>();
        public int port = 11906;
        public SocketRepository() { }

        public async Task<bool> TryConnect(string host, int port)
        {
            bool checkPort = CheckPortIsBusy(port);
            if (!checkPort)
            {
                throw new Exception($"Cannot connect with port {port}, port is busying");
            }
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            IPAddress? address;
            if (!IPAddress.TryParse(host, out address))
            {
                address = Dns.GetHostEntry(host).AddressList[0];
            }
            IPEndPoint remoteEp = new IPEndPoint(address, port);
            try
            {
                await sck.ConnectAsync(remoteEp);
                if (sck.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SocketException e)
            {
                throw new Exception($"Error when connect to socket: ", e);
            }
        }
        public async void Listen()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            received = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            received.Bind(endPoint);
            received.Listen();
            try
            {
                while (true)
                {
                    if (received == null) return;
                    using (Socket client = await received.AcceptAsync())
                    {
                        using (NetworkStream stream = new NetworkStream(client))
                        {
                            DataReceivedHandler(stream);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void DataReceivedHandler(NetworkStream stream)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                byte[] buffer = new byte[4096];
                int length = 0;
                while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
                {

                    ms.Write(buffer, 0, length);

                    if (stream.DataAvailable)
                    {
                        continue;
                    }
                    ms.Seek(0, SeekOrigin.Begin);
                    byte[] source = ms.ToArray();

                    SocketEnums type = (SocketEnums)source[0];
                    byte[] data = new byte[source.Length - 1];
                    Array.Copy(source, 1, data, 0, data.Length);

                    if (data != null)
                    {
                        queue.Enqueue(new SocketQueue(type, data));
                    }
                }
            }
            catch (EndOfStreamException ex)
            {
                throw new EndOfStreamException($"Error writing data: {ex.GetType().Name} - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.GetType().Name} - {ex.Message}");
            }
            finally
            {
                ms.Dispose();
            }
        }
        public SocketServerInfo ServerInfo()
        {
            Random rd = new Random();
            port = rd.Next(0, 65535);
            while (!CheckPortIsBusy(port))
            {
                port = rd.Next(0, 65535);
            }
            var IpAddresses = GetLocalIPAddress().ToList();
            SocketServerInfo serverInfo = new SocketServerInfo("Yahallo Socket Api", IpAddresses, port);
            return serverInfo;
        }
        private IEnumerable<string> GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = (from ip in host.AddressList where !IPAddress.IsLoopback(ip) select ip.ToString()).ToList();
            return ipAddress;
        }
        public bool CheckPortIsBusy(int port)
        {
            bool isAvailable = true;
            IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnection = iPGlobalProperties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation connection in tcpConnection)
            {
                if (connection.LocalEndPoint.Port == port)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }
    }
}
