using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class SkillsRepository : GeneralRepository<MyContext, Skills, int>
    {
        public SkillsRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
