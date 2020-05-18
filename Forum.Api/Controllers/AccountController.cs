using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Forum.Service.Dto.Account;
using Forum.Service.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationDto userRegistrationDto)
        {
            var result= await _accountService.RegisterAsync(userRegistrationDto);
            if(result.Succeeded)
            return Ok(result.Data);
            return BadRequest(result.Errors);
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthenticationRequestDto userRegistrationDto)
        {
            var result= await _accountService.AuthenticateAsync(userRegistrationDto);
            if (result.Succeeded)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
    }
}