using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourcePlacementAPI.Base;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.Repositories.Data;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantSkillController : BaseController<ParticipantsSkills, ParticipantSkillRepository, int>
    {
        private ParticipantSkillRepository repository;
        public ParticipantSkillController(ParticipantSkillRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost("AddParticipantSkill")]
        public ActionResult AddParticipantSkill(AddParticipantSkillVM addParSkill)
        {
            var addPsrtSkill = repository.AddParticipantSkill(addParSkill);
            if (addPsrtSkill == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = addPsrtSkill, message = "Add Participant Skill Succeed!" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = addPsrtSkill, message = "Add Participant Skill Failed!" });
            }
        }
    }
}
