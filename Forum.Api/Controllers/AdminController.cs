using System.Threading.Tasks;
using Forum.Service.Dto.Admin;
using Forum.Service.Identity;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy =StaticPolicies.ShouldBeAdmin)]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> BanUser(string id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTags()
        {
            return null;
        }

        [HttpPost(StaticRoutes.Admin.CreateRole)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleDto role)
        {
            return CustomResult(await _adminService.CreateRoleAsync(role.Role));
        }
    }
}