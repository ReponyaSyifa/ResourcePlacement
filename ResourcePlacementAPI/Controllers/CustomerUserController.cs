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
    public class CustomerUserController : BaseController<CustomerUsers, CustomerUserRepository, int>
    {
        private CustomerUserRepository repository;
        public CustomerUserController(CustomerUserRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPut("ProjectPlotting/{participantId}")]
        public ActionResult ProjectPlotting(ProjectPlottingVM projectPlottingVM, int participantId)
        {
            var plotting = repository.ProjectPlotting(projectPlottingVM, participantId);
            if (plotting == 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result = plotting, message = "Dapat Job" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result = plotting, message = "Status Idle" });
            }
        }
    }
}
