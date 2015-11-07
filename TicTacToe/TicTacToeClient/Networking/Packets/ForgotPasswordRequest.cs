using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
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
