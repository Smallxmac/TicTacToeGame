using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg.XmlHbmBinding;
using TicTacToeServer.Database.Domains;

namespace TicTacToeServer.Database.Respositorys
{
    public static class BaseRepository
    {
        public static void Add(object item)
        {
            using (var session = NHibernateHelper.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public static void Remove(object item)
        {
            using (var session = NHibernateHelper.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(item);
                    transaction.Commit();
                }
            }
        }

        public static void Update(object item)
        {
            using (var session = NHibernateHelper.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(item);
                    transaction.Commit();
                }
            }
        }

        public static void SaveOrUpdate(object item)
        {
            using (var session = NHibernateHelper.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    transaction.Commit();
                }
            }
        }
    }
}
