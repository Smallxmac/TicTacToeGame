using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    /// <summary>
    /// Packet sent to tell the server to invite people or to have a pending invite.
    /// Server Send and Receive
    /// Client Send and Receive
    /// </summary>
    public class GameInvite : PacketBuilder
    {
        public GameInvite(int length) : base(PacketType.GameInvite, length+18)
        {
        }

        public GameInvite(byte[] bytes) : base(bytes)
        {
        }

        private int _no;

        public int RequesterId //4
        {
            get { return ReadInt(4);}
            set { WriteInt(value, 4); }
        }

        public int TargetId //8
        {
            get { return ReadInt(8); }
            set { WriteInt(value, 8); }
        }

        public int Timestamp //12
        {
            get { return ReadInt(12); }
            set { WriteInt(value, 12); }
        }

        public short RequestType //16
        {
            get { return ReadShort(16); }
            set { WriteInt(value, 16); }
        }

        public string[] InviteInfo //18
        {
            get { return ReadStringArray(18, out _no); }
            set { WriteStringArray(value, 18, out _no); }
        }
    }
}
