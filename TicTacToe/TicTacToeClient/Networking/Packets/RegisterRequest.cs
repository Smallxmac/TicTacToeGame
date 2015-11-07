using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    public class RegisterRequest : PacketBuilder
    {
        public RegisterRequest(int length) : base(PacketType.RegisterRequest, length)
        {
        }

        public RegisterRequest(byte[] bytes) : base(bytes)
        {
        }

        private int _no;
        private string[] _registerInformation;

        public string[] RegisterInformation
        {
            get
            {
                ReadStringArray(4, out _no); return _registerInformation; }
            set
            {
                WriteStringArray(value, 4, out _no); _registerInformation = value; }
        }
    }
}
