using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer.Database.Domains
{
    public class PlayerRelations
    {
        public virtual int Id { get; set; }
        public virtual int AccountId { get; set; }
        public virtual int RelationId { get; set; }
        public virtual short RelationType { get; set; }
    }
}
