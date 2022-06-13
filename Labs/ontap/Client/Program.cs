using OnTap;
using System;
using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id;
            string name;
            double price;

            Console.WriteLine("Nhap ID Sach: ");
            id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nhap Ten Sach: ");
            name = Console.ReadLine();
            Console.WriteLine("Nhap Gia Sach: ");
            price = Double.Parse(Console.ReadLine());

            OnTap.Sach sach = new OnTap.Sach(id, name, price);

            TcpClient tcpClient;

            try
            {
                tcpClient = new TcpClient("127.0.0.1", 9000);
            }catch (Exception ex)
            {
                Console.WriteLine("Can't connecty to server");
                Console.WriteLine("Error: " + ex.Message);
                return;
            }

            NetworkStream stream = tcpClient.GetStream();
            byte[] data = sach.GetBytes();
            int size = sach.Size;
            byte[] packageSize = new byte[2];
            Console.WriteLine("Size of package = {0}", size);

            packageSize = BitConverter.GetBytes(size);
            stream.Write(packageSize, 0, 2);

            stream.Write(data, 0, size);

            stream.Flush();
            stream.Close();
            tcpClient.Close();

            Console.ReadKey();
        }
    }
}
