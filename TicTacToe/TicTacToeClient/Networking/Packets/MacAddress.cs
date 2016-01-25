using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    /// <summary>
    /// Packet sent in the connection process to tell the server who you are
    /// Server Receive
    /// Client Send
    /// </summary>
    public class MacAddress : PacketBuilder
    {
        public MacAddress() : base(PacketType.MaccAddress, 13)
        {
        }

        public MacAddress(byte[] bytes) : base(bytes)
        {
        }

        private int _no;
        public string MAddress
        {
            get { return ReadString(4, out _no); }
            set { WriteString(value, 4, out _no); }
        }
    }
}
