using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TicTacToeServer.Database;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Database.Respositorys;
using TicTacToeServer.Enums;
using TicTacToeServer.Objects;
using TicTacToeServer.Other;

namespace TicTacToeServer.Networking.Packets
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
                _registerInformation = ReadStringArray(4, out _no); return _registerInformation; }
            set
            {
                WriteStringArray(value, 4, out _no); _registerInformation = value; }
        }

        public static void Handle( SocketClient client,RegisterRequest request)
        {
            var registerInfo = request.RegisterInformation;
            var user = new Accounts
            {
                Username = registerInfo[0],
                Password = GetStringSha1Hash(registerInfo[1]),
                Email = registerInfo[2],
                Registerip = client.handler.RemoteEndPoint.ToString(),
                Lastloginip = client.handler.RemoteEndPoint.ToString(),
                Registertime = DateTime.Now,
                Lastlogintime = DateTime.Now,
                Locked = false,
                Verified = false,
                Verificationcode = Guid.NewGuid().ToString()
        };

            var reply = new LoginResponse();
            try
            {
                if (AccountRepository.GetAccount(user.Username, null) == null)
                {
                    if (AccountRepository.GetAccount(null, user.Email) == null)
                    {
                        BaseRepository.Add(user);
                        reply.ResponseType = LoginResponseType.AccountCreated;
                        reply.AccountId = user.Accountid;
                        EmailSender.SendWelcomeEmail(user);
                    }
                    else
                        reply.ResponseType = LoginResponseType.EmailInUse;
                }
                else
                    reply.ResponseType = LoginResponseType.UsernameInUse;
            }
            catch (Exception e)
            {
                reply.ResponseType = LoginResponseType.DatabaseError;
                Logger.Error(e.Message);
            }
            client.Send(reply);
        }

        internal static string GetStringSha1Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            using (var sha1 = new SHA1Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);

                byte[] hash = sha1.ComputeHash(textData);

                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
