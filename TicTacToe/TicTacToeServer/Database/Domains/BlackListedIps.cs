using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer.Database.Domains
{
    public class BlackListedIps
    {
        public virtual int Id { get; set; }
        public virtual string Ip { get; set; }
        public virtual DateTime BlacklistLiftTime { get; set; }
        public virtual string MacAddress { get; set; }
        public virtual int Attempts { get; set; }

    }
}
