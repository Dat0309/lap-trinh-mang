using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace _1914775_DinhTrongDat_Lab1_bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ipaddr = GetIPAddress();
            var snmask = GetSubnetMask(ipaddr);
            var defaultGateway = GetDefaultGateway();

            txtIP.Text = ipaddr.ToString();
            txtSubnetMask.Text = snmask.ToString();
            txtDefaultGateway.Text = defaultGateway.ToString();
        }

        #region CAC HAM CHUC NANG
        /// <summary>
        /// Lấy địa chỉ IP của localhost
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Lấy subnet mask của địa chỉ ip
        /// </summary>
        /// <param name="ipaddr"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Lấy Default Gateway
        /// </summary>
        /// <returns></returns>
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

        private string GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(host);
                StringBuilder sb = new StringBuilder();
                //sb.Append(hostEntry.AddressList[1]);
                foreach (IPAddress ipaddr in hostEntry.AddressList)
                {
                    sb.AppendLine(ipaddr.ToString());
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the phan giai ten mien!!");
                return null;
            }
        }
        #endregion

        private void btnPhanGiai_Click(object sender, EventArgs e)
        {
            string tenMien = txtInput.Text;
            string ipList = GetHostInfo(tenMien);
            if(!string.IsNullOrWhiteSpace(ipList))
                txtResult.Text = ipList;
        }
    }
}
