using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Database;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Database.Respositorys;
using TicTacToeServer.Enums;
using TicTacToeServer.Networking.Packets;
using TicTacToeServer.Objects;

namespace TicTacToeServer.Networking
{
    public class SocketClient
    {
        // Size of receive buffer.
        public static int BufferSize = 1024;
        // Receive buffer.
        public byte[] Buffer = new byte[BufferSize];
        public byte[] PacketBuffer;
        
        public Socket Handler;
        public Accounts Account;
        public string MAddress;

        public SocketClient(Socket clientSocket)
        {
            Handler = clientSocket;
        }

        public int LoginAttempt = 0;

        public void Send(PacketBuilder packet)
        {
            Handler.BeginSend(packet.Build(), 0, packet.Build().Length, SocketFlags.None, SendCallback, this);
        }

        public void Disconnect()
        {
            SocketClient client;
            Program.OnlineAccounts.TryRemove(Account.Accountid, out client);
            Program.OnlineAccounts.TryAdd(client.Account.Accountid, client);
            var relations = PlayerRelationsRepository.GetAllRelations(client.Account.Accountid);
            foreach (var relation in relations)
            {
                AssociationType relationType;
                Enum.TryParse(relation.RelationType.ToString(), out relationType);
                switch (relationType)
                {
                    case AssociationType.Friend:
                    {
                        var account = AccountRepository.GetAccount(relation.RelationId);
                        if (account.Accountid == client.Account.Accountid)
                            account = AccountRepository.GetAccount(relation.AccountId);
                        if (Program.OnlineAccounts.ContainsKey(account.Accountid))
                        {
                            var targetAssossiation = new PlayerAssociation(client.Account.Username.Length)
                            {
                                AccountId = client.Account.Accountid,
                                AssociationExtra = 0,
                                AssociationType = relation.RelationType,
                                Username = client.Account.Username
                            };
                            Program.OnlineAccounts[account.Accountid].Send(targetAssossiation);
                        }
                        break;
                    }
                }
            }
            Handler.Shutdown(SocketShutdown.Both);
            Handler.BeginDisconnect(false, DisconnectCallback, this);
        }

        private static void DisconnectCallback(IAsyncResult ar)
        {
            var client = (SocketClient)ar.AsyncState;
            client.Handler.EndDisconnect(ar);
        }

        private void SendCallback(IAsyncResult ar)
        {
            if(Handler.Connected)
            {
                var bytesSent = Handler.EndSend(ar);
            }
        }
    }
}
