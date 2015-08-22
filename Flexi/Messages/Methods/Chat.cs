using System;
using System.Collections.Generic;
using Flexi.Users;
using Flexi.Output;
using Flexi.Commands;
using Flexi.SQL;

namespace Flexi.Messages.Methods
{
    public static class Chat
    {
        public static void Execute(string MessageBody, object[] Objects)
        {
            if (MessageBody.Length >= 3)
            {
                User User = (User)Objects[1];

                if (User == null)
                    return;

                if (MessageBody.StartsWith("/"))
                {
                    CommandParser.Parse(User, MessageBody);
                    return;
                }

                // Add to stack
                Dictionary<string, string> Parameters = new Dictionary<string, string>();
                Parameters.Add("userid", User.UserID.ToString());
                Parameters.Add("message", MessageBody);
                SQLQueue.QueryStack.TryAdd(Parameters, "INSERT INTO chatlogs (userid, message) VALUES (@userid, @message);");

                UserManager.SendMassData("CHAT;[" + User.Username + "]: " + MessageBody);
                Logging.Message("CHAT: [" + User.Username + "]: " + MessageBody);
            }
        }
    }
}
