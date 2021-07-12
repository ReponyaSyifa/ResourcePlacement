using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employees, int>
    {
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
