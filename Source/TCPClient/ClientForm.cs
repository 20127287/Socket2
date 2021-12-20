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
        int i; // index của phoneBookClients.
        int count; // Số phần tử trong phoneBookClients.

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


        // Click vào nút Connect:
        public void Connect(object sender, EventArgs e)
        {
            const Int32 sizePictureMax = 1000000000; // Dung lượng tối đa của ảnh.

            // khởi tạo của client với IP và PORT để kết nối đến server
            client = new Client(IPAddress.Parse(IPTextbox.Text), Int32.Parse(PortTextbox.Text), sizePictureMax);
            bool connect = client.Connect();
            if (connect == true)
            {
                run = true; // Gán run = true.

                // Bật tắt các nút, textbox:
                ConnectButton.Enabled = false;
                DefaultButton.Enabled = false;
                DisconnectedButton.Enabled = true;
                PortTextbox.Enabled = false;
                IPTextbox.Enabled = false;
            }
        }


        // Click vào nút Disconnect:
        private void Disconnect(object sender, EventArgs e)
        {
            if (run == true)
            {   
                // Bật tắt các nút, textbox:
                ConnectButton.Enabled = true;
                DefaultButton.Enabled = true;
                DisconnectedButton.Enabled = false;
                PortTextbox.Enabled = true;
                IPTextbox.Enabled = true;
                run = false; // Gán run = false.
                client.Send("Disconnect"); // Client gửi tới server thông điệp "Disconnect".
                client.Disconnect(); // Ngắt kết nối.

                MessageBox.Show("Đóng kết nối thành công", "THÔNG BÁO", MessageBoxButtons.OK); // Xuất thông báo thành công.
            }
            else
                MessageBox.Show("Chưa kết nối server!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error); // Xuất thông báo lỗi.
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
            if (IPTextbox.Text == "Nhập IP") // Nếu có dòng chữ "Nhập IP".
                IPTextbox.Text = ""; // Xóa dòng chữ đó.
        }


        // Rời khỏi IPTextbox:
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (IPTextbox.Text == "") // Nếu IPTextbox rỗng.
                IPTextbox.Text = "Nhập IP"; // Thêm dòng chữ "Nhập IP".
            IPTextbox.ForeColor = Color.Gray; // Chuyển màu kí tự sang màu xám.
        }

        //************************************************************************
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

        //************************************************************************


        // Click vào nút Display:
        public void Display(object sender, EventArgs e)
        {
            if (run == true) //nếu socket kết nối thành công thì mới làm
            {
                SearchTextBox.Text = "Nhập code"; //hiển thị nhập code mỗi khi thực hiện xong display
                SearchTextBox.ForeColor = Color.Silver;
                bool checkServer;

                checkServer = client.Send(DisplayButton.Text); // gửi thông điệp của DisplayButton đến server.
                                                               //và trả về checkSever là true/false để thể hiện gửi thông tin có thành công hay không
                if (checkServer == true)    //nếu gửi thông tin thành công
                {
                    string convert = Encoding.UTF8.GetString(client.Recieve()); // Encoding thông điệp mà client nhận được sang string

                    // DeserializeObject dữ liệu chứa trong convert sang List<PhoneBookClient>:
                    phoneBookClients = JsonConvert.DeserializeObject<List<PhoneBookClient>>(convert);

                    i = 0; // Gán i = 0
                    count = phoneBookClients.Count; // Gán count = số lượng phần tử của phoneBookClients.

                    showObject(phoneBookClients[i]); // Xuất phoneBookClients[i].

                    if (count > 1) NextButton.Enabled = true; // Nếu count > 1 thì nút Next sẽ được bật lên.
                    BackButton.Enabled = false; // Tắt nút Back.

                    ord.Visible = true; // Bật lên để có thể nhìn thấy chỉ số ord.
                    ord.Text = (i + 1).ToString() + "/" + count.ToString(); // Gán chỉ số cho ord.

                    // bật tắt các nút chức năng khác:
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
            if (run == true)    //nếu socket kết nối thành công thì mới làm
            {
                string information = SearchTextBox.Text;        // lấy thông tin của ô search
                bool check = false;

                //kiểm tra ô tìm kiểm có dấu khoảng trắng
                for (int i = 0; i < information.Length; i++)
                    if (information[i] != ' ')
                        check = true;
                if (information == "Nhập code")
                    check = false;
                bool checkServer;
                if (check)          // kiểm tra nếu kiểm tra ô không phải khoảng trắng thì gửi thông tin, còn không thì xuất cảnh báo và thoát hàm
                    checkServer = client.Send(SearchTextBox.Text);  //checkSever kiểm tra xem gửi client gửi thông tin qua sever thành công hay không
                else
                {
                    MessageBox.Show("Bạn chưa nhập mã số", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SearchTextBox.Text = "Nhập code";
                    SearchTextBox.ForeColor = Color.Silver;
                    return;
                }

                if (checkServer == true)        //nếu gửi thông tin thành công thì mới làm
                {

                    //Nhan lai thong tin tu server
                    byte[] recieve = client.Recieve();
                    string data = Encoding.UTF8.GetString(recieve);

                    if (data != "false")        // nếu tìm thấy đối tượng
                    {
                        PhoneBookClient phoneBookClient = new PhoneBookClient();
                        phoneBookClient = JsonConvert.DeserializeObject<PhoneBookClient>(data);     // chuyển thông tin từ chuỗi vào class
                        showObject(phoneBookClient);        //hiện thông tin

                        NextButton.Enabled = BackButton.Enabled = false;
                        ord.Visible = false;

                        GoTextbox.Enabled = false;
                        GoButton.Enabled = false;
                        GoTextbox.Enabled = false;
                        DisplayButton.Enabled = true;
                    } //nếu không tìm thấy thì data="false"
                    else MessageBox.Show("Không có trong danh sách", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Không kết nối được với server!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Chưa tạo kết nối!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            SearchTextBox.ForeColor = Color.Gray;
            SearchTextBox.Text = "Nhập code";
        }


        // Hàm xuất sinh viên:
        private void showObject(PhoneBookClient phoneBookClient)
        {
            CodeView.Text = phoneBookClient.code.ToString();
            NameView.Text = phoneBookClient.name;
            PhoneView.Text = phoneBookClient.phone;
            EmailView.Text = phoneBookClient.email;
            if (phoneBookClient.avatar != null) // kiểm tra xem có avatar hay không
                pictureBox.Image = new Bitmap(Image.FromStream(new MemoryStream(phoneBookClient.avatar)), new Size(300, 300));
            /*chuyển avatar từ byte[] về MemoryStream -> chuyển về image -> chuyển về bitmap để hiển thị
                //MemoryStream là một lớp mở rộng trực tiếp từ lớp Stream, nó là luồng (stream) mà dữ liệu được lưu trữ (store) trên bộ nhớ.
                    //Về bản chất MemoryStream là một đối tượng nó quản lý một bộ đệm (buffer) là một mảng các byte,
                    //khi các byte được ghi vào luồng này nó sẽ tự động được gán vào các vị trí tiếp theo tính từ vị trí hiện tại của con trỏ trên mảng.
                    //Khi bộ đệm đầy một mảng mới có kích thước lớn hơn được tạo ra, và copy các dữ liệu từ mảng cũ sang.
                //Image.FromStream hoạt động dựa trên một cá thể Stream để lấy dữ liệu hình ảnh. Điều này có nghĩa là bạn có thể lấy Hình ảnh từ một mảng byte trong bộ nhớ với MemoryStream
                //dùng bitmap để để xuất ảnh từ Image.FromStream*/
            else pictureBox.Image = pictureBox.ErrorImage;
        }


        // Click vào nút Default:
		private void button3_Click(object sender, EventArgs e)
		{
            IPTextbox.Text = "127.1.1.2";
            PortTextbox.Text = "4004";
        }


        // Click vào nút Next:
        private void Next_Click(object sender, EventArgs e)
        {
            BackButton.Enabled = true; // Bật nút Back.

            showObject(phoneBookClients[++i]); // Xuất sinh viên liền sau.
            ord.Text = (i + 1).ToString() + "/" + count.ToString(); // Cập nhật lại chỉ số ord.

            if (i == count - 1) NextButton.Enabled = false; // Tắt nút Next nếu đến sinh viên cuối cùng.
        }


        // click vào nút Back:
        private void Back_Click(object sender, EventArgs e)
        {
            NextButton.Enabled = true; // Bật nút Next.

            showObject(phoneBookClients[--i]); // Xuất sinh viên liền trước.
            ord.Text = (i + 1).ToString() + "/" + count.ToString(); // Cập nhật lại chỉ số ord.

            if (i == 0) BackButton.Enabled = false; // tắt nút Back nếu đến sinh viên đầu tiên.
        }


        // Click vào nút Go:
        private void GoButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tmp = Int32.Parse(GoTextbox.Text); // Chuyển nội dung trong GoTextbox sang int.

                if (tmp < 1 || tmp > count) // Nếu (tmp < 1) hoặc (tmp > tổng số sinh viên).
                    MessageBox.Show("Số vừa nhập không hợp lệ!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    i = tmp - 1; // i nhỏ hơn tmp 1 đơn vị vì i bắt đầu từ 0, còn tmp bắt đầu từ 1, nên phải trừ đi 1.
                    showObject(phoneBookClients[i]); // Xuất sinh viên thứ i.
                    ord.Text = tmp.ToString() + "/" + count.ToString(); // Cập nhật lại ord.

                    if (i == 0) BackButton.Enabled = false; // nếu i là sinh viên đầu tiên thì tắt nút Back.
                    else BackButton.Enabled = true; // Nếu không thì bật nút Back lên.

                    if (i == count - 1) NextButton.Enabled = false; // nếu i là sinh viên cuối cùng thì tắt nút Next.
                    else NextButton.Enabled = true; // Nếu không thì bật nút Next lên.
                }

                GoTextbox.ForeColor = Color.Gray; // Chuyển màu trong GoTextbox sang màu xám.
                GoTextbox.Text = "Nhập vị trí"; // Chuyển nội dung trong GoTextbox thành "Nhập vị trí".
            }
            catch
            {
                // Nếu lỗi:
                MessageBox.Show("Bước nhảy không hợp lệ!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Enter vào SearchTextbox (giống với click):
        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "Nhập code")
                SearchTextBox.Text = ""; // Xóa dòng chữ "Nhập code".
            SearchTextBox.ForeColor = Color.Black; // Chuyển màu kí tự sang màu đen.
        }


        // Rời khỏi SearchTextbox:
        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                SearchTextBox.Text = "Nhập code"; // Thêm dòng chữ "Nhập code".
                SearchTextBox.ForeColor = Color.Silver; // Chuyển màu kí tự sang màu bạc.
            }
        }


        // Enter vào GoTextbox (giống với click):
        private void GoTextbox_Enter(object sender, EventArgs e)
        {
            if (GoTextbox.Text == "Nhập vị trí")
                GoTextbox.Text = ""; // Xóa dòng chữ "Nhập vị trí".
            GoTextbox.ForeColor = Color.Black; // Chuyển màu kí tự sang màu đen.
        }


        // Rời khỏi GoTextbox:
        private void GoTextbox_Leave(object sender, EventArgs e)
        {
            if (GoTextbox.Text == "")
            {
                GoTextbox.Text = "Nhập vị trí"; // Thêm dòng chữ "Nhập vị trí".
                GoTextbox.ForeColor = Color.Gray; // Chuyển màu kí tự sang màu xám.
            }
        }


        // Đóng form:
        private void TCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (run == true)
            {
                // Bật tắt các nút chức năng, textbox:
                ConnectButton.Enabled = true;
                DefaultButton.Enabled = true;
                DisconnectedButton.Enabled = false;
                PortTextbox.Enabled = true;
                IPTextbox.Enabled = true;

                run = false; // Gán run = false;
                client.Send("Disconnect"); // client gửi đi thông điệp "Disconnect" cho server.
                client.Disconnect(); // Đóng client.

                this.Close(); // Đóng form.
            }
        }

        private void PortTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
