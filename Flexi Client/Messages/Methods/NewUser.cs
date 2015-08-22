using System;

namespace Flexi_Client.Messages.Methods
{
    public static class NewUser
    {
        public static Action<string> AddUser;

        public static void Execute(string MessageBody)
        {
            AddUser.BeginInvoke(MessageBody, null, null);
        }
    }
}
