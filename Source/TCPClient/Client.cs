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
        private Socket socket;
        private IPAddress IP;
        private int Port;
        private int Buffer;
        private byte[] Buffers;

        public Client(IPAddress ip, int port, int size = 500000)
        {
            IP = ip;
            Port = port;
            Buffer = size;
            Buffers = new byte[Buffer];
        }

        public bool Connect()
        {           
            try
            {
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
            socket.Shutdown(SocketShutdown.Both);
            socket.Disconnect(false);
            socket.Close();
        }

        public bool Send(string message) // Gửi thông điệp từ client qua server.
        {
            try
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
            int bytes = socket.Receive(Buffers, Buffer, SocketFlags.None);
            byte[] req = new byte[bytes];
            Array.Copy(Buffers, req, bytes);

            return req;
        }
    }
}
 