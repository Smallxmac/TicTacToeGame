using System;
using TicTacToeServer.Database.Task_Managers;
using TicTacToeServer.Enums;

namespace TicTacToeServer.Networking.Packets
{
    public class ForgotPasswordRequest : PacketBuilder
    {
        public ForgotPasswordRequest(PacketType type, int length) : base(type, length)
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

        public static void Handel(SocketClient client, ForgotPasswordRequest request)
        {
            var reply = new LoginResponse();
            if (AccountManager.EmailExist(request.Email))
            {
                var account = AccountManager.GetAccountByEmail(request.Email);
                if(account.Locked)
                    reply.ResponseType = LoginResponseType.AccountLocked;
                else if (account.Verified)
                {
                    account.Locked = true;
                    account.Verified = false;
                    account.VerificationCode = Guid.NewGuid().ToString();
                    if (AccountManager.SaveAccount(account))
                    {
                        EmailSender.SendRestEmail(account);
                        reply.AccountId = account.AccountId;
                        reply.ResponseType = LoginResponseType.ResetSent;
                    }
                    else
                        reply.ResponseType = LoginResponseType.DatabaseError;
                    
                }
                else
                    reply.ResponseType = LoginResponseType.AccountNotVerified;
                
            }
            else
                reply.ResponseType = LoginResponseType.ResetInvalid;

            client.Send(reply);
        }
    }
}
