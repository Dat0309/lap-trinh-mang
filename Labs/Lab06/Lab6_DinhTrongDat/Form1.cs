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
    public partial class Form1 : Form
    {
        ServerProgram svP = new ServerProgram(IPAddress.Any, 5000);
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            svP.SetDataFunction = text => listBox1.Items.Add(text);
            svP.SetStatusFunction = text => textBox1.Text = text;
        }

        private void btn_start_server_Click(object sender, EventArgs e)
        {
            svP.Listen();
        }

        private void btn_stop_server_Click(object sender, EventArgs e)
        {
            svP.Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.Show();
        }
    }
}
