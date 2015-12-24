using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer.Enums
{
    public enum PacketType : short
    {
        MaccAddress = 100,
        LoginRequest = 120,
        LoginResponse = 121,
        RegisterRequest = 123,
        RegisterResponse = 124,
        ForgotPasswordRequest = 125,
        ForgotPasswordResponse = 126
    }
}
