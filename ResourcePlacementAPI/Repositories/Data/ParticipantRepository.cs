using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class ParticipantRepository : GeneralRepository<MyContext, Participants, int>
    {
        public ParticipantRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
