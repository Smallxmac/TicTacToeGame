using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
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
    }
}
