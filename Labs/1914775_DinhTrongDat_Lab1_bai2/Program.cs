using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;

namespace _1914775_DinhTrongDat_Lab1_bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ipaddr = GetIPAddress();
            var snmask = GetSubnetMask(ipaddr);
            var defaultGateway = GetDefaultGateway();

            Console.WriteLine("IP Address LocalHost: "+ ipaddr.ToString());
            Console.WriteLine("Subnet Mask : " + snmask);
            Console.WriteLine("Default Gateway : " + defaultGateway.ToString());
        }

        /**
         * Phan giai dia chi IP
         */
        static IPAddress GetIPAddress()
        {
                var hostInfo = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in hostInfo.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip;
                    }
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /**
         * Phan giai subnet mask
         */
        static IPAddress GetSubnetMask(IPAddress ipaddr)
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddress in networkInterface.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddress.Address.AddressFamily == AddressFamily.InterNetwork)
                        if (ipaddr.Equals(unicastIPAddress.Address))
                            return unicastIPAddress.IPv4Mask;

                }
            }
            throw new ArgumentException(string.Format("Khong the tim subnetmask cua IP address '{0}'", ipaddr));
        }

        /**
         * Phan default gateway
         */
        static IPAddress GetDefaultGateway()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                .Where(x => x.OperationalStatus == OperationalStatus.Up)
                .Where(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(x => x.GetIPProperties().GatewayAddresses)
                .Select(y => y?.Address)
                .Where(z => z != null)
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();
        }
    }
}
