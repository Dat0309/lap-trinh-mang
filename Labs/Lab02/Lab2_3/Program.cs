using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("==================================");
            Console.WriteLine("DANG KET NOI VOI SERVER");
            Console.WriteLine("==================================");

            serverSocket.Connect(serverEndPoint);

            if (serverSocket.Connected)
            {
                Console.WriteLine("KET NOI THANH CONG VOI SERVER ... ");
                byte[] buff = new byte[100];
                int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);

                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine("KET QUA TRA VE TU SERVER" + str);
            }

            Console.ReadKey();

            serverSocket.Close();
        }
    }
}
