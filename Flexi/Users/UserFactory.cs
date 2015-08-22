using System;
using System.Data;
using Flexi.Connections;
using Flexi.Output;

namespace Flexi.Users
{
    public static class UserFactory
    {
        public static User GenerateUserFromRow(DataRow Row, Connection ClientConnection)
        {
            try
            {
                uint UserID = Convert.ToUInt32(Row["id"]);
                string Username = Convert.ToString(Row["username"]);
                uint Rank = Convert.ToUInt32(Row["rank"]);
                bool Banned = Convert.ToBoolean(Row["banned"]);

                return new User(UserID, ClientConnection, Username, Rank, Banned);
            }
            catch (Exception Ex)
            {
                Logging.Exception(Ex, "Error whilst generating user from row");
                return null;
            }
        }
    }
}
