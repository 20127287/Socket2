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
    class PhoneBookSever
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

        public PhoneBookClient(PhoneBookSever phoneBookSever)
        {
            code = phoneBookSever.code;
            name = phoneBookSever.name;
            phone = phoneBookSever.phone;
            email = phoneBookSever.email;
                        
            try
            {
                MemoryStream ms = new MemoryStream();
                Bitmap bmp = new Bitmap(phoneBookSever.avatar);
                bmp.Save(ms, ImageFormat.Jpeg);
                avatar = ms.ToArray();
            }
            catch
            {
                avatar = null;
            }            
        }
    }

    class Server
    {
        private IPAddress IP;
        private int Port;
        private List<Socket> ClientSockets;
        private Socket ServerSocket;
        private string DB;
        private int Buffer;
        private byte[] Request;
        
        public Server(IPAddress ip, int port, string db, int buffer)
        {
            IP = ip;
            Port = port;
            DB = db;
            Buffer = buffer;
            Request = new byte[Buffer];
            ClientSockets = new List<Socket>();           
        }

        public void Start()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(new IPEndPoint(IP, Port));
            ServerSocket.Listen(0);
            ServerSocket.BeginAccept(Accept_Callback, null);
        }
        public void CloseAll()
        {
            foreach (Socket socket in ClientSockets)
            {
                socket.Close();
            }
            ClientSockets.Clear();
            ServerSocket.Close();
        }

        private void Accept_Callback(IAsyncResult Result)
        {
            try
            {
                Socket socket = ServerSocket.EndAccept(Result);
                ClientSockets.Add(socket);
                socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                ServerSocket.BeginAccept(Accept_Callback, null);
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
                ReadJson("DB/DanhBa.json", phoneBookClients);

                if (req == "Disconnect")
                {
                    socket.Close();
                    ClientSockets.Remove(socket);
                }
                else
                if (req == "Display")
                {
                    string convert = JsonConvert.SerializeObject(phoneBookClients);

                    socket.Send(Encoding.UTF8.GetBytes(convert));
                    socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                }
                else
                {
                    foreach (PhoneBookClient phoneBookClient in phoneBookClients)
                        if (req == phoneBookClient.code)
                        {
                            string convert = JsonConvert.SerializeObject(phoneBookClient);
                            socket.Send(Encoding.UTF8.GetBytes(convert));

                            socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                            return;
                        }
                    socket.Send(Encoding.UTF8.GetBytes("false"));
                    socket.BeginReceive(Request, 0, Buffer, SocketFlags.None, Receive_Callback, socket);
                }
                
            }
        }

        private string ReadRequest(IAsyncResult Result, Socket socket)
        {
            try
            {
                int received = socket.EndReceive(Result);
                byte[] resbuffer = new byte[received];
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

        private void ReadJson(string address, List<PhoneBookClient> phoneBookClients)
        {
            string data = System.IO.File.ReadAllText(address);
            List<PhoneBookSever> phoneBookSevers = JsonConvert.DeserializeObject<List<PhoneBookSever>>(data);            

            foreach (PhoneBookSever phoneBookSever in phoneBookSevers)
            {
                PhoneBookClient phoneBookClient = new PhoneBookClient(phoneBookSever);
                
                phoneBookClients.Add(phoneBookClient);
            }
        }
    }
}
