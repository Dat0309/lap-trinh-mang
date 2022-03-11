using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab02_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Console.WriteLine("=======================================");
            Console.WriteLine("KET NOI CLIENT...");
            Console.WriteLine("=======================================");

            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndpoint = clientSocket.RemoteEndPoint;

            Console.WriteLine("Thong tin client ket noi: " + clientEndpoint.ToString());

            string hello = "Dinh Trong Dat: XIN CHAO Client";

            byte[] buff = Encoding.ASCII.GetBytes(hello);

            clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);

            Console.ReadKey();

            serverSocket.Close();
            clientSocket.Close();
        }
    }
}
