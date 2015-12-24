using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using NHibernate.Hql.Ast.ANTLR.Tree;
using TicTacToeServer.Database;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Database.Respositorys;
using TicTacToeServer.Enums;
using TicTacToeServer.Other;

namespace TicTacToeServer.Networking.Packets
{
    public class LoginRequest : PacketBuilder
    {
        public LoginRequest(int length) : base(PacketType.LoginRequest, length)
        {
            
        }

        public LoginRequest(byte[] bytes) : base(bytes)
        {

        }

        private int _no;

        private string[] _accountInformation;

        public string[] AccountInformation
        {
            get
            {
                _accountInformation = ReadStringArray(4, out _no);
                return _accountInformation;
            }
            set
            {
                WriteStringArray(value, 4, out _no);
                _accountInformation = value;
            }
        }

        public static void Handel(SocketClient client, LoginRequest request, bool bypass)
        {
            var info = request.AccountInformation;
            var reply = new LoginResponse();
            var record = BlacklistIpsRepository.GetRecordByMac(client.MAddress) ??
                         new BlackListedIps {Attempts = 0, MacAddress = client.MAddress};
            var address = (IPEndPoint)client.Handler.RemoteEndPoint;
            record.Ip = address.Address.ToString();
            record.Attempts++;
            try
            {
                if (record.Attempts > 3 && !bypass)
                {
                    if (record.Attempts == 5)
                        record.BlacklistLiftTime = DateTime.Now.AddMinutes(15);
                    else if (record.Attempts == 8)
                        record.BlacklistLiftTime = DateTime.Now.AddMinutes(30);
                    else if (record.Attempts >= 11)
                        record.BlacklistLiftTime = DateTime.Now.AddMinutes(record.Attempts*10);
                    else
                    {
                        Handel(client, request, true);
                        return;
                    }
                    BaseRepository.Update(record);
                    reply.ResponseType = LoginResponseType.TooManyTries;
                    reply.AccountId = (int) record.BlacklistLiftTime.Subtract(DateTime.Now).TotalMinutes;
                }
                else
                {
                    
                    
                    BaseRepository.SaveOrUpdate(record);
                    var account = AccountRepository.GetAccount(info[0], null);
                    if (account != null)
                    {
                        if (account.Locked && !account.Verified)
                        {
                            var resetinfo = info[1].Split(':');
                            if (account.Verificationcode.Equals(resetinfo[0]))
                            {
                                account.Locked = false;
                                account.Verified = true;
                                account.Password = GetStringSha1Hash(resetinfo[1]);
                                reply.ResponseType = LoginResponseType.ResetVerified;
                                BaseRepository.Update(account);
                            }
                            else
                                reply.ResponseType = LoginResponseType.ResetLocked;
                        }
                        else if (!account.Locked)
                        {
                            if (account.Verified)
                            {
                                if (account.Password.Equals(GetStringSha1Hash(info[1])))
                                {
                                    BaseRepository.Remove(record);
                                    reply.AccountId = account.Accountid;
                                    reply.ResponseType = LoginResponseType.Correct;
                                    account.Lastloginip = client.Handler.RemoteEndPoint.ToString();
                                    account.Lastlogintime = DateTime.Today;
                                    BaseRepository.Update(account);
                                    client.Account = account;
                                }
                                else
                                    reply.ResponseType = LoginResponseType.InvalidPassword;
                            }
                            else
                            {
                                if (account.Verificationcode.Equals(info[1]))
                                {
                                    account.Verified = true;
                                    reply.ResponseType = LoginResponseType.AccountVerified;
                                    BaseRepository.Update(account);
                                }
                                else
                                {
                                    reply.AccountId = account.Accountid;
                                    reply.ResponseType = LoginResponseType.AccountNotVerified;
                                }
                            }
                        }
                        else
                            reply.ResponseType = LoginResponseType.AccountLocked;
                    }
                    else
                        reply.ResponseType = LoginResponseType.InvalidPassword;
                }
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
