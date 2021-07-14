using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class ParticipantSkillRepository : GeneralRepository<MyContext, ParticipantsSkills, int>
    {
        private readonly MyContext myContext;
        public ParticipantSkillRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}