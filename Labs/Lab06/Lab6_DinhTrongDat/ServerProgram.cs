using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_DinhTrongDat
{
    internal class ServerProgram
    {
        private IPAddress serverIP;

        public IPAddress ServerIP
		{
			get
			{
				return serverIP;
			}
			set
			{
				this.serverIP = value;
			}
		}

		private int port;
		public int Port
		{
			get
			{
				return this.port;
			}
			set
			{
				this.port = value;
			}
		}
		//delegate để set dữ liệu cho các Control

		public delegate void SetDataControl(string Data);
		public SetDataControl SetDataFunction = null;
		public delegate void SetStatusControl(string Data);
		public SetStatusControl SetStatusFunction = null;
		Socket serverSocket = null;
		IPEndPoint serverEP = null;
		Socket clientSocket = null;
		//buffer để nhận và gởi dữ liệu
		byte[] buff = new byte[1024];
		//Số byte thực sự nhận được
		int byteReceive = 0;
		string stringReceive = "";

		public ServerProgram(IPAddress ServerIP, int Port)
		{
			this.ServerIP = ServerIP;
			this.Port = Port;
		}
		//Lắng nghe kết nối
		public void Listen()
		{
			serverSocket = new Socket(AddressFamily.InterNetwork,
			SocketType.Stream, ProtocolType.Tcp);
			serverEP = new IPEndPoint(ServerIP, Port);
			//Kết hợp Server Socket với Local Endpoint
			serverSocket.Bind(serverEP);
			//Lắng nghe kết nối trên Server Socket
			//-1: không giới hạn số lượng client kết nối đến
			serverSocket.Listen(-1);
			SetStatusFunction("Dang cho ket noi");
			//Bắt đầu chấp nhận Client kết nối đến
			serverSocket.BeginAccept(new AsyncCallback(AcceptScoket),
		   serverSocket);
		}
		//Hàm callback chấp nhận Client kết nối
		private void AcceptScoket(IAsyncResult ia)
		{
			Socket s = (Socket)ia.AsyncState;
			//Hàm Accept sẽ block server lại và chờ Client kết nối đến

			clientSocket = s.EndAccept(ia);
			string hello = "Hello Client";
			buff = Encoding.ASCII.GetBytes(hello);
			SetStatusFunction("Client " + clientSocket.RemoteEndPoint.ToString()
			+ "da ket noi den");
			clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new
			AsyncCallback(SendData), clientSocket);
		}
		private void SendData(IAsyncResult ia)
		{
			Socket s = (Socket)ia.AsyncState;
			s.EndSend(ia);
			//khởi tạo lại buffer để nhận dữ liệu
			buff = new byte[1024];
			//Bắt đầu nhận dữ liệu
			s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new
		   AsyncCallback(ReceiveData), s);
		}
		public void Close()
		{
			if (clientSocket != null)
			{
				clientSocket.Close();
				serverSocket.Close();
			}

		}
		private void ReceiveData(IAsyncResult ia)
		{
			Socket s = (Socket)ia.AsyncState;
			try
			{

				byteReceive = s.EndReceive(ia);
			}
			catch
			{
				//Trường hợp lỗi xảy ra khi Client ngắt kết nối
				this.Close();
				SetStatusFunction("Client ngat ket noi");
				this.Listen();
				return;
			}
			//Nếu Client shutdown thì hàm EndReceive sẽ trả về 0
			if (byteReceive == 0)
			{
				Close();
				SetStatusFunction("Clien dong ket noi");
			}
			else
			{
				stringReceive = Encoding.ASCII.GetString(buff, 0, byteReceive);
				SetDataFunction(stringReceive);

				s.BeginSend(buff, 0, buff.Length, SocketFlags.None, new
			   AsyncCallback(SendData), s);
			}
		}
	}
}
