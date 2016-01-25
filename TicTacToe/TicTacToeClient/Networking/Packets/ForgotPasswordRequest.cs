using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    /// <summary>
    /// Information sent to the server once the client has requested his password be reset.
    /// Server Receive
    /// Client Send.
    /// </summary>
    public class ForgotPasswordRequest : PacketBuilder
    {
        public ForgotPasswordRequest(int length) : base(PacketType.ForgotPasswordRequest, length)
        {
        }

        public ForgotPasswordRequest(byte[] bytes) : base(bytes)
        {
        }

        private int _no;
        private string _email;

        public string Email
        {
            get { _email = ReadString(4, out _no); return _email; }
            set {WriteString(value,4,out _no); _email = value; }
        }
    }
}
