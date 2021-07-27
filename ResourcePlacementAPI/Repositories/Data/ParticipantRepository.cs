﻿using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections;
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

        public IEnumerable<ShowSkillVM> ShowSkillParticipants(int participantId)
        {
            List<ShowSkillVM> showSkillParticipants = new List<ShowSkillVM>();
            var participantSkills = myContext.ParticipantsSkills.Where(e => e.ParticipantsId == participantId).ToList();

            foreach (var item in participantSkills)
            {
                ShowSkillVM showSkillParticipant = new ShowSkillVM();
                var skill = myContext.Skills.Find(item.SkillsId);
                showSkillParticipant.SKillName = skill.SkillName;
                showSkillParticipants.Add(showSkillParticipant);
            }
            return showSkillParticipants;
        }

        public IEnumerable GetParticipantByUser()
        {
            Participants par = new Participants();
            using (var db = myContext)
            {
                var listPar = (from a in myContext.Participants
                               join b in myContext.Projects on a.ProjectId equals b.ProjectId
                               join c in myContext.CustomerUsers on b.CustomerUserId equals c.CustomerUserId
                               where a.Status != "Idle"
                               select new
                               {
                                   a.FirstName,
                                   a.LastName,
                                   c.CompanyName,
                                   b.ProjectName
                               });
                return listPar.ToList();
            }
        }
    }
}
