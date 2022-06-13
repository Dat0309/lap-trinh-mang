using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            int byteReceived;

            TcpListener server = new TcpListener(IPAddress.Any, 9000);
            server.Start();
            Console.WriteLine("Waiting for a connection...");

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected succesfully");
            NetworkStream stream = client.GetStream();

            byte[] size = new byte[2];
            byteReceived = stream.Read(size, 0, 2);
            int packageSize = BitConverter.ToInt16(size, 0);
            Console.WriteLine("The size of package: {0}", packageSize);

            byteReceived = stream.Read(data, 0, packageSize);
            OnTap.Sach sach = new OnTap.Sach(data);
            Console.WriteLine(sach.ToString());

            stream.Close();
            client.Close();
            server.Stop();

            Console.ReadLine();
        }
    }
}
