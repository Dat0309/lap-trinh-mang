using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_DinhTrongDat
{
    public partial class Client : Form
    {
        ClientProgram clP = new ClientProgram();
        public Client()
        {
            InitializeComponent();
            clP.SetDataFunction = text => listBox1.Items.Add(text);
        }

        private void btn_Connect_Client_Click(object sender, EventArgs e)
        {
            clP.Connect(IPAddress.Loopback, 5000);
        }

        private void btn_DisConnect_Client_Click(object sender, EventArgs e)
        {
            clP.Disconnect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            clP.SendData(txtMess.Text);
            txtMess.Text = "";
        }
    }
}
