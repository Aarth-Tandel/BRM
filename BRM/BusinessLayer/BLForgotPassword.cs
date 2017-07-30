using System.Linq;
using DatabaseLayer;
using System.Net.Mail;
using EntityLayer;
using System.Net;

namespace BusinessLayer
{
    public class BLForgotPassword
    {
        public BRMContext db = new BRMContext();

        public string GetEmail(string username)
        {
            var emailid = (from i in db.UserContext
                           where i.Username == username
                           select i.Email).FirstOrDefault();
            return emailid;
        }

        public void AddToken(string token, string username)
        {
            UserDetails user = new UserDetails();

            user = (from p in db.UserContext where p.Username == username select p).SingleOrDefault();
            user.Token = token;
            db.SaveChanges();
            
        }

        public void SendEMail(string emailid, string subject, string body)
        {
            try
            {
                string ActivationUrl = string.Empty;
                MailMessage mail = new MailMessage();
                SmtpClient Objsmtp = new SmtpClient();
                Objsmtp.Port = 587;
                Objsmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Objsmtp.UseDefaultCredentials = false;
                Objsmtp.EnableSsl = true;
                Objsmtp.Credentials = new NetworkCredential("", "");

                Objsmtp.Host = "smtp.gmail.com";
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("");
                mail.To.Add(emailid);
                mail.Subject = subject;
                mail.Body = body;
                Objsmtp.Send(mail);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
          

        }

        public bool CheckToken(string username, string token)
        {
            return  (from j in db.UserContext
                              where (j.Username == username)
                              && (j.Token == token)
                              //&& (j.PasswordVerificationTokenExpirationDate < DateTime.Now)
                              select j).Any(); 
        }

        public bool CheckUser(string username)
        {
            bool user = (from j in db.UserContext
                         where (j.Username == username)
                         select j).Any();
            return user;
        }

        public bool ResetPassword(string username, string newpassword)
        {
            UserDetails user = new UserDetails();

            user = (from p in db.UserContext where p.Username == username select p).SingleOrDefault();
            user.Password = newpassword;
            db.SaveChanges();
            return true;
        }
    }
}
