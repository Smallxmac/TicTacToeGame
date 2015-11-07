using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    public class LoginResponse : PacketBuilder
    {
        public LoginResponse(int length) : base(PacketType.LoginResponse, length)
        {
        }

        public LoginResponse(byte[] bytes) : base(bytes)
        {
        }

        private int _accountId;
        private Enums.LoginResponseType _responseTypeType;

        public int AccountId
        {
            get { _accountId = ReadInt(4); return _accountId; }
            set { WriteInt(value, 4); _accountId = value; }
            

        }

        public Enums.LoginResponseType ResponseTypeType
        {
            get { _responseTypeType = (Enums.LoginResponseType) ReadByte(8); return _responseTypeType; }
            set { WriteByte((byte) value, 8); _responseTypeType = value; }
        }
    }
}
