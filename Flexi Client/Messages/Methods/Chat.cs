using System;

namespace Flexi_Client.Messages.Methods
{
    public static class Chat
    {
        public static Action<string> AddMessage;

        public static void Execute(string MessageBody)
        {
            if (MessageBody.Length >= 3 && Global.LoggedIn)
            {
                AddMessage.BeginInvoke(MessageBody, null, null);
            }
        }
    }
}
