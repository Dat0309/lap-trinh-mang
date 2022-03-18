using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab03_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(serverEndpoint);

            Console.WriteLine("Dang cho client ket noi...");

            EndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);

            byte[] buffer = new byte[1024];
            int receivedByte;

            while (true)
            {
                buffer = new byte[1024];
                receivedByte = serverSocket.ReceiveFrom(buffer, ref clientEndpoint);

                string dataStr = Encoding.ASCII.GetString(buffer, 0, receivedByte);

                Console.WriteLine(clientEndpoint + ": " + dataStr);
            }
        }
    }
}
