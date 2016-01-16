using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Enums;

namespace TicTacToeServer.Database.Respositorys
{
    public class PlayerRelationsRepository
    {
        public static List<PlayerRelations> GetAllRelations(int id)
        {
            using (var session = NHibernateHelper.Open())
            {
                var account = (List<PlayerRelations>)session
                    .CreateCriteria<PlayerRelations>()
                    .Add(Restrictions.Eq("AccountId", id))
                    .List<PlayerRelations>();
                account.AddRange((List<PlayerRelations>)session
                    .CreateCriteria<PlayerRelations>()
                    .Add(Restrictions.Eq("RelationId", id))
                    .List<PlayerRelations>());
                return account;
            }
        }

        public static List<PlayerRelations> GetAllFriendRequest(int id)
        {
            using (var session = NHibernateHelper.Open())
            {
                return (List<PlayerRelations>)session
                    .CreateCriteria<PlayerRelations>()
                    .Add(Restrictions.Eq("RelationId", id))
                    .Add(Restrictions.Eq("RelationType", (short) AssociationType.FriendRequest))
                    .List<PlayerRelations>();
            }
        }
    }
}
