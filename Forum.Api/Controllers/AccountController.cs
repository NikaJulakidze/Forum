using System.Threading.Tasks;
using Forum.Service.Dto.Account;
using Forum.Service.Identity;
using Forum.Service.Services.MailService;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;

        public AccountController(IAccountService accountService,IEmailService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
        }


        [HttpPost(StaticRoutes.Account.Register)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationRequestDto userRegistrationDto)
        {
            var result= await _accountService.RegisterAsync(userRegistrationDto);
            return CustomGenericResult(result);
        }

        [HttpPost(StaticRoutes.Account.Authenticate)]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthenticationRequestDto userRegistrationDto)
        {
            var result= await _accountService.AuthenticateAsync(userRegistrationDto);
            if (result.Succeeded)
                return Ok(result.Data);
            return BadRequest(result.noSuccessMessage);
        }

        [HttpPost(StaticRoutes.Account.FirstSetup)]
        [Authorize(Policy =StaticPolicies.ShouldBeAdmin)]
        public async Task<IActionResult> FirstSetUpProfile(string UserId,[FromBody] FirstSetUpProfileRequestDto firstSetUp)
        {

            return Ok();
        }
       

        [HttpPost("Test")]
        [Authorize(Policy =StaticPolicies.ShouldBeUser)]
        public IActionResult Test()
        {
            _emailService.SendMail(null);
            return Ok();
        }

    }
}