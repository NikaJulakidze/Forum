using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Forum.Models.Account;
using Forum.Models.Filters;
using Forum.Service.Identity;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsersController : BaseController
    {
        private readonly IAccountService _accountService;

        public UsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost(StaticRoutes.Account.Register)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest userRegistrationDto)
        {
            var result= await _accountService.RegisterAsync(userRegistrationDto);
            return CustomGenericResult(result);
        }

        [HttpPost(StaticRoutes.Account.Authenticate)]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticatationRequest authenticatation)
        {
            var result= await _accountService.AuthenticateAsync(authenticatation);
            if (result.Succeeded)
                return Ok(result.Data);
            return BadRequest(result.noSuccessMessage);
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _accountService.GetRolesAsync();
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery] UsersFilterModel filterModel)
        {
            return Ok(await _accountService.GetPagedUsersAsync(filterModel));
        }

        [HttpGet("{id}/{username}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserById(string id, string username)
        {
            //if (User?.FindFirstValue(ClaimTypes.Email)== id)
            //    return RedirectToAction("MyProfile",id);
            return Ok(await _accountService.GetUserById(id));
        }

        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> MyProfile(string id)
        {
            return Ok();
        }
       
    }
}