using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer.Database.Domains
{
    public class Accounts
    {
        public virtual int Accountid { get; set; }
        public virtual string Username { get; set; }

        [Required]
        public virtual string Password { get; set; }

        [Required]
        public virtual string Email { get; set; }

        [Required]
        public virtual string Registerip { get; set; }

        [Required]
        public virtual string Lastloginip { get; set; }

        [Required]
        public virtual DateTime Lastlogintime { get; set; }

        [Required]
        public virtual DateTime Registertime { get; set; }

        [Required]
        public virtual bool Verified { get; set; }

        [Required]
        public virtual bool Locked { get; set; }

        [Required]
        public virtual string Verificationcode { get; set; }
    }
}
