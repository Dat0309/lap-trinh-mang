using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(serverEndpoint);
            Console.WriteLine("Dang cho client ket noi.");
            EndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);

            byte[] buffer = new byte[1024];

            int receivedByte;

            receivedByte = serverSocket.ReceiveFrom(buffer, ref clientEndpoint);
            string dataStr = Encoding.ASCII.GetString(buffer, 0, receivedByte);

            Console.WriteLine("Du lieu tu Client: " + dataStr);

            Console.ReadLine();
            serverSocket.Close();
        }
    }
}
