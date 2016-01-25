using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    /// <summary>
    /// Packet used to list and add/approve/remove friends from players friends list.
    /// Server Send and Receive
    /// Client Send and Receive 
    /// </summary>
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
