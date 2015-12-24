using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using TicTacToeServer.Database.Domains;

namespace TicTacToeServer.Database.Respositorys
{
    public class BlacklistIpsRepository
    {
        public static List<BlackListedIps> GetAll()
        {
            using (var session = NHibernateHelper.Open())
            {
                return (List<BlackListedIps>) session
                    .CreateCriteria<BlackListedIps>()
                    .List<BlackListedIps>();
            }
        }

        public static BlackListedIps GetRecord(string ip)
        {
            using (var session = NHibernateHelper.Open())
            {
                return session
                    .CreateCriteria<BlackListedIps>()
                    .Add(Restrictions.Eq("Ip", ip))
                    .UniqueResult<BlackListedIps>();
            }
        }

        public static BlackListedIps GetRecordByMac(string mac)
        {
            using (var session = NHibernateHelper.Open())
            {
                return session
                    .CreateCriteria<BlackListedIps>()
                    .Add(Restrictions.Eq("MacAddress", mac))
                    .UniqueResult<BlackListedIps>();
            }
        }
    }
}
