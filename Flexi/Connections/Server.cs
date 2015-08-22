using System;
using System.Net;
using System.Net.Sockets;
using Flexi.Output;
using Flexi.Messages;

namespace Flexi.Connections
{
    public class Server
    {
        private Socket ServerListener;
        private int AcceptedConnections;

        public Server()
        {
            StartServer();
        }

        private void StartServer()
        {
            ServerListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint IPEndPoint = new IPEndPoint(IPAddress.Any, 30000);

            try
            {
                ServerListener.Bind(IPEndPoint);
                ServerListener.Listen(100);
                ServerListener.BeginAccept(ConnectionRequest, ServerListener);

                Logging.Message("Server successfully started! Awaiting connections...");
            }
            catch (Exception Ex)
            {
                Logging.Exception(Ex, "Could not setup the server listener!");
            }
        }

        private void ConnectionRequest(IAsyncResult IAR)
        {
            AcceptedConnections++;

            Socket Client = ((Socket)IAR.AsyncState).EndAccept(IAR);
            string IPAddress = Client.RemoteEndPoint.ToString().Split(':')[0];

            new Connection(Client, IPAddress);

            ServerListener.BeginAccept(ConnectionRequest, ServerListener);
        }
    }
}
