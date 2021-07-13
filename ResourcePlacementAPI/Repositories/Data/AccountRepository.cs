using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
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

        public string Login(LoginVM loginVM)
        {
            try
            {
                if (loginVM.Email != null && loginVM.Password != null)// pakai email
                {
                    var findAccount = myContext.Accounts.FirstOrDefault(e => e.Email == loginVM.Email);
                    var checkPassword = HashingPassword.ValidatePassword(loginVM.Password, findAccount.Password);
                    if (checkPassword == true)
                    {
                        var result = Authentication(loginVM.Email);
                        return result;
                    }
                    else
                    {
                        return "0"; //password salah
                    }
                }
                else// gak ada password atau gak ada semua
                {
                    return "2";
                }
            }
            catch (Exception)
            {

                return "1";
            }
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

        public int ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var account = myContext.Accounts.FirstOrDefault(e => e.Email == changePasswordVM.Email);

            if (changePasswordVM.NewPassword == null && changePasswordVM.OldPassword == null) return 2; //NewPassword & OldPassword gak ada
            if (changePasswordVM.NewPassword != null && changePasswordVM.OldPassword == null) return 3; //OldPassword gak ada
            if (changePasswordVM.NewPassword == null && changePasswordVM.OldPassword == null) return 4; //NewPassword gak ada

            var checkPassword = HashingPassword.ValidatePassword(changePasswordVM.OldPassword, account.Password);

            if (!checkPassword)
            {
                return 5;//OldPassword salah
            }
            else
            {
                var newPasswordHash = HashingPassword.HashPassword(changePasswordVM.NewPassword);
                account.Password = newPasswordHash;

                myContext.Entry(account).State = EntityState.Modified;
                myContext.SaveChanges();
                return 1;
            }
        }

        private string Authentication(string email)
        {
            //create claims details based on the user information
            var account = myContext.Accounts.FirstOrDefault(e => e.Email == email);

            var accountRole = myContext.AccountsRoles.Find(account.AccountId);
            var role = myContext.Roles.Find(accountRole.RolesId);
            var claims = new[] {
                new Claim("email", account.Email),
                new Claim("role", role.RoleName)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfsdfsjdbf78sdyfssdfsdfbuidfs98gdfsdbf"));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("API", "Test", claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
