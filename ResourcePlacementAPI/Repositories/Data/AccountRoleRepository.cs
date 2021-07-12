using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountsRoles, int>
    {
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
