using Employee;
using System;
using System.Net;
using System.Net.Sockets;

namespace UDPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            try
            {
                client.Connect("127.0.0.1", 11000);
                byte[] data;
                EmployeeModel employee;

                IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    employee = new EmployeeModel();

                    employee.ImportEmployee();
                    data = employee.GetBytes();

                    int size = employee.Size;
                    byte[] packageSize = new byte[2];
                    Console.WriteLine("Size of package = {0}", size);

                    packageSize = BitConverter.GetBytes(size);
                    client.Send(packageSize, packageSize.Length);

                    client.Send(data, size);

                    Console.WriteLine("Do you want to continue? Type 'exit' to exit!!");
                    string answer = Console.ReadLine();
                    if(answer.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        packageSize = BitConverter.GetBytes(0);
                        client.Send(packageSize, 0);
                        break;
                    }
                }
                client.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
