using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var findAkun = myContext.Accounts.Find(loginVM.Email);

            var matchAcc = myContext.Accounts.FirstOrDefault(a => a.Email == loginVM.Email);
            var matchPass = myContext.Accounts.FirstOrDefault(p => p.Password == loginVM.Password);
            if (findAkun != null)
            {
                if (matchAcc != null && matchPass != null)
                {
                    return 2;
                }
                return 1;
            }
            return 0;
        }
        /*public string Guid() //
        {
            System.Guid guid = System.Guid.NewGuid();
            string newguid = guid.ToString();
            return newguid;
        }*/

        /*public int ResetPassword(ResetPasswordVM resetPwd)
        {
            System.Guid guid = System.Guid.NewGuid();
            string newguid = guid.ToString();

            var acc = new Accounts();

            var accMatchEmp = myContext.Employees.FirstOrDefault(e => e.Email == resetPwd.Email);
            var accMatchCU = myContext.CustomerUsers.FirstOrDefault(c => c.Email == resetPwd.Email);

            if (accMatchEmp  != null)
            {
                acc.Email = accMatchEmp.Email;
                acc.Password = HashingPassword.HashPassword(newguid);
                myContext.Entry(accMatchEmp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var update = myContext.SaveChanges();

                using (MailMessage)
            }
        }*/
    }
}
