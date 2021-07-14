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

        public int AddParticipantSkill(AddParticipantSkillVM addParSkill)
        {
            var cekPartisipan = myContext.ParticipantsSkills.Find(addParSkill.ParticipantsId);
            var cekSkill = myContext.ParticipantsSkills.Find(addParSkill.SkillsId);
            if (cekPartisipan == null && cekSkill == null) //partisipanID blm ada & skil belum ada
            {
                ParticipantsSkills parSkill = new ParticipantsSkills();
                parSkill.ParticipantsId = addParSkill.ParticipantsId;
                parSkill.SkillsId = addParSkill.SkillsId;
                myContext.ParticipantsSkills.Add(parSkill);
                myContext.SaveChanges();
                return 1;
            }
            else if (cekPartisipan != null && cekSkill == null) //partisipan suda ada tapi skill blm ada
            {
                ParticipantsSkills parSkill = new ParticipantsSkills();
                parSkill.ParticipantsId = addParSkill.ParticipantsId;
                parSkill.SkillsId = addParSkill.SkillsId;
                myContext.ParticipantsSkills.Add(parSkill);
                myContext.SaveChanges();
                return 1;
            }
            else if (cekPartisipan == null && cekSkill != null) //partisipan blm ada tapi skill suda ada
            {
                ParticipantsSkills parSkill = new ParticipantsSkills();
                parSkill.ParticipantsId = addParSkill.ParticipantsId;
                parSkill.SkillsId = addParSkill.SkillsId;
                myContext.ParticipantsSkills.Add(parSkill);
                myContext.SaveChanges();
                return 1;
            }
            else if (cekPartisipan == null && cekSkill != null)
            {
                return 2;
            }
            else
            {
                return 2;
            }            
        }
    }
}