using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class ProjectSkillRepository : GeneralRepository<MyContext, ProjectsSkills, int>
    {
        public ProjectSkillRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
