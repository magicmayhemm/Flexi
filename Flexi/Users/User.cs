using System;
using System.Data;
using Flexi.Connections;
using Flexi.SQL;
using Flexi.Output;

namespace Flexi.Users
{
    public class User
    {
        public uint UserID;
        public Connection ClientConnection;
        public string Username;
        public uint Rank;
        public bool Banned;

        public User(uint UserID, Connection ClientConnection, string Username, uint Rank, bool Banned)
        {
            this.UserID = UserID;
            this.ClientConnection = ClientConnection;
            this.Username = Username;
            this.Rank = Rank;
            this.Banned = Banned;

            this.ClientConnection.ClientUser = this;
        }

        public void OnDisconnect()
        {
            if (!UserManager.Users.ContainsKey(UserID))
                return;

            UserManager.Users.Remove(UserID);
            UserManager.SendMassData("CHAT;" + Username + " has left the room!");
            UserManager.SendMassData("USRLEFT;" + Username);
            Logging.Message("{0} has logged out!", Username);
        }
    }
}
