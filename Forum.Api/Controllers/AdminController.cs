using System.Threading.Tasks;
using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Models.Tag;
using Forum.Service.Dto.Admin;
using Forum.Service.Dto.Question;
using Forum.Service.Dto.Tags;
using Forum.Service.Identity;
using Forum.Service.Models;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy =StaticPolicies.ShouldBeAdmin)]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public AdminController(IAdminService adminService,IMapper mapper,ApplicationDbContext context,IOptionsSnapshot<AppSettings> appSettings)
        {
            _adminService = adminService;
            _mapper = mapper;
            _context = context;
            _appSettings=appSettings.Value;
        }

        [HttpPost("CreateTag")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTags([FromBody] AddTagModel tag)
        {
            var result = await _adminService.CreateTagAsync(tag);
            return Ok(result);
        }

        [HttpPost(StaticRoutes.Admin.CreateRole)]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleDto role)
        {
            return CustomResult(await _adminService.CreateRoleAsync(role.Role));
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] int currenPage)
        {
            var a= await _adminService.GetUsersWithPaging(new Data.Models.PagingSettings(currenPage, 5));
            return Ok(a);
        }
    }
}