using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories
{
    public class Email
    {
        public static string SendEmail(string email, string body, string subject, string notification)
        {
            try
            {
                var fromAddress = new MailAddress("	akunt5634@gmail.com");
                var passwordFrom = "akunt3$t";
                var toAddress = new MailAddress(email);
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, passwordFrom)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = body,
                    Body = subject,
                    IsBodyHtml = true,
                }) smtp.Send(message);
                return notification;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
