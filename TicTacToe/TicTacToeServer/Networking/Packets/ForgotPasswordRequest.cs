using System;
using System.Linq;
using TicTacToeServer.Database;
using TicTacToeServer.Database.Respositorys;
using TicTacToeServer.Enums;
using TicTacToeServer.Other;

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
            try
            {
                var user = AccountRepository.GetAccount(null, request.Email);
                if (user != null)
                {
                    if (user.Locked)
                        reply.ResponseType = LoginResponseType.AccountLocked;

                    else if (user.Verified)
                    {
                        user.Locked = true;
                        user.Verified = false;
                        user.Verificationcode = Guid.NewGuid().ToString();
                        reply.AccountId = user.Accountid;
                        reply.ResponseType = LoginResponseType.ResetSent;
                        EmailSender.SendRestEmail(user);
                        BaseRepository.Update(user);
                    }
                    else
                        reply.ResponseType = LoginResponseType.AccountNotVerified;
                }
                else
                    reply.ResponseType = LoginResponseType.ResetInvalid;

            }
            catch (Exception e)
            {
                reply.ResponseType = LoginResponseType.DatabaseError;
                Logger.Error(e.Message);
            }
            client.Send(reply);
        }
    }
}
