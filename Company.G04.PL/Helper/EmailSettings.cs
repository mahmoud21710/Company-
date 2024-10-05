using Company.G04.DAL.Model;
using System.Net;
using System.Net.Mail;

namespace Company.G04.PL.Helper
{
    public static class EmailSettings
    {
        public static void SendEmail (Email email) 
        {
            //Mail Server : gmail.com 
            //Smtp

            var client = new SmtpClient ("smtp.gmail.com",587);

            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("mvc90006@gmail.com", "tgychwpbmhurboos");

            client.Send("mvc90006@gmail.com", email.To, email.Subjets, email.Body);
        }
    }
}
