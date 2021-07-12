using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class SkillRepository : GeneralRepository<MyContext, Skills, int>
    {
        public SkillRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
