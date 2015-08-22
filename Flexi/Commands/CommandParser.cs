using System;
using System.Collections.Generic;
using Flexi.SQL;
using Flexi.Output;
using Flexi.Users;
using Flexi.Commands.Methods;

namespace Flexi.Commands
{
    public static class CommandParser
    {
        public static Dictionary<string, Action<User, string[]>> Commands;

        public static void RegisterCommands()
        {
            Commands = new Dictionary<string, Action<User, string[]>>();

            Commands.Add("ban", Ban.Execute);
            Commands.Add("alert", Alert.Execute);
            Commands.Add("execute", SaveLogs.Execute);

            Logging.Message("Successfully registered {0} commands!", Commands.Count);
        }

        public static void Parse(User User, string Text)
        {
            string TextNoSlash = Text.Substring(1);
            string[] Params = TextNoSlash.Split(' ');

            string Command = Params[0];

            if (Commands.ContainsKey(Command.ToLower()))
            {
                Action<User, string[]> MethodToInvoke = Commands[Command.ToLower()];
                MethodToInvoke.BeginInvoke(User, Params, null, null);
            }
            else
            {
                User.ClientConnection.SendData("CHAT;Invalid command!");
            }
        }
    }
}
