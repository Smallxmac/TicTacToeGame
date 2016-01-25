using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    /// <summary>
    /// Packet sent from the server to update the status of the login request.
    /// Server Send
    /// Client Receive
    /// </summary>
    public class LoginResponse : PacketBuilder
    {
        public LoginResponse(int length) : base(PacketType.LoginResponse, length)
        {
        }

        public LoginResponse(byte[] bytes) : base(bytes)
        {
        }

        private int _accountId;
        private LoginResponseType _responseTypeType;

        public int AccountId
        {
            get { _accountId = ReadInt(4); return _accountId; }
            set { WriteInt(value, 4); _accountId = value; }
            

        }

        public LoginResponseType ResponseTypeType
        {
            get { _responseTypeType = (LoginResponseType) ReadByte(8); return _responseTypeType; }
            set { WriteByte((byte) value, 8); _responseTypeType = value; }
        }
    }
}
