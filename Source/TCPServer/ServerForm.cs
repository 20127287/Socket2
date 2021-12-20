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


		// Click nút start:
        private void button1_Click(object sender, EventArgs e)
        {
			server = new Server(IPAddress.Parse(IPTextbox.Text), Int32.Parse(PortTextbox.Text), "", 8 * 1024); // Khởi tạo server.
            server.Start();
			MessageBox.Show("Server đang chạy", "THÔNG BÁO", MessageBoxButtons.OK); // Xuất thông báo.
            StartButton.Enabled = false; // Tắt nút start.
			DefaultButton.Enabled = false; // Tắt nút default.
            StopButton.Enabled = true; // Bật nút stop.
			IPTextbox.Enabled = false; // Tắt IPTextbox.
			PortTextbox.Enabled = false; // Tắt PortTextbox.
            run = true;  //bật true để biết đã kết nối thành công
		}


		// Click nút stop.
        private void button2_Click(object sender, EventArgs e)
        {            
            if (run == true)    //kiểm tra đã kết nối với client chua
			{
				// Bật tắt các nút, textbox:
                StartButton.Enabled = true;
				DefaultButton.Enabled = true;
				StopButton.Enabled = false;
				IPTextbox.Enabled = true;
				PortTextbox.Enabled = true;

				MessageBox.Show("Đã đóng kết nối thành công", "THÔNG BÁO", MessageBoxButtons.OK); // Xuất thông báo.
				run = false; //bật false để biết đã ngắt kết nối
				server.CloseAll(); // Đóng tất cả các client và server
			}
            else // Nếu run == false thì báo lỗi.
				MessageBox.Show("Chưa tạo kết nối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}


		// Click nút default:
		private void button3_Click(object sender, EventArgs e)
		{
            IPTextbox.Text = "127.1.1.2";
            PortTextbox.Text = "4004";
        }
		//************************************************************************


		// Click vào IPTextbox:
		private void textBox1_Click(object sender, EventArgs e)
		{
			if (IPTextbox.Text != "") // Nếu IPTextbox không rỗng.
				IPTextbox.ForeColor = Color.Black; // Chuyển màu kí tự sang màu đen.
		}


		// Click chuột vào IPTextbox:
		private void textBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (IPTextbox.Text == "Nhập IP")
				IPTextbox.Text = ""; // Xóa dòng chữ "Nhập IP".
		}


		// Rời khỏi IPTextbox:
		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (IPTextbox.Text == "") // Nếu IPTextbox rỗng.
				IPTextbox.Text = "Nhập IP"; // Thêm dòng chữ "nhập IP".
			IPTextbox.ForeColor = Color.Gray; // Chuyển màu kí tự sang màu xám.
		}
		//************************************************************************


		// Đóng form:
		private void TCPServer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (run == true)
			{
				run = false;    //bật false để biết đã ngắt kết nối
				server.CloseAll(); // Đóng tất cả các client và server
			}
		}


		// Các sự kiện của PortTextbox (tương tự như IPTextbox):
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
