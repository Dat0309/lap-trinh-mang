using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab02_server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Console.WriteLine("============================");
            Console.WriteLine("WAITINGGGGGGGG...");
            Console.WriteLine("============================");

            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndpoint = clientSocket.RemoteEndPoint;

            Console.WriteLine("Thong tin client ket noi: " + clientEndpoint.ToString());

            int counter = 0;

            try
            {
                while (true)
                {
                    counter += 1;

                    byte[] clientBuff = new byte[1024];
                    int byteReceive = clientSocket.Receive(clientBuff, 0, clientBuff.Length, SocketFlags.None);
                    string clientStr = Encoding.ASCII.GetString(clientBuff, 0, byteReceive);

                    Console.WriteLine("Ket qua gui len tu client: " + clientStr);

                    string hello = "Hello Client " + counter.ToString();
                    byte[] buff = Encoding.ASCII.GetBytes(hello);
                    clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
                }
            }
            catch
            {
                Console.WriteLine("Client da ngat ket noi! Thoat chuong trinh!");
            }

            Console.ReadKey();

            serverSocket.Close();
        }
    }
}
