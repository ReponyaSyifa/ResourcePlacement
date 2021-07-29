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

        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = repository.Login(loginVM);
            if (login == "1")
            {
                return Ok(new JWTokenVM { Status = HttpStatusCode.BadRequest, Token = login, Message = "Email tidak Terdaftar" });
            }
            else if (login == "0")
            {
                return Ok(new JWTokenVM { Status = HttpStatusCode.BadRequest, Token = login, Message = "Password Salah" });
            }
            else if (login == "2")
            {
                return Ok(new JWTokenVM { Status = HttpStatusCode.BadRequest, Token = login, Message = "Masukan Password" });
            }
            else
            {
                return Ok(new JWTokenVM { Status = HttpStatusCode.OK, Message = "Login Sukses", Token = login });
            }
        }

        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            var reset = repository.ResetPassword(resetPasswordVM);
            if (reset == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = reset, message = "Sukses" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.BadRequest, result = reset, message = "Gagal Reset Password" });
            }
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
