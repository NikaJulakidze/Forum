using System.Threading.Tasks;
using Forum.Data.Models;
using Forum.Models.Account;
using Forum.Service.Identity;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _http;

        public AccountController(IAccountService accountService,IHttpContextAccessor http)
        {
            _accountService = accountService;
            _http = http;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _accountService.GetRolesAsync();
            return Ok(result);
        }

        //[HttpGet("Users")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetUsersWithPaging(UsersFilterModel filter,int page=1)
        //{ 
            
        //    return null;
        //}
       
    }
}