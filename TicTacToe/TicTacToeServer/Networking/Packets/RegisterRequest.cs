using System;
using System.Security.Cryptography;
using System.Text;
using TicTacToeServer.Database.Task_Managers;
using TicTacToeServer.Enums;
using TicTacToeServer.Objects;

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
            var account = new Account
            {
                Username = registerInfo[0],
                Password = GetStringSha1Hash(registerInfo[1]),
                Email = registerInfo[2],
                RegisterIp = client.handler.RemoteEndPoint.ToString(),
                LastLoginIp = client.handler.RemoteEndPoint.ToString(),
                RegisterTime = DateTime.Now,
                LastLoginTime = DateTime.Now,
                Locked = false,
                Verified = false,
                VerificationCode = Guid.NewGuid().ToString()
        };

            var reply = new LoginResponse();
            if (!AccountManager.AccountExist(account.Username))
            {
                if (!AccountManager.EmailExist(account.Email))
                {
                    if (AccountManager.SaveAccount(account))
                    {
                        reply.ResponseType = LoginResponseType.AccountCreated;
                        EmailSender.SendWelcomeEmail(account);
                    }
                    else
                        reply.ResponseType = LoginResponseType.DatabaseError;
                }
                else
                    reply.ResponseType = LoginResponseType.EmailInUse;
            }
            else
                reply.ResponseType = LoginResponseType.UsernameInUse;
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
