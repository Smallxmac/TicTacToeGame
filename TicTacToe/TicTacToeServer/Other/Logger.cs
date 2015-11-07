using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer.Other
{
    public class Logger
    {
        //TODO: Actually log everything into a file with priories

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[{0}][ERROR] {1}", DateTime.Now, message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[{0}][INFO] {1}", DateTime.Now, message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[{0}][WARNING] {1}", DateTime.Now, message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[{0}][SUCCESS] {1}", DateTime.Now, message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
