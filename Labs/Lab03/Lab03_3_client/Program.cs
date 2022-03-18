using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab03_3_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                Console.Write("Nhap du lieu can gui: ");
                string str = Console.ReadLine();

                if (str.Equals("exit")) break;

                byte[] data = Encoding.ASCII.GetBytes(str);

                serverSocket.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);
                Console.WriteLine("Da gui cau chao");

                Console.WriteLine();
            }

            Console.WriteLine("Da thoat chuong trinh client");
            Console.ReadLine();
            serverSocket.Close();
        }
    }
}
