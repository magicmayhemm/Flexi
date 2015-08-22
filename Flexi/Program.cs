using System;

namespace Flexi
{
    class Program
    {
        static void Main()
        {
            Global.Boot();
            ConsoleKey();
        }

        private static void ConsoleKey()
        {
            ConsoleKeyInfo Info = Console.ReadKey(true);
            if (Info.Key == System.ConsoleKey.Enter)
            {
                ConsoleCommand();
            }
            else
                ConsoleKey();
        }
        private static void ConsoleCommand()
        {
            Console.WriteLine("(Flexi) CONSOLE INPUT ENABLED");
            Console.Write("(Flexi) > ");
            Console.ReadLine();
            ConsoleKey();
        }
    }
}
