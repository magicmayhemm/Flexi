using System;
using System.Collections.Generic;
using Flexi.Connections;
using Flexi.Output;
using Flexi.SQL;
using Flexi.Users;
using Flexi.Messages;
using Flexi.Commands;

namespace Flexi
{
    public static class Global
    {
        private static Server Server;
        public static Dictionary<string, string> Data;

        public static void Boot()
        {
            #region Starting credentials
            Console.Title = "Flexi Server ~ 1.0.0";
            Logging.Message("Flexi Server ~ 1.0.0");
            Console.WriteLine();
            #endregion

            #region Load config
            Config Config = new Config();
            Config.GetAllData("Config/MySQL.txt");
            #endregion

            #region MySQL test run
            using (DatabaseConnection DB = new DatabaseConnection())
            {
            }
            Logging.Message("Successfully connected to the MySQL server!");
            #endregion

            #region Initialize user manager
            UserManager.Initialize();
            #endregion

            #region Initialize message handlers
            MessageHandler.RegisterMessages();
            #endregion

            #region Initialize commands
            CommandParser.RegisterCommands();
            #endregion

            #region Start server listener
            Console.WriteLine();

            Server = new Server();

            Console.WriteLine();
            #endregion
        }

        public static Server GetServer()
        {
            return Server;
        }
    }
}
