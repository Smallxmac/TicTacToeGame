using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    /// <summary>
    /// Once the login form sends a request to login this is the packet that is sent.
    /// Server Receive
    /// Client Send
    /// </summary>
    public class LoginRequest : PacketBuilder
    {
        public LoginRequest(int length) : base(PacketType.LoginRequest, length)
        {
            
        }

        public LoginRequest(byte[] bytes) : base(bytes)
        {

        }

        private int _no;

        private string[] _accountInformation;

        public string[] AccountInformation
        {
            get
            {
                _accountInformation = ReadStringArray(4, out _no);
                return _accountInformation;
            }
            set
            {
                WriteStringArray(value, 4, out _no);
                _accountInformation = value;
            }
        }
    }
}
