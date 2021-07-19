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
    public class ParticipantController : BaseController<Participants, ParticipantRepository, int>
    {
        private ParticipantRepository repository;
        public ParticipantController(ParticipantRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost("Add")]
        public ActionResult AddParticipant(AddParticipantVM addParticipant)
        {
            var add = repository.AddParticipant(addParticipant);
            if (add == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = add, message = "Add Participant Succeed!" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = add, message = "Add Participant Failed!" });
            }
        }

        [HttpGet("ShowSkillParticipant")]
        public ActionResult ShowSkillParticipant()
        {
            var add = repository.ShowSkillParticipants();
            if (add == null)
            {
                return Ok(add);
            }
            else
            {
                return BadRequest(add);
            }
        }
    }
}
