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

            var matchAcc = myContext.Accounts.FirstOrDefault(a => a.Email == loginVM.Email && a.Password == loginVM.Password);
            if (findAkun != null)
            {
                if (matchAcc != null)
                {
                    if (HashingPassword.ValidatePassword(loginVM.Password, matchAcc.Password))
                    {
                        return 3;
                    }
                    return 2;
                }
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


    }
}
