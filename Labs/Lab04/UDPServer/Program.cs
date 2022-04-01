using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(11000);
            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                byte[] bytes = udpClient.Receive(ref remote);
                string msg = Encoding.UTF8.GetString(bytes);
                if (msg.Equals("exit all", StringComparison.InvariantCultureIgnoreCase))
                    break;

                Console.WriteLine(">>>CLIENT :"+msg);

                Console.WriteLine(">>>INPUT :");
                msg = Console.ReadLine();
                bytes = Encoding.UTF8.GetBytes(msg);
                udpClient.Send(bytes, bytes.Length, remote);
            }
            udpClient.Close();
        }
    }
}
