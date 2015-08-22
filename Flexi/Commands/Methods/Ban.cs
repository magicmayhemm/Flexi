using System;
using Flexi.SQL;
using Flexi.Users;

namespace Flexi.Commands.Methods
{
    public static class Ban
    {
        public static void Execute(User UserThatCalled, params string[] Params)
        {
           if (Params.Length > 1)
           {
               if (!Permissions.IsStaff(UserThatCalled))
                   return;

               User TargetUser = UserManager.GetUserByName(Params[1]);
               if (TargetUser == null)
               {
                   UserThatCalled.ClientConnection.SendData("CHAT;Couldn't find that user!");
                   return;
               }
               if (UserThatCalled == TargetUser)
                   return;

               using(DatabaseConnection DB = new DatabaseConnection())
               {
                   DB.SetQuery("UPDATE users SET banned = '1' WHERE id = @id");
                   DB.AddParam("id", TargetUser.UserID);
                   DB.ExecuteQuery();
               }

               TargetUser.ClientConnection.SendData("CHAT;You were banned by " + UserThatCalled.Username + "!");
               TargetUser.ClientConnection.Disconnect();
               UserManager.SendMassData("CHAT;" + TargetUser.Username + " was banned by " + UserThatCalled.Username + "!");
           }
           else
           {
               UserThatCalled.ClientConnection.SendData("CHAT;Invalid syntax, correct: /ban USERNAME");
           }
        }
    }
}
