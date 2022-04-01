using System;
using System.Net.Sockets;
using System.Text;

namespace Lab4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 5000);
                string msg = string.Empty;
                byte[] buffer;

                NetworkStream stream = tcpClient.GetStream();

                while (true)
                {
                    Console.WriteLine(">>>INPUT: ");
                    msg = Console.ReadLine();

                    if (msg.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                        break;

                    buffer = Encoding.UTF8.GetBytes(msg);

                    stream.Write(buffer, 0,buffer.Length);
                    if (msg.Equals("exit all", StringComparison.InvariantCultureIgnoreCase))
                        break;

                    buffer = new byte[1024];

                    string response = String.Empty;
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    response = Encoding.UTF8.GetString(buffer, 0, bytes);
                    Console.WriteLine(">>>SERVER: " + response);
                }
                stream.Close();
                tcpClient.Close();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}
