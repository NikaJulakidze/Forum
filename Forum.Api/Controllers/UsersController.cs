using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersController(IAccountService accountService,IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }


        [HttpPost(StaticRoutes.Account.Register)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequestModel userRegistrationDto)
        {
            var result= await _accountService.RegisterAsync(userRegistrationDto);
            return CustomGenericResult(result);
        }

        [HttpPost(StaticRoutes.Account.Authenticate)]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticatationRequestModel authenticatation)
        {
            var result= await _accountService.AuthenticateAsync(authenticatation);
            return CustomGenericResult(result);
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
            return Ok(await _accountService.GetUserProfile(id));
        }

        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> MyProfile(string id)
        {
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Top15()
        {
            var result = await _accountService.GetTop15ThisWeek();
            return Ok(result);
        }
       
    }
}