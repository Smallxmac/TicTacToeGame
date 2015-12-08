using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TicTacToeServer.Database.Domains;

namespace TicTacToeServer.Database.Mappings
{
    public class AccountsMap : ClassMap<Accounts>
    {

        public AccountsMap()
        {
            Table("accounts");
            LazyLoad();
            Id(x => x.Accountid).Column("AccountId").GeneratedBy.Increment();
            Map(x => x.Username).Column("Username").Not.Nullable();
            Map(x => x.Password).Column("Password").Not.Nullable();
            Map(x => x.Email).Column("Email").Not.Nullable();
            Map(x => x.Registerip).Column("RegisterIp").Not.Nullable();
            Map(x => x.Lastloginip).Column("LastLoginIp").Not.Nullable();
            Map(x => x.Lastlogintime).Column("LastLoginTime").Not.Nullable();
            Map(x => x.Registertime).Column("RegisterTime").Not.Nullable();
            Map(x => x.Verified).Column("Verified").Not.Nullable();
            Map(x => x.Locked).Column("Locked").Not.Nullable();
            Map(x => x.Verificationcode).Column("VerificationCode").Not.Nullable();
        }
    }
}
