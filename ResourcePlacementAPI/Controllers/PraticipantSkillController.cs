﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourcePlacementAPI.Base;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PraticipantSkillController : BaseController<ParticipantsSkills, ParticipantSkillRepository, int>
    {
        public PraticipantSkillController(ParticipantSkillRepository repository) : base(repository)
        {
        }
    }
}