using System;
using System.Collections.Generic;
using Flexi.Output;

namespace Flexi.Users
{
    public static class UserManager
    {
        public static Dictionary<uint, User> Users;

        public static void Initialize()
        {
            Users = new Dictionary<uint, User>();
            Logging.Message("Successfully initialized the user manager!");
        }

        public static User GetUserByName(string Username)
        {
            lock (Users.Values)
            {
                foreach (User User in Users.Values)
                {
                    if (User.Username.ToLower() == Username.ToLower())
                        return User;
                }
            }

            return null;
        }

        public static void SendUserList(User UserToSendTo)
        {
            UserToSendTo.ClientConnection.SendData("NEWUSR;" + UserToSendTo.Username);

            lock (Users.Values)
            {
                foreach (User User in Users.Values)
                {
                    if (User == null || User == UserToSendTo) continue;
                    UserToSendTo.ClientConnection.SendData("NEWUSR;" + User.Username);
                }
            }
        }

        public static void SendMassData(string Data)
        {
            lock (Users.Values)
            {
                foreach (User User in Users.Values)
                {
                    if (User == null) continue;

                    User.ClientConnection.SendData(Data);
                }
            }
        }
    }
}
