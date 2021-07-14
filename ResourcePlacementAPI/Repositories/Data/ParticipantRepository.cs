using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Repositories.Data
{
    public class ParticipantRepository : GeneralRepository<MyContext, Participants, int>
    {
        private readonly MyContext myContext;
        public ParticipantRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int AddParticipant(AddParticipantVM addParticipant)
        {
            var cekPartisipan = myContext.Participants.FirstOrDefault(p => p.Email == addParticipant.Email);
            if (cekPartisipan == null)
            {
                Participants peserta = new Participants();
                peserta.FirstName = addParticipant.FirstName;
                peserta.LastName = addParticipant.LastName;
                peserta.Email = addParticipant.Email;
                peserta.Gender = (Models.Gender)addParticipant.Gender;
                peserta.PhoneNumber = addParticipant.PhoneNumber;
                peserta.BirthDate = addParticipant.BirthDate;
                peserta.Grade = addParticipant.Grade;
                peserta.Status = "Idle";
                peserta.ProjectId = null;
                myContext.Participants.Add(peserta);
                myContext.SaveChanges();

                ParticipantsSkills parSkill = new ParticipantsSkills();
                for (int i = 0; i < addParticipant.ListSkill.Length; i++)
                {
                    parSkill.ParticipantsId = peserta.ParticipantId;
                    parSkill.SkillsId = addParticipant.ListSkill[i];
                    myContext.ParticipantsSkills.Add(parSkill);
                    myContext.SaveChanges();
                }

                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
