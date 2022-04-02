using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClientA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect("127.0.0.1", 11000);
                string msg = string.Empty;
                byte[] bytes;

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    Console.WriteLine(">>>INPUT: ");
                    msg = Console.ReadLine();

                    if (msg.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                        break;

                    bytes = Encoding.UTF8.GetBytes(msg);

                    udpClient.Send(bytes, bytes.Length);

                    bytes = udpClient.Receive(ref endPoint);
                    msg = Encoding.UTF8.GetString(bytes);

                    Console.WriteLine(">>>SERVER: "+msg);

                }
                udpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex" + ex);
            }
            Console.ReadKey();
        }
    }
}
