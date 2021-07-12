using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class ProjectRepository : GeneralRepository<MyContext, Projects, int>
    {
        public ProjectRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
