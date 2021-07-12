using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class CustomerUserRepository : GeneralRepository<MyContext, CustomerUsers, string>
    {
        public CustomerUserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
