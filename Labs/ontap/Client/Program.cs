using OnTap;
using System;
using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            OnTap.Sach sach = new OnTap.Sach();
            sach.ImportBook();

            TcpClient tcpClient;
            try
            {
                tcpClient = new TcpClient("127.0.0.1",9000);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            NetworkStream stream = tcpClient.GetStream();
            byte[] data = sach.GetBytes();
            int size = sach.Size;
            byte[] packageSize = new byte[2];
            packageSize = BitConverter.GetBytes(size);

            Console.WriteLine("Package size: {0}", size);

            stream.Write(packageSize, 0, 2);
            stream.Write(data, 0, size);

            stream.Flush();
            stream.Close();
            tcpClient.Close();

            Console.ReadKey();

        }
    }
}
