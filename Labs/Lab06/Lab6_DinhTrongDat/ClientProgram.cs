using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_DinhTrongDat
{
    internal class ClientProgram
    {
		public delegate void SetDataControl(string Data);
		public SetDataControl SetDataFunction = null;
		//buffer để nhận và gởi dữ liệu
		byte[] buff = new byte[1024];
		//Số byte thực sự nhận được
		int byteReceive = 0;
		//Chuỗi nhận được
		string stringReceive = "";
		Socket serverSocket = new Socket(AddressFamily.InterNetwork,
		SocketType.Stream, ProtocolType.Tcp);
		IPEndPoint serverEP = null;
		//Lắng nghe kết nối
		public void Connect(IPAddress serverIP, int Port)
		{
			serverEP = new IPEndPoint(serverIP, Port);

			serverSocket.BeginConnect(serverEP, new
		   AsyncCallback(ConnectCallback), serverSocket);
		}
		//Hàm callback chấp nhận Client kết nối
		private void ConnectCallback(IAsyncResult ia)
		{
			//Lấy Socket đang thực hiện việc kết nối bất đồng bộ
			Socket s = (Socket)ia.AsyncState;
			try
			{
				//Set dữ liệu cho Control
				SetDataFunction("Đang chờ kết nối");
				//Hàm EndConnect sẽ bị block cho đến khi kết nối thành công
				s.EndConnect(ia);
				SetDataFunction("Kết nối thành công");
			}
			catch
			{
				SetDataFunction("Kết nối thất bại");
				return;
			}
			//Ngay sau khi kết nối xong bắt đầu nhận câu chào từ Server gởi xuống
			s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new
		   AsyncCallback(ReceiveData), s);
		}
		private void ReceiveData(IAsyncResult ia)
		{
			Socket s = (Socket)ia.AsyncState;
			byteReceive = s.EndReceive(ia);
			stringReceive = Encoding.ASCII.GetString(buff, 0, byteReceive);
			SetDataFunction(stringReceive);
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
		//Hàm ngắt kết nối
		public bool Disconnect()
		{
			try
			{
				//Shutdown Soket đang kết nối đến Server
				serverSocket.Shutdown(SocketShutdown.Both);
				serverSocket.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}
		//Hàm gởi dữ liệu
		public void SendData(string Data)
		{
			buff = Encoding.ASCII.GetBytes(Data);
			serverSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new
			AsyncCallback(SendToServer), serverSocket);
		}
		//Hàm CallBack gởi dữ liệu
		private void SendToServer(IAsyncResult ia)
		{
			Socket s = (Socket)ia.AsyncState;
			s.EndSend(ia);
			buff = new byte[1024];
			s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new
			AsyncCallback(ReceiveData), s);
		}
	}
}
