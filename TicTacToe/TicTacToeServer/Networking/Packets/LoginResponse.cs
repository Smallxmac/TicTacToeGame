using TicTacToeServer.Database.Task_Managers;
using TicTacToeServer.Enums;

namespace TicTacToeServer.Networking.Packets
{
    class LoginResponse : PacketBuilder
    {
        public LoginResponse() : base(PacketType.LoginResponse, 8)
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

        public LoginResponseType ResponseType
        {
            get { _responseTypeType = (LoginResponseType)ReadByte(8); return _responseTypeType; }
            set { WriteByte((byte)value, 8); _responseTypeType = value; }
        }

        public static void Handle(SocketClient client, LoginResponse response)
        {
            if(response.ResponseType == LoginResponseType.AccountNotVerified)
                EmailSender.SendWelcomeEmail(AccountManager.GetAccount(response.AccountId));
        }
    }
}
