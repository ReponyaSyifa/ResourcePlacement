using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourcePlacementAPI.Base;
using ResourcePlacementAPI.Context;
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
    public class AccountController : BaseController<Accounts, AccountRepository, int>
    {
        private readonly AccountRepository repository;
        private readonly MyContext myContext;

        public AccountController(AccountRepository repository, MyContext myContext) : base(repository)
        {
            this.myContext = myContext;
            this.repository = repository;
        }

        [HttpPost("/API/Account/Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            int login = repository.Login(loginVM);
            if (login == 1)
            {
                return Ok(login);
            }
            else
            {
                return BadRequest(login);
            }
            /*switch (login)
            {
                case 1:
                    return BadRequest();
                case 2:
                    return Ok();
                default:
                    return BadRequest();
            }*/
        }

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var result = repository.ChangePassword(changePasswordVM);
            if (result == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = result, message = "Sukses" });
            }
            else if (result == 2)
            {
                return Ok(new { status = HttpStatusCode.BadRequest, result = result, message = "Old Password dan New Password tidak ada" });
            }
            else if (result == 3)
            {
                return Ok(new { status = HttpStatusCode.BadRequest, result = result, message = "Old Password tidak ada" });
            }
            else if (result == 4)
            {
                return Ok(new { status = HttpStatusCode.BadRequest, result = result, message = "New Password tidak ada" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.BadRequest, result = result, message = "Password yang lama tidak cocok" });
            }
        }

    }
}
