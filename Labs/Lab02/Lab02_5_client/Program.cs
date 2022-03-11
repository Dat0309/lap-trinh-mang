using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Lab02_5_client
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            Console.WriteLine("============================");
            Console.WriteLine("PROCESSSSSSSSSS...");
            Console.WriteLine("============================");

            try
            {
                serverSocket.Connect(serverEndpoint);
            }
            catch (SocketException ex)
            {
                Console.Error.WriteLine("Co loi trong qua trinh ket noi tu server");
                Console.Error.WriteLine("Thong bao loi: " + ex.Message);
                Console.ReadKey();
                return;
            }

            if (!serverSocket.Connected)
            {
                Console.WriteLine("Co loi trong qua trinh ket noi tu server");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("KET NOI THANH CONG TOI SERVER...");

            while (true)
            {

                Console.Write("Enter message (press q to quit): ");
                string str = Console.ReadLine();

                if (str.Equals("q"))
                {
                    Console.WriteLine("DA NGAT KET NOI TOI SERVER");
                    break;
                }

                byte[] buffInput = Encoding.ASCII.GetBytes(str);

                serverSocket.Send(buffInput, 0, buffInput.Length, SocketFlags.None);

                byte[] buffResult = new byte[1024];
                int byteReceive = serverSocket.Receive(buffResult, 0, buffResult.Length, SocketFlags.None);

                string strResult = Encoding.ASCII.GetString(buffResult, 0, byteReceive);

                Console.WriteLine("KET QUA TRA VE TU SERVER: " + strResult);
            }

            Console.ReadKey();

            serverSocket.Close();
        }
    }
}
