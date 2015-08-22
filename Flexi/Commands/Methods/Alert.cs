using System;
using Flexi.Output;
using Flexi.Users;

namespace Flexi.Commands.Methods
{
    public static class Alert
    {
        public static void Execute(User UserThatCalled, string[] Params)
        {
            if (Params.Length < 3)
                return;

            if (!Permissions.IsStaff(UserThatCalled))
                return;

            User TargetUser = UserManager.GetUserByName(Params[1]);
            string Message = "MESSAGE FROM A STAFF MEMBER:\n" + ConstructMessage(Params, 2);

            if (TargetUser == null)
                return;

            TargetUser.ClientConnection.SendData("SHWALERT;" + Message);
        }

        private static string ConstructMessage(string[] Params, int StartingIndex)
        {
            string Message = string.Empty;

            for (int i = 0; i < Params.Length; i++)
            {
                if (i < StartingIndex)
                    continue;

                Message = Message + Params[i] + " ";
            }
            
            return Message;
        }
    }
}
