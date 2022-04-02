using Employee;
using System;
using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] data;
            byte[] size = new byte[2];
            UdpClient client = new UdpClient(11000);
            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                data = new byte[1024];
                size = client.Receive(ref remote);
                if (size.Length == 0)
                    break;

                Console.WriteLine("Connected successfully");
                Console.WriteLine("Host info: " + remote);

                int packageSize = BitConverter.ToInt16(size, 0);
                Console.WriteLine("The size of package: {0}", packageSize);

                data = client.Receive(ref remote);
                EmployeeModel employee = new EmployeeModel(data);
                Console.WriteLine(employee.ToString());
            }
            client.Close();
            Console.ReadKey();
        }
    }
}
