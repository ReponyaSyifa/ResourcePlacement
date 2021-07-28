using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employees, EmployeeRepository, int>
    {
        private EmployeeRepository repository;
        public EmployeeController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = repository.RegisterRepo(registerVM);
            if (register == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = register, message = "succes" });
            }
            else if (register == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = register, message = "nik sudah ada" });
            }
            else if (register == 3)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = register, message = "data kurang" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = register, message = "Gagal menyimpan, data harus diisi semua" });
            }
        }

        [HttpPost("ProjectPlotting/{participantId}")]
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

        [HttpPost("RegisterRepoWithAdmin")]
        public ActionResult RegisterRepoWithAdmin(RegisterVM registerVM)
        {
            var register = repository.RegisterRepoWithAdmin(registerVM);
            if (register == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = register, message = "succes" });
            }
            else if (register == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = register, message = "nik sudah ada" });
            }
            else if (register == 3)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = register, message = "data kurang" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = register, message = "Gagal menyimpan, data harus diisi semua" });
            }
        }

        [HttpPut("AdminChooseRoleEmployee/{employeeId}")]
        public ActionResult AdminChooseRoleEmployee(AdminChooseRoleEmployeeVM adminChooseRoleEmployeeVM, int employeeId)
        {
            var plotting = repository.AdminChooseRoleEmployee(adminChooseRoleEmployeeVM, employeeId);
            if (plotting == 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result = plotting, message = "Sukses" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result = plotting, message = "Gagal" });
            }
        }
    }
}
