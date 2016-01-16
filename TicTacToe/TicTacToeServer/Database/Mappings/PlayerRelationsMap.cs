using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TicTacToeServer.Database.Domains;

namespace TicTacToeServer.Database.Mappings
{
    public class PlayerRelationsMap : ClassMap<PlayerRelations>
    {
        public PlayerRelationsMap()
        {
            Table("playerrelations");
            LazyLoad();
            Id(x => x.Id).Column("Id").GeneratedBy.Increment();
            Map(x => x.AccountId).Column("AccountId").Not.Nullable();
            Map(x => x.RelationId).Column("RelationId").Not.Nullable();
            Map(x => x.RelationType).Column("RelationType").Not.Nullable();
        }
    }
}
