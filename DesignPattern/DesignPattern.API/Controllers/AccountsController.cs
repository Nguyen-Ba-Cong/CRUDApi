using DesignPattern.Service.IApiServices;
using DesignPattern.Service.Models.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Admin/Login")]
        public IActionResult AdminLogin(AccountModel accountModel)
        {
            var response = _accountService.AdminLogin(accountModel.Email, accountModel.Password);
            if (response == null)
            {
                return StatusCode(404, Service.Common.Constants.NotFound);
            }
            else
            {
                HttpContext.Session.SetString("UserId", response.Id.ToString());
                return StatusCode(200, response);
            }
        }
        [HttpPost("Guest/Login")]
        public IActionResult GuestLogin(AccountModel accountModel)
        {
            var response = _accountService.GuestLogin(accountModel.Email, accountModel.Password);
            if (response == null)
            {
                return StatusCode(404, Service.Common.Constants.NotFound);
            }
            else
            {
                return StatusCode(200, response);
            }
        }
    }
}
