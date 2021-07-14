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

    }
}
