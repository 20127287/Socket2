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
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace TCPClient
{
    public partial class TCPClient : Form
    {
        Client client;
        private bool run = false;
        List<PhoneBookClient> phoneBookClients = new List<PhoneBookClient>();
        int i;
        int count;

        class PhoneBookClient
        {
            public string code { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public byte[] avatar { get; set; }

            public PhoneBookClient()
            {
                code = "";
                name = "";
                phone = "";
                email = "";
                avatar = null;
            }
        }

        public TCPClient()
        {
            InitializeComponent();
        }

        public void Connect(object sender, EventArgs e)
        {
            const Int32 sizePictureMax = 1000000000;
            client = new Client(IPAddress.Parse(IPTextbox.Text), Int32.Parse(PortTextbox.Text), sizePictureMax);
            bool connect = client.Connect();
            if (connect == true)
            {
                run = true;
                ConnectButton.Enabled = false;
                DefaultButton.Enabled = false;
                DisconnectedButton.Enabled = true;
                PortTextbox.Enabled = false;
                IPTextbox.Enabled = false;
            }
        }

        private void Disconnect(object sender, EventArgs e)
        {
            if (run == true)
            {
                ConnectButton.Enabled = true;
                DefaultButton.Enabled = true;
                DisconnectedButton.Enabled = false;
                PortTextbox.Enabled = true;
                IPTextbox.Enabled = true;
                run = false;
                client.Send("Disconnect");
                client.Disconnect();

                MessageBox.Show("Đóng kết nối thành công", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Chưa kết nối server!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //************************************************************************

        public void Display(object sender, EventArgs e)
        {
            if (run == true)
            {
                SearchTextBox.Text = "Nhập code";
                SearchTextBox.ForeColor = Color.Silver;
                bool checkServer;

                checkServer = client.Send(DisplayButton.Text);

                if (checkServer == true)
                {

                    string convert = Encoding.UTF8.GetString(client.Recieve());

                    phoneBookClients = JsonConvert.DeserializeObject<List<PhoneBookClient>>(convert);

                    i = 0;
                    count = phoneBookClients.Count;

                    showObject(phoneBookClients[i]);

                    if (count > 1) NextButton.Enabled = true;
                    BackButton.Enabled = false;

                    ord.Visible = true;
                    ord.Text = (i + 1).ToString() + "/" + count.ToString();

                    GoTextbox.Enabled = true;
                    GoButton.Enabled = true;
                    GoTextbox.Enabled = true;
                    DisplayButton.Enabled = false;
                }
                else MessageBox.Show("Không kết nối được với server!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Chưa tạo kết nối!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

        } 
        //gui ma so can tìm kiem
        private void Search(object sender, EventArgs e)
        {
            if (run == true)
            {
                string information = SearchTextBox.Text;
                bool check = false;

                for (int i = 0; i < information.Length; i++)
                    if (information[i] != ' ')
                        check = true;
                if (information == "Nhập code")
                    check = false;
                bool checkServer;
                if (check)
                    checkServer = client.Send(SearchTextBox.Text);
                else
                {
                    MessageBox.Show("Bạn chưa nhập mã số", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SearchTextBox.Text = "Nhập code";
                    SearchTextBox.ForeColor = Color.Silver;
                    return;
                }

                if (checkServer == true)
                {

                    //Nhan lai thong tin tu server
                    byte[] recieve = client.Recieve();
                    string data = Encoding.UTF8.GetString(recieve);

                    if (data != "false")
                    {
                        PhoneBookClient phoneBookClient = new PhoneBookClient();
                        phoneBookClient = JsonConvert.DeserializeObject<PhoneBookClient>(data);
                        showObject(phoneBookClient);

                        NextButton.Enabled = BackButton.Enabled = false;
                        ord.Visible = false;

                        GoTextbox.Enabled = false;
                        GoButton.Enabled = false;
                        GoTextbox.Enabled = false;
                        DisplayButton.Enabled = true;
                    }
                    else MessageBox.Show("Không có trong danh sách", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Không kết nối được với server!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Chưa tạo kết nối!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            SearchTextBox.ForeColor = Color.Gray;
            SearchTextBox.Text = "Nhập code";
        }

        private void showObject(PhoneBookClient phoneBookClient)
        {
            CodeView.Text = phoneBookClient.code.ToString();
            NameView.Text = phoneBookClient.name;
            PhoneView.Text = phoneBookClient.phone;
            EmailView.Text = phoneBookClient.email;
            if (phoneBookClient.avatar != null)
                pictureBox.Image = new Bitmap(Image.FromStream(new MemoryStream(phoneBookClient.avatar)), new Size(300, 300));
            else pictureBox.Image = pictureBox.ErrorImage;
        }

		private void button3_Click(object sender, EventArgs e)
		{
            IPTextbox.Text = "127.1.1.2";
            PortTextbox.Text = "4004";
        }

        private void Next_Click(object sender, EventArgs e)
        {
            BackButton.Enabled = true;

            showObject(phoneBookClients[++i]);
            ord.Text = (i + 1).ToString() + "/" + count.ToString();

            if (i == count - 1) NextButton.Enabled = false;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            NextButton.Enabled = true;

            showObject(phoneBookClients[--i]);
            ord.Text = (i + 1).ToString() + "/" + count.ToString();

            if (i == 0) BackButton.Enabled = false;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tmp = Int32.Parse(GoTextbox.Text);

                if (tmp < 1 || tmp > count)
                    MessageBox.Show("Số vừa nhập không hợp lệ!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    i = tmp - 1;
                    showObject(phoneBookClients[i]);
                    ord.Text = tmp.ToString() + "/" + count.ToString();

                    if (i == 0) BackButton.Enabled = false;
                    else BackButton.Enabled = true;

                    if (i == count - 1) NextButton.Enabled = false;
                    else NextButton.Enabled = true;
                }

                GoTextbox.ForeColor = Color.Gray;
                GoTextbox.Text = "Nhập vị trí";
            }
            catch
            {
                MessageBox.Show("Bước nhảy không hợp lệ!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "Nhập code")
                SearchTextBox.Text = "";
            SearchTextBox.ForeColor = Color.Black;
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                SearchTextBox.Text = "Nhập code";
                SearchTextBox.ForeColor = Color.Silver;
            }
        }

        private void GoTextbox_Enter(object sender, EventArgs e)
        {
            if (GoTextbox.Text == "Nhập vị trí")
                GoTextbox.Text = "";
            GoTextbox.ForeColor = Color.Black;
        }

        private void GoTextbox_Leave(object sender, EventArgs e)
        {
            if (GoTextbox.Text == "")
            {
                GoTextbox.Text = "Nhập vị trí";
                GoTextbox.ForeColor = Color.Gray;
            }
        }

        private void TCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (run == true)
            {
                ConnectButton.Enabled = true;
                DefaultButton.Enabled = true;
                DisconnectedButton.Enabled = false;
                PortTextbox.Enabled = true;
                IPTextbox.Enabled = true;
                run = false;
                client.Send("Disconnect");
                client.Disconnect();

                this.Close();
            }
        }
    }
}
