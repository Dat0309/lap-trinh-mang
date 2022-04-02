using Employee;
using System;
using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee.Employee employee = new Employee.Employee(1, "Dinh Trong", "Dat", 10, 15000000);

            TcpClient tcpClient;
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 9000);
            }catch (SocketException ex)
            {
                Console.WriteLine("Can't connect to server");
                Console.WriteLine("Error: " + ex.Message);
                return;
            }
            NetworkStream stream = tcpClient.GetStream();
            byte[] data = employee.GetBytes();
            int size = employee.Size;
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
