using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TicTacToeServer.Database.Domains;

namespace TicTacToeServer.Database.Mappings
{
    public class BlackListedIpsMap : ClassMap<BlackListedIps>
    {

        public BlackListedIpsMap()
        {
            Table("blacklistedips");
            LazyLoad();
            Id(x => x.Id).Column("Id").GeneratedBy.Increment();
            Map(x => x.Ip).Column("Ip").Not.Nullable();
            Map(x => x.BlacklistLiftTime).Column("BlacklistLiftTime");
            Map(x => x.MacAddress).Column("MacAddress");
            Map(x => x.Attempts).Column("Attempts");
        }
    }
}
