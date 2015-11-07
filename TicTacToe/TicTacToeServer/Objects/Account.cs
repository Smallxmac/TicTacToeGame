using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer.Objects
{
    public class Account
    {
        public int AccountId;
        public string Username,Password,Email,RegisterIp,LastLoginIp,VerificationCode;
        public DateTime LastLoginTime, RegisterTime;
        public bool Verified, Locked;
    }
}
