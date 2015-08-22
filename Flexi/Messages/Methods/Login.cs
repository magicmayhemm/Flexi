using System;
using System.Data;
using Flexi.SQL;
using Flexi.Users;
using Flexi.Connections;
using Flexi.Output;

namespace Flexi.Messages.Methods
{
    public static class Login
    {
        // USERNAME@PASSWORD
        public static void Execute(string MessageBody, object[] Objects)
        {
            string[] MessageBodyArray = MessageBody.Split('@');

            string Username = MessageBodyArray[0];
            string Password = MessageBodyArray[1];

            DataRow User;
            using (DatabaseConnection DB = new DatabaseConnection())
            {
                DB.SetQuery("SELECT * FROM users WHERE username = @username AND password = @password");
                DB.AddParam("username", Username);
                DB.AddParam("password", Password);

                User = DB.GetRow();
            }
            
            Connection ClientConnection = (Connection)Objects[0];
            if (User == null)
            {
                ClientConnection.SendData("LOGIN;INVALID");
                return;
            }

            User ClientUser = UserFactory.GenerateUserFromRow(User, ClientConnection);
            if (ClientUser.Banned)
            {
                ClientConnection.SendData("LOGIN;BANNED");
                ClientUser = null;
                return;
            }

            if (UserManager.Users.ContainsKey(ClientUser.UserID))
            {
                ClientConnection.SendData("LOGIN;ALREADY");
                ClientUser = null;
                return;
            }


            Logging.Message("{0} logged in!", ClientUser.Username);
            ClientConnection.SendData("LOGIN;SUCCESS");

            UserManager.SendMassData("CHAT;" + ClientUser.Username + " joined the room!");
            UserManager.SendMassData("NEWUSR;" + ClientUser.Username);
            UserManager.Users.Add(ClientUser.UserID, ClientUser);
        }
    }
}