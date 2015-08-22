using System;
using Flexi.Users;

namespace Flexi.Messages.Methods
{
    public static class UsersRequestList
    {
        public static void Execute(string MessageBody, params object[] Objects)
        {
            User UserThatRequested = (User)Objects[1];

            if (UserThatRequested == null)
                return;

            UserManager.SendUserList(UserThatRequested);
        }
    }
}