using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session5.Context;
using Session5.Models;
using Session5.Services;

namespace Session5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountService _accountService;


        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO appUser) 
        {
            var errors = await _accountService.Register(appUser);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(errors);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LogInDTO logindto)
        {
            var authResponse = await _accountService.Login(logindto);
            if (authResponse == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(authResponse);
            }
        }

        [HttpGet]
        [Route("Logout")]
        public  ActionResult LogOut()
        {
            _accountService.LogOut();
            return Ok();
        }

        [HttpGet]
        [Route("UserList")]
        public async Task<ActionResult> UserList()
        {
            List<AppUser> userlist = await _accountService.UserList();
            return Ok(userlist);
        }


        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            var result = await _accountService.DeleteUser(userId);
            if (result == true)
                return Ok();
            return NotFound();
        }

    }
}
