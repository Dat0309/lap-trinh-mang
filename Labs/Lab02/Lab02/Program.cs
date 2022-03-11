using System;
using System.Net;
using System.Net.Sockets;

namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);

            Console.WriteLine("=============================================");
            Console.WriteLine("KET NOI CLIENT...");
            Console.WriteLine("=============================================");

            Socket clientSocket = serverSocket.Accept();

            EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
            
            Console.WriteLine("Thong tin client ket noi: " + clientEndPoint.ToString());

            Console.ReadKey();
            serverSocket.Close();
            clientSocket.Close();
        }
    }
}
