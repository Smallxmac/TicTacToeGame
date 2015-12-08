using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Database;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Objects;

namespace TicTacToeServer.Networking
{
    public class EmailSender
    {
        public static void SendWelcomeEmail(Accounts account)
        {
            SmtpClient client = new SmtpClient("mail.michaelandrepont.com")
            {
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("donotreply@michaelandrepont.com", "dn9u(T]C@G49")
            };
            // That password is not used for anything by the way.
            var message =
                new MailMessage(new MailAddress("donotreply@michaelandrepont.com", "Michael's TicTacToe Program"),
                    new MailAddress(account.Email))
                {
                    Subject = "Please Verify Your Account",
                    Body = "Please use " + account.Verificationcode +
                           " in the password box the next time you login to this account to verify your account."
                };
            client.Send(message);
        }

        public static void SendRestEmail(Accounts account)
        {
            SmtpClient client = new SmtpClient("mail.michaelandrepont.com")
            {
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("donotreply@michaelandrepont.com", "dn9u(T]C@G49")
            };
            // That password is not used for anything by the way.
            var message =
                new MailMessage(new MailAddress("donotreply@michaelandrepont.com", "Michael's TicTacToe Program"),
                    new MailAddress(account.Email))
                {
                    Subject = "Forgot Your Password?",
                    Body = "Everybody forgets their password from time to time... it is okay we wont judge ;)" +
                           " \n To reset your password to a new password please login with your account username and the" +
                           " verification code followed by the new password like this below" +
                           $" \n {account.Verificationcode}:Password \n and then your password will be changed."
                };
            client.Send(message);
        }
    }
}
