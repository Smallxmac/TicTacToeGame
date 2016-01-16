using System;
using System.Collections.Concurrent;
using System.Linq;
using TicTacToeServer.Database;
using TicTacToeServer.Networking;
using TicTacToeServer.Other;

namespace TicTacToeServer
{
    class Program
    {
        public static ConcurrentDictionary<int, SocketClient> OnlineAccounts { get; set; }

        static void Main(string[] args)
        {
            OnlineAccounts = new ConcurrentDictionary<int, SocketClient>();
            Server server = new Server();
            server.StartListening();
            NHibernateHelper.CreateSessionFactory();
            var golbalThreadManager = new GlobalThreading();
            golbalThreadManager.StartThreads();

            while (true)
            {
               var command = Console.ReadLine();
                switch (command)
                {
                    case "/online":
                    {
                        var statusString = $"{OnlineAccounts.Count} accounts online; ";
                        statusString = OnlineAccounts.Values.Aggregate(statusString, (current, player) => current + (player.Account.Username + "; "));
                        Logger.Info(statusString);
                        break;
                    }
                }
            }
        }
    }
}
