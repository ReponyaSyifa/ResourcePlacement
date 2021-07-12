using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class ParticipantSkillRepository : GeneralRepository<MyContext, ParticipantsSkills, int>
    {
        public ParticipantSkillRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
