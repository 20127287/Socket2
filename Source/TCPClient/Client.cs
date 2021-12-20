using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TCPClient
{
    class Client
    {
        private Socket socket;      // cổng kết nối của client đến server
        private IPAddress IP;
        private int Port;           
        private int Buffer;         // kích thước dữ liệu tối đa của mảng byte
        private byte[] Buffers;     // chứa dữ liệu của server gửi qua

        public Client(IPAddress ip, int port, int size = 500000)
        {
            IP = ip;
            Port = port;
            Buffer = size;
            Buffers = new byte[Buffer];
        }

        public bool Connect()
        {
            try //bắt lỗi xem kết nối với sever có thành công hay không
            {
                // AddressFamily.InterNetwork có thể kết nối với kiểu IPv4 và IPv6
                // SocketType.Stream để đọc và viết trong giao thức tcp
                // ProtocolType.IP kiểu giao thức chung
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                
                socket.Connect(new IPEndPoint(IP,Port));
                MessageBox.Show("Kết nối thành công với sever", "THÔNG BÁO", MessageBoxButtons.OK);
                return true;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối với server!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void Disconnect()
        {
            socket.Shutdown(SocketShutdown.Both);   //ngắt kết nối socket
            socket.Disconnect(false);               //tắt kết nối
            socket.Close();                         //đóng socket
        }

        public bool Send(string message) // Gửi thông điệp từ client qua server.
        {
            try //bắt lỗi thông điệp gửi đi ví dụng có kiểu không tương thích
            {
                socket.Send(Encoding.UTF8.GetBytes(message)); // Thông điệp được gửi đi.
                return true;
            }
            catch
            {
                return false;
            }
        }

        public byte[] Recieve()
        {
            // lưu kích thước của mảng byte[]
            // Buffers dữ liệu của server gửi qua
            // Buffer kích thước dữ liệu tối đa của mảng byte
            // SocketFlags.None không chờ thông tin của bên kia gửi qua
            int bytes = socket.Receive(Buffers, Buffer, SocketFlags.None);

            // tạo mảng byte
            byte[] req = new byte[bytes];

            //chép thông tin từ Buffers qua req với kích thước bytes
            Array.Copy(Buffers, req, bytes);

            return req;
        }
    }
}
 