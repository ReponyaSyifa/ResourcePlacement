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
    public class ProjectController : BaseController<Projects, ProjectRepository, int>
    {
        private ProjectRepository repository;
        public ProjectController(ProjectRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost("AddProject")]
        public ActionResult AddProject(AddProjectVM addProject)
        {
            var add = repository.AddProject(addProject);
            if (add == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = add, message = "Add Project Succeed!" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = add, message = "Add Project Failed!" });
            }
        }

        [HttpGet("ShowSkillProjects/{projectId}")]
        public ActionResult ShowSkillProjects(int projectId)
        {
            var add = repository.ShowSkillProjects(projectId);
            if (add == null)
            {
                return Ok(add);
            }
            else
            {
                return BadRequest(add);
            }
        }

        [HttpGet("ShowDetailProject")]
        public ActionResult ShowDetailProject()
        {
            var add = repository.ShowDetailProjectVM();
            if (add == null)
            {
                return Ok(add);
            }
            else
            {
                return BadRequest(add);
            }
        }

        [HttpGet("ShowDetailProject/{projectId}")]
        public ActionResult ShowDetailProject(int projectId)
        {
            var add = repository.ShowDetailProjectVM(projectId);
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
