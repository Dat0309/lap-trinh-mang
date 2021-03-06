using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab03_5_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Connect(serverEndpoint);

            if (!serverSocket.Connected)
            {
                Console.WriteLine("Co loi trong qua trinh ket noi");
                Console.ReadLine();
                return;
            }

            //while (true)
            //{
            //    Console.Write("Nhap du lieu can gui: ");
            //    string str = Console.ReadLine();

            //    if (str.Equals("exit")) break;

            //    byte[] data = Encoding.ASCII.GetBytes(str);

            //    serverSocket.Send(data);
            //    Console.WriteLine("Da gui cau chao");

            //    Console.WriteLine();
            //}

            for(int i =1; i <= 5; i++)
            {
                byte[] data = Encoding.ASCII.GetBytes("Thong Diep " + i.ToString());
                serverSocket.SendTo(data, 0, data.Length, SocketFlags.None, serverEndpoint);
            }

            Console.WriteLine("Da thoat chuong trinh client");
            Console.ReadLine();
            serverSocket.Close();
        }
    }
}
