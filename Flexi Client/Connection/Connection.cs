using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using Flexi_Client.Messages;

namespace Flexi_Client.Connection
{
    public static class Connection
    {
        public static Socket Socket;
        public static byte[] DataBuffer = new byte[1024];

        public static void Connect()
        {
            try
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000);

                Socket.BeginConnect(EndPoint, StartReceiving, null);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect to our server!");
            }
        }

        private static void StartReceiving(IAsyncResult IAR)
        {
            try
            {
                Socket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, IncomingData, null);
            }
            catch
            {
                MessageBox.Show("Error with receiving buffer!");
            }
        }

        private static void IncomingData(IAsyncResult IAR)
        {
            try
            {
                SocketError SocketStatus;
                int BytesReceived = Socket.EndReceive(IAR, out SocketStatus);

                if (BytesReceived > 0 && SocketStatus == SocketError.Success)
                {
                    MessageHandler.Parse(DataBuffer);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error with receiving buffer!");
            }
            finally
            {
                if (Socket != null)
                    StartReceiving(null);
            }
        }

        public static void SendData(string Data)
        {
            try
            {
                Data = "<START>" + Data + "<END>";
                byte[] DataBytes = Encoding.ASCII.GetBytes(Data);
                Socket.BeginSend(DataBytes, 0, DataBytes.Length, SocketFlags.None, SentData, null);
            }
            catch
            {
                MessageBox.Show("Failed to send the data");
            }
        }

        private static void SentData(IAsyncResult AR)
        {
            try
            {
                Socket.EndSend(AR);
            }
            catch
            {
            }
        }
    }
}
