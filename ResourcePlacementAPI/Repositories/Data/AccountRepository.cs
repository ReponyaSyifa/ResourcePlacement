using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Accounts, int>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Login(LoginVM loginVM)
        {
            var findAkun = myContext.Accounts.FirstOrDefault(a => a.Email == loginVM.Email);
            //if (findAkun != null && findAkun.Password == loginVM.Password)
            if (findAkun != null && HashingPassword.ValidatePassword(loginVM.Password, findAkun.Password))
            {
                return 1;
            }
            return 0;
        }

        public string Guid() //
        {
            System.Guid guid = System.Guid.NewGuid();
            string newguid = guid.ToString();
            return newguid;
        }

        public int ResetPassword(ResetPasswordVM resetPwd)
        {
            string guid = Guid();

            var acc = new Accounts();
            var accMatch = myContext.Accounts.FirstOrDefault(c => c.Email == resetPwd.Email);

            if (accMatch != null)
            {
                acc.Password = HashingPassword.HashPassword(guid);
                myContext.Entry(accMatch).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var update = myContext.SaveChanges();

                using (MailMessage message = new MailMessage("hostmail.onlytest@gmail.com", resetPwd.Email))
                {
                    message.Subject = "[No Reply] Reset Password";
                    string bodyMail = "Hi There!, ";
                    bodyMail += "\n\nPlease copy these following GUID code and paste on to your login form:\n\n";
                    bodyMail += guid;
                    bodyMail += "\n\nThanks!\n\n";
                    bodyMail += "\n\nRegards,\nReset Password Teams!\n";
                    message.Body = bodyMail;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred = new NetworkCredential("hostmail.onlytest@gmail.com", "raha,sia.");
                    smtp.Credentials = NetworkCred;
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.Send(message);
                }
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
