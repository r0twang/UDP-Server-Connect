﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace UDPServerConnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int port = (int)numericUpDown1.Value;
            IPEndPoint remoteIP = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                UdpClient server = new UdpClient(port);
                Byte[] read = server.Receive(ref remoteIP);
                string data = Encoding.ASCII.GetString(read);
                listBox1.Items.Add(data);
                server.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
