using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using TicTacToeServer.Database.Mappings;

namespace TicTacToeServer.Database
{
    public static class NHibernateHelper
    {
        private static ISessionFactory SessionFactory { get; set; }

        public static void CreateSessionFactory()
        {
            SessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(Properties.Settings.Default.MysqlConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountsMap>())
                .BuildSessionFactory();
        }

        public static ISession Open()
        {
            return SessionFactory.OpenSession();
        }
    }
}
