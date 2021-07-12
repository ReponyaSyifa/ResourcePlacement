using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Roles, int>
    {
        public RoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
