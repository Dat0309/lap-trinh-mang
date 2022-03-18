using System;
using System.Net;

namespace _1914775_DinhTrongDat_Lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string domainName = "";
            Console.WriteLine("Nhap ten mien can phan giai: ");
            domainName = Console.ReadLine();

            GetHostInfo(domainName);
        }

        static void GetHostInfo(string host)
        {
            try{
                IPHostEntry hostInfo = Dns.GetHostEntry(host);
                Console.WriteLine("Ten Mien: " + hostInfo.HostName);
                Console.WriteLine("Dia chi IP:");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                {
                    Console.WriteLine(ipaddr.ToString() + " ");
                }
                Console.WriteLine();
            }catch (Exception ex)
            {
                Console.Error.WriteLine("Khong phan giai duoc ten mien: " + host + "\n");
            }
        }
    }
}
