using System;

namespace Flexi.Output
{
    public static class Logging
    {
        public static void Message(string Message, params object[] Params)
        {
            DateTime CurrentDateAndTime = DateTime.Now;
            string CurrentTimeFormatted = CurrentDateAndTime.ToString("H:mm:ss");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[Flexi - " + CurrentTimeFormatted + "] ");

            for (int i = 0; i < Params.Length; i++)
            {
                Message = Message.Replace("{" + i + "}", Params[i].ToString());
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Message);
        }

        public static void Exception(Exception Ex, string Reason)
        {
            DateTime CurrentDateAndTime = DateTime.Now;
            string CurrentTimeFormatted = CurrentDateAndTime.ToString("H:mm:ss");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[Flexi - " + CurrentTimeFormatted + "] ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR OCCURRED: " + Reason + "! Check logs for a detailed report!");
        }

        public static void MySQL(Exception Ex, string Reason)
        {
            DateTime CurrentDateAndTime = DateTime.Now;
            string CurrentTimeFormatted = CurrentDateAndTime.ToString("H:mm:ss");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[Flexi - " + CurrentTimeFormatted + "] ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SQL ERROR OCCURRED: " + Reason + "! Check logs for a detailed report!");
        }
    }
}
