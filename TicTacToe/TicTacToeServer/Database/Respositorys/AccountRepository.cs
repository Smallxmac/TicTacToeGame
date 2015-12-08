using System;
using NHibernate.Criterion;
using NHibernate.Hql.Ast.ANTLR.Tree;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Objects;

namespace TicTacToeServer.Database.Respositorys
{
    public class AccountRepository
    {
        public static Accounts GetAccount(int id)
        {
            using (var session = NHibernateHelper.Open())
            {
                return session
                    .CreateCriteria<Accounts>()
                    .Add(Restrictions.Eq("Accountid", id))
                    .UniqueResult<Accounts>();
            }
        }

        public static Accounts GetAccount(string username,string email)
        {
            if (string.IsNullOrEmpty(username))
            {
                using (var session = NHibernateHelper.Open())
                {
                    return session
                        .CreateCriteria<Accounts>()
                        .Add(Restrictions.Eq("Email", email))
                        .UniqueResult<Accounts>();
                }
            }
            using (var session = NHibernateHelper.Open())
            {
                return session
                    .CreateCriteria<Accounts>()
                    .Add(Restrictions.Eq("Username", username))
                    .UniqueResult<Accounts>();
            }
        }
    }
}