using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TicTacToeServer.Other;

namespace TicTacToeServer.Database.Controller
{
    public class MysqlController
    {
        public static bool Execute(MySqlCommand command)
        {
            var conn = new MySqlConnection(Properties.Settings.Default.MysqlConnectionString);

            try
            {
                conn.Open();
                command.Connection = conn;
                command.Prepare();
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Logger.Error($"Database Error: {ex.Message}");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
