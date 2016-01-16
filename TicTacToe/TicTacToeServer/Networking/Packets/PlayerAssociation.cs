using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Database.Respositorys;
using TicTacToeServer.Enums;
using TicTacToeServer.Other;

namespace TicTacToeServer.Networking.Packets
{
    public class PlayerAssociation : PacketBuilder
    {
        public PlayerAssociation(int length) : base(PacketType.PlayerAssociation, length+12)
        {
        }

        public PlayerAssociation(byte[] bytes) : base(bytes)
        {
        }

        private int _no;

        public short AssociationType { get { return ReadShort(4); } set {WriteShort(value, 4);} }
        public short AssociationExtra { get { return ReadShort(6); } set { WriteShort(value, 6); } }
        public int AccountId { get { return ReadInt(8); } set { WriteInt(value, 8); } }
        public string Username { get { return ReadString(12, out _no); } set { WriteString(value,12, out _no); } }

        public static void Handle(SocketClient client, PlayerAssociation playerAssociation)
        {
            AssociationType aType;
            Enum.TryParse(playerAssociation.AssociationType.ToString(), out aType);
            switch (aType)
            {
                case Enums.AssociationType.FriendRequest:
                {
                    var account = AccountRepository.GetAccount(playerAssociation.Username, string.Empty);
                        //Person targeted for friend.
                    if (account != null)
                    {
                        var relation = new PlayerAssociation(account.Username.Length)
                        {
                            AccountId = account.Accountid,
                            AssociationType = (short) Enums.AssociationType.FriendRequest,
                            Username = account.Username,
                            AssociationExtra = (short) client.Account.Accountid
                        };
                            client.Send(relation);
                        if (Program.OnlineAccounts.ContainsKey(account.Accountid))
                        {
                            var relation2 = new PlayerAssociation(client.Account.Username.Length)
                            {
                                AccountId = account.Accountid,
                                Username = client.Account.Username,
                                AssociationType = relation.AssociationType,
                                AssociationExtra = (short) client.Account.Accountid
                            };
                            var player = Program.OnlineAccounts[account.Accountid];
                            player.Send(relation2);
                        }
                        var relationDb = new PlayerRelations()
                        {
                            AccountId = relation.AccountId,
                            RelationId = relation.AssociationExtra,
                            RelationType = relation.AssociationType
                        };
                        BaseRepository.Add(relationDb);
                    }
                    break;
                }
                case Enums.AssociationType.FriendAccept:
                {
                    var relation = PlayerRelationsRepository.GetAllRelations(playerAssociation.AssociationExtra);
                    foreach (var re in relation)
                    {
                        if (re.RelationType == (int) Enums.AssociationType.FriendRequest)
                        {
                            if (re.AccountId == playerAssociation.AssociationExtra &&
                                re.RelationId == playerAssociation.AccountId || re.AccountId == playerAssociation.AccountId &&
                                re.RelationId == playerAssociation.AssociationExtra)
                            {
                                re.RelationType = (short) Enums.AssociationType.Friend;
                            }
                            BaseRepository.Update(re);
                            Accounts account;//Accepted Player
                            account = AccountRepository.GetAccount(re.AccountId  == client.Account.Accountid ? re.RelationId : re.AccountId);
                            //Accepting player's Packet
                                var relationPakcet = new PlayerAssociation(account.Username.Length)
                                {
                                    AccountId = account.Accountid,
                                    AssociationType = (short)Enums.AssociationType.Friend,
                                    Username = account.Username,
                                    AssociationExtra = (short) (Program.OnlineAccounts.ContainsKey(account.Accountid) ? 1 : 0)
                                };
                                client.Send(relationPakcet);
                            if (Program.OnlineAccounts.ContainsKey(account.Accountid))
                            {
                                var clientTarget = Program.OnlineAccounts[account.Accountid];
                                var relationPakcetTarget = new PlayerAssociation(client.Account.Username.Length)
                                {
                                    AssociationExtra = 1,
                                    AccountId = client.Account.Accountid,
                                    Username = client.Account.Username,
                                    AssociationType = (short) Enums.AssociationType.Friend
                                };
                                 clientTarget.Send(relationPakcetTarget);                                   
                            }
                            }
                    }
                    break;
                }
                case Enums.AssociationType.FriendDeny:
                {
                    break;
                }
            }
            

        }
    }
}
