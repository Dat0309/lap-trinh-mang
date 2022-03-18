using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab3_1_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string str = "Hello Server";
            byte[] data = Encoding.ASCII.GetBytes(str);

            Console.WriteLine("Dang gui loi chao.");
            serverSocket.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);
            Console.WriteLine("Da gui loi chao.");

            Console.ReadLine();
        }
    }
}
