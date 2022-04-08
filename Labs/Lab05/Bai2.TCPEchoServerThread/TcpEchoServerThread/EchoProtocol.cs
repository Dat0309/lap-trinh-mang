using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpEchoServerThread
{
    public class EchoProtocol
    {
        private Socket clientSocket;
        private ILogger logger;

        public const int BUFF_SIZE = 32;

        public EchoProtocol(Socket clientSocket, ILogger logger)
        {
            this.clientSocket = clientSocket;
            this.logger = logger;
        }

        public void HandleClient()
        {
            ArrayList entry = new ArrayList();
            entry.Add("Client address and port: " + clientSocket.RemoteEndPoint);
            entry.Add("Thread " + Thread.CurrentThread.GetHashCode());
            try
            {
                int receivedMessageSize;
                int totalBytes = 0;
                byte[] buff = new byte[BUFF_SIZE];
                try
                {
                    while((receivedMessageSize = clientSocket.Receive(buff,0,buff.Length, SocketFlags.None)) != 0)
                    {
                        clientSocket.Send(buff, 0, receivedMessageSize, SocketFlags.None);
                        totalBytes += receivedMessageSize;
                    }
                }
                catch (SocketException ex)
                {
                    entry.Add(ex.ErrorCode + " error: " + ex.Message);
                }catch(IOException e)
                {
                    entry.Add("ERROR:" + e.Message);
                }
                entry.Add("Echoed " + totalBytes + " bytes"); 
            }catch(SocketException ex)
            {
                entry.Add(ex.ErrorCode + "error: " + ex.Message);
            }
            clientSocket.Close();
            logger.Write(entry);
        }
    }
}
