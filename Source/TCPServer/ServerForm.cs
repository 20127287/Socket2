using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Project1
{
    public partial class TCPServer : Form
    {
        public TCPServer()
        {
            InitializeComponent();
        }
        Server server;
        private bool run = false;
        private void button1_Click(object sender, EventArgs e)
        {
			server = new Server(IPAddress.Parse(IPTextbox.Text), Int32.Parse(PortTextbox.Text), "", 8 * 1024);
            server.Start();
			MessageBox.Show("Server đang chạy", "THÔNG BÁO", MessageBoxButtons.OK);
            StartButton.Enabled = false;
			DefaultButton.Enabled = false;
            StopButton.Enabled = true;
			IPTextbox.Enabled = false;
			PortTextbox.Enabled = false;
            run = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {            
            if (run == true)
            {
                StartButton.Enabled = true;
				DefaultButton.Enabled = true;
				StopButton.Enabled = false;
				IPTextbox.Enabled = true;
				PortTextbox.Enabled = true;
				MessageBox.Show("Đã đóng kết nối thành công", "THÔNG BÁO", MessageBoxButtons.OK);
				run = false;
				server.CloseAll();
			}
            else
				MessageBox.Show("Chưa tạo kết nối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private void button3_Click(object sender, EventArgs e)
		{
            IPTextbox.Text = "127.1.1.2";
            PortTextbox.Text = "4004";
        }
		//************************************************************************

		private void textBox1_Click(object sender, EventArgs e)
		{
			if (IPTextbox.Text != "")
				IPTextbox.ForeColor = Color.Black;
		}

		private void textBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (IPTextbox.Text == "Nhập IP")
				IPTextbox.Text = "";
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (IPTextbox.Text == "")
				IPTextbox.Text = "Nhập IP";
			IPTextbox.ForeColor = Color.Gray;
		}
		//************************************************************************

		private void TCPServer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (run == true)
			{
				run = false;
				server.CloseAll();
			}
		}

		private void textBox2_Click(object sender, EventArgs e)
		{
			if (PortTextbox.Text != "")
				PortTextbox.ForeColor = Color.Black;
		}

		private void textBox2_MouseClick(object sender, MouseEventArgs e)
		{
			if (PortTextbox.Text == "Nhập Port")
				PortTextbox.Text = "";
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (PortTextbox.Text == "")
				PortTextbox.Text = "Nhập Port";
			PortTextbox.ForeColor = Color.Gray;
		}    
    }
}
