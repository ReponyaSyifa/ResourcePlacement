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
    }
}
