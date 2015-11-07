using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Enums;
using TicTacToeServer.Networking;

namespace TicTacToeServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartListening();
            while (true)
            {
                Console.Read();
                return;
            }
        }
    }
}
