using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TicTacToeServer.Database.Controller;
using TicTacToeServer.Objects;
using TicTacToeServer.Other;

namespace TicTacToeServer.Database.Task_Managers
{
    public class AccountManager
    {
        public static bool SaveAccount(Account account)
        {
            var cmd = new MySqlCommand();
            if (AccountExist(account.Username))
            {
                cmd.CommandText =
                    "UPDATE accounts SET Username = @Username, Password = @Password, Email = @Email, RegisterIp = @RegisterIp, LastLoginIp = @LastLoginIp, LastLoginTime = @LastLoginTime, RegisterTime = @RegisterTime, Verified = @Verified, Locked = @Locked, VerificationCode = @VC WHERE AccountId = @id";
                cmd.Parameters.AddWithValue("@id", account.AccountId);
                cmd.Parameters.AddWithValue("@Username", account.Username);
                cmd.Parameters.AddWithValue("@Password", account.Password);
                cmd.Parameters.AddWithValue("@Email", account.Email);
                cmd.Parameters.AddWithValue("@RegisterIp", account.RegisterIp);
                cmd.Parameters.AddWithValue("@LastLoginIp", account.LastLoginIp);
                cmd.Parameters.AddWithValue("@LastLoginTime", account.LastLoginTime);
                cmd.Parameters.AddWithValue("@RegisterTime", account.RegisterTime);
                cmd.Parameters.AddWithValue("@Verified", account.Verified);
                cmd.Parameters.AddWithValue("@Locked", account.Locked);
                cmd.Parameters.AddWithValue("@VC", account.VerificationCode);
            }
            else
            {
                cmd.CommandText =
                    "INSERT INTO accounts(Username,Password,Email,RegisterIp,LastLoginIp,LastLoginTime,RegisterTime,Verified,Locked,VerificationCode) VALUES(@Username,@Password,@Email,@RegisterIp,@LastLoginIp,@LastLoginTime,@RegisterTime,@Verified,@Locked,@VerificationCode)";
                cmd.Parameters.AddWithValue("@Username", account.Username);
                cmd.Parameters.AddWithValue("@Password", account.Password);
                cmd.Parameters.AddWithValue("@Email", account.Email);
                cmd.Parameters.AddWithValue("@RegisterIp", account.RegisterIp);
                cmd.Parameters.AddWithValue("@LastLoginIp", account.LastLoginIp);
                cmd.Parameters.AddWithValue("@LastLoginTime", account.LastLoginTime);
                cmd.Parameters.AddWithValue("@RegisterTime", account.RegisterTime);
                cmd.Parameters.AddWithValue("@Verified", account.Verified);
                cmd.Parameters.AddWithValue("@Locked", account.Locked);
                cmd.Parameters.AddWithValue("@VerificationCode", account.VerificationCode);
            }
            return MysqlController.Execute(cmd);
        }

        public static Account GetAccount(int id)
        {
            var conn = new MySqlConnection(Properties.Settings.Default.MysqlConnectionString);
            var account = new Account();
            var cmd = new MySqlCommand();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Username, Password, Email, RegisterIp, LastLoginIp, LastLoginTime, RegisterTime, Verified, Locked, VerificationCode FROM accounts WHERE AccountId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    account.AccountId = id;
                    account.Username = reader.GetString(0);
                    account.Password = reader.GetString(1);
                    account.Email = reader.GetString(2);
                    account.RegisterIp = reader.GetString(3);
                    account.LastLoginIp = reader.GetString(4);
                    account.LastLoginTime = reader.GetDateTime(5);
                    account.RegisterTime = reader.GetDateTime(6);
                    account.Verified = reader.GetBoolean(7);
                    account.Locked = reader.GetBoolean(8);
                    account.VerificationCode = reader.GetString(9);
                }
                return account;

            }
            catch (MySqlException ex)
            {
                Logger.Error($"Database Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return account;
        }

        public static Account GetAccount(string username)
        {
            var conn = new MySqlConnection(Properties.Settings.Default.MysqlConnectionString);
            var account = new Account();
            var cmd = new MySqlCommand();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT AccountId, Password, Email, RegisterIp, LastLoginIp, LastLoginTime, RegisterTime, Verified, Locked, VerificationCode FROM accounts WHERE Username = @username";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Prepare();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    account.AccountId = reader.GetInt32(0);
                    account.Username = username;
                    account.Password = reader.GetString(1);
                    account.Email = reader.GetString(2);
                    account.RegisterIp = reader.GetString(3);
                    account.LastLoginIp = reader.GetString(4);
                    account.LastLoginTime = reader.GetDateTime(5);
                    account.RegisterTime = reader.GetDateTime(6);
                    account.Verified = reader.GetBoolean(7);
                    account.Locked = reader.GetBoolean(8);
                    account.VerificationCode = reader.GetString(9);
                }
                return account;

            }
            catch (MySqlException ex)
            {
                Logger.Error($"Database Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return account;
        }

        public static Account GetAccountByEmail(string email)
        {
            var conn = new MySqlConnection(Properties.Settings.Default.MysqlConnectionString);
            var account = new Account();
            var cmd = new MySqlCommand();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT AccountId, Username, Password, RegisterIp, LastLoginIp, LastLoginTime, RegisterTime, Verified, Locked, VerificationCode FROM accounts WHERE Email = @email";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Prepare();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    account.AccountId = reader.GetInt32(0);
                    account.Username = reader.GetString(1);
                    account.Password = reader.GetString(2);
                    account.Email = email;
                    account.RegisterIp = reader.GetString(3);
                    account.LastLoginIp = reader.GetString(4);
                    account.LastLoginTime = reader.GetDateTime(5);
                    account.RegisterTime = reader.GetDateTime(6);
                    account.Verified = reader.GetBoolean(7);
                    account.Locked = reader.GetBoolean(8);
                    account.VerificationCode = reader.GetString(9);
                }
                return account;

            }
            catch (MySqlException ex)
            {
                Logger.Error($"Database Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return account;
        }

        public static bool AccountExist(string username)
        {
            var account = GetAccount(username);
            return account.Username != null;
        }

        public static bool EmailExist(string email)
        {
            
            var conn = new MySqlConnection(Properties.Settings.Default.MysqlConnectionString);
            var cmd = new MySqlCommand();
            MySqlDataReader reader;
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Username FROM accounts WHERE Email = @Email";
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Prepare();
                reader = cmd.ExecuteReader();
                return reader.HasRows;

            }
            catch (MySqlException ex)
            {
                Logger.Error($"Database Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

    }
}
