using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Flexi.Output;
using Flexi.Users;
using Flexi.Messages;

namespace Flexi.Connections
{
    public class Connection
    {
        private Socket ClientSocket;
        public User ClientUser;
        private string ClientIP;
        private byte[] DataBuffer;
   
        public Connection(Socket Socket, string IP)
        {
            ClientSocket = Socket;
            ClientIP = IP;
            DataBuffer = new byte[1024];

            StartReceiving();
        }

        private void StartReceiving()
        {
            try
            {
                ClientSocket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, DataArrived, ClientSocket);
            }
            catch
            {
                Disconnect();
            }
        }

        private void DataArrived(IAsyncResult IAR)
        {
            try
            {
                SocketError SocketStatus;
                int BytesArrived = ClientSocket.EndReceive(IAR, out SocketStatus);

                if (BytesArrived > 0 && SocketStatus == SocketError.Success)
                {
                    MessageHandler.Parse(DataBuffer, this, ClientUser);
                }
            }
            catch
            {
                Disconnect();
            }
            finally
            {
                if (ClientSocket != null)
                    StartReceiving();
            }
        }

        public void SendData(string Data)
        {
            try
            {
                Data = "<START>" + Data + "<END>";
                byte[] DataByte = Encoding.ASCII.GetBytes(Data);
                ClientSocket.BeginSend(DataByte, 0, DataByte.Length, SocketFlags.None, SentData, null);
            }
            catch
            {
            }
        }

        private void SentData(IAsyncResult IAR)
        {
            try
            {
                ClientSocket.EndSend(IAR);
            }
            catch(Exception Ex)
            {
                Logging.Exception(Ex, "Error with ending the async send");
            }
        }

        public void Disconnect()
        {
            if (ClientSocket != null && ClientSocket.Connected)
            {
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Close();
                ClientSocket = null;
            }

            if (ClientUser != null)
            { 
                ClientUser.OnDisconnect();
                ClientUser = null;
            }
        }
    }
}
