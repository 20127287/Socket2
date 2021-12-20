using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project1
{
    class PhoneBookSever        //tạo class để đọc từ file JSON
    {
        public string code { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }

        public PhoneBookSever()
        {
            code = "";
            name = "";
            phone = "";
            email = "";
            avatar = "";
        }
    }

    class PhoneBookClient        //class để chuyển đổi từ sever qua client để client sử dụng
                                 //(chuyển avatar từ đường dẫn sang mảng byte để chuyển qua client có thể hiển thị)
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

        public PhoneBookClient(PhoneBookSever phoneBookSever)
        {
            code = phoneBookSever.code;
            name = phoneBookSever.name;
            phone = phoneBookSever.phone;
            email = phoneBookSever.email;

            // đọc ảnh sau đó chuyển về kiểu byte

            try     //bắt lỗi khi đường dẫn không có ảnh, hoặc sai đường dẫn
            {
                MemoryStream ms = new MemoryStream();//MemoryStream là một lớp mở rộng trực tiếp từ lớp Stream, nó là luồng (stream) mà dữ liệu được lưu trữ (store) trên bộ nhớ.
                //MemoryStream là một đối tượng nó quản lý một bộ đệm (buffer) là một mảng các byte,
                //khi các byte được ghi vào luồng này nó sẽ tự động được gán vào các vị trí tiếp theo tính từ vị trí hiện tại của con trỏ trên mảng.
                //Khi bộ đệm đầy một mảng mới có kích thước lớn hơn được tạo ra, và copy các dữ liệu từ mảng cũ sang.
                Bitmap bmp = new Bitmap(phoneBookSever.avatar); //dùng bitmap để để lấy ảnh từ đường dẫn (có dữ liệu pixel cho hình ảnh đồ họa và các thuộc tính của nó)
                bmp.Save(ms, ImageFormat.Jpeg);     // sau đó chuyển về kiểu memoryStream
                avatar = ms.ToArray();              // cuối cùng là chuyển về kiểu mảng byte
            }
            catch
            {
                avatar = null;                      //nếu không có thì cho avatar là null để qua client xử lý
            }
        }
    }

    class Server
    {
        private IPAddress IP;
        private int Port;
        private List<Socket> ClientSockets; // List chứa các socket của client.
        private Socket ServerSocket; // Socket của server.
        private string DB;
        private int Buffer;//kha nang nhan du lieu toi da
        private byte[] Request;     //yêu cầu của client
        

        // Constructer của lớp Server:
        public Server(IPAddress ip, int port, string db, int buffer)
        {
            IP = ip;
            Port = port;
            DB = db;
            Buffer = buffer;
            Request = new byte[Buffer];
            ClientSockets = new List<Socket>();           
        }
        /*
        cách kết nối:
       + client mún kết nối với server phải thông qua 1 cái socket
       + Cần tạo socket cho server 
       +Lắng nghe kết nối từ client,  đợi khi có client kết nối rồi mới làm các công việc kế tiếp
       + Khi nghe dc yêu cầu kết nối từ client thì tạo ra việc xử lý các công việc kế tiếp 
        * */

        // Khi server bắt đầu:
        public void Start()
        {
            //Tao socket mới cho server
            //AddressFamily.InterNetwork có thể kết nối với kiểu IP ipv4, ipv6
            //TCP có kiểu socket là stream để đọc viết 
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Khởi tạo socket cho server.
            ServerSocket.Bind(new IPEndPoint(IP, Port));//Hàm kết nối
            ServerSocket.Listen(0);
            ServerSocket.BeginAccept(Accept_Callback, null);//Chấp nhận kết nối từ server
            //AcceptCallBack: truyền địa chỉ hàm
        }


        // Hàm đóng server:
        public void CloseAll()
        {   //hàm đóng tất cả các client
            
            foreach (Socket socket in ClientSockets) //for và đóng từng client
            {
                socket.Close();
            }
            ClientSockets.Clear();      //xóa toàn bộ client trong danh sách
            ServerSocket.Close();       //đóng socket của sever lại
        }


        // Hàm nhập yêu cầu kết nối của client:
        private void Accept_Callback(IAsyncResult Result)//kết quả trả về của việc callback , lưu lại kết quả cuối cùng sau khi quá trình bất đồng bộ hoàn thành
        {// IAsyncResult định danh giá trị của client ứng với socket nào
            try
            {
                //chấp nhận kết nối từ client
                //Truyền vào Result để lấy giá trị trả về 
                Socket socket = ServerSocket.EndAccept(Result);// tạo ra 1 giá trị trả về gắn vào socket
                ClientSockets.Add(socket); // Add socket của client vào ClientSockets.

                //Xử lý nhận trên socket
                    //Request yêu cầu của client
                    // bắt đầu đọc từ 0 sang Buffer giá trị
                    //SocketFlags.None để khóa server. khi client ko gửi gì thì khóa lại còn có gửi thì tiếp tục xử lý
                socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                //Xử lý nhận
                ServerSocket.BeginAccept(Accept_Callback, null);//AcceptCallBack: truyền địa chỉ hàm gọi lại listen
            }
            catch { }
        }
        
        private void Receive_Callback(IAsyncResult Result)
        {
            Socket socket = (Socket)Result.AsyncState;
            string req = ReadRequest(Result, socket);
            if (req != null)
            {
                List<PhoneBookClient> phoneBookClients = new List<PhoneBookClient>();
                ReadJson("DB/DanhBa.json", phoneBookClients); // Đọc file json.

                if (req == "Disconnect") // Nếu server nhận được thông điệp "Disconnect" từ client.
                {
                    socket.Close(); // Đóng socket.
                    ClientSockets.Remove(socket); // Remove socket đó ra khỏi ClientSockets.
                }
                else
                if (req == "Display") // Nếu server nhận được thông điệp "Display" từ client.
                {
                    string convert = JsonConvert.SerializeObject(phoneBookClients); // Chuyển đổi dữ liệu trong file json.

                    socket.Send(Encoding.UTF8.GetBytes(convert)); // Gửi dữ liệu đến client.
                    socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                }
                else // Nếu server nhận được thông điệp "Search" từ client.
                {
                    foreach (PhoneBookClient phoneBookClient in phoneBookClients)
                        if (req == phoneBookClient.code) // Nếu tìm thấy.
                        {
                            string convert = JsonConvert.SerializeObject(phoneBookClient);
                            socket.Send(Encoding.UTF8.GetBytes(convert)); // Gửi phần dữ liệu tìm được cho client.

                            socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                            return;
                        }
                    socket.Send(Encoding.UTF8.GetBytes("false"));
                    socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                }
                
            }
        }


        // Hàm đọc các request mà client gửi cho server:
        private string ReadRequest(IAsyncResult Result, Socket socket)
        {   //đọc yêu cầu của client gửi qua sever
            try
            {
                int received = socket.EndReceive(Result); // Chuyển đổi Result sang int để khởi tạo kích thước của mảng
                byte[] resbuffer = new byte[received]; // Khởi tạo mảng byte.
                Array.Copy(Request, resbuffer, received);
                string req = Encoding.UTF8.GetString(resbuffer);
                return req;
            }
            catch
            {
                socket.Close();
            }
            return null;
        }


        // Hàm đọc file json:
        private void ReadJson(string address, List<PhoneBookClient> phoneBookClients)
        {
            string data = System.IO.File.ReadAllText(address); //lấy địa chỉ để đọc tệp json vào chuỗi string

            // Chuyển dữ liệu trong file json sang List<PhoneBookSever>:
            List<PhoneBookSever> phoneBookSevers = JsonConvert.DeserializeObject<List<PhoneBookSever>>(data);   

            foreach (PhoneBookSever phoneBookSever in phoneBookSevers)
            {
                //chuyển đối tương từ class phoneBookSever sang đối tượng của class phoneBookClient
                PhoneBookClient phoneBookClient = new PhoneBookClient(phoneBookSever);

                // Sau đó add vào phoneBookClients:
                phoneBookClients.Add(phoneBookClient);
            }
        }
    }
}
