using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    /// <summary>
    /// Player data is sent once an account is fully logged in and contains useful information of from that account.
    /// Server Send
    /// Client Receive
    /// </summary>
    public class PlayerData : PacketBuilder
    {
        public PlayerData(int length) : base(PacketType.PlayerData, length + 8)
        {
        }

        public PlayerData(byte[] bytes) : base(bytes)
        {
        }

        private int _no;
        public int AccountId { get { return ReadInt(4);} set { WriteInt(value, 4);} }
        public string Username { get { return ReadString(8, out _no); } set { WriteString(value, 8, out _no); } }

    }
}
