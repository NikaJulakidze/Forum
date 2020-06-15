using Forum.Data.Entities;
using Forum.Service.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public class AdminService : IAdminService
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager) 
        {
            _rolemanager = roleManager;
            _userManager = userManager;
        }

        public async Task<Result> CreateRoleAsync(string role)
        {
            var identityResult= await _rolemanager.CreateAsync(new IdentityRole { Name = role});
            if (identityResult.Succeeded)
                return Result.Ok();
            return Result.BadRequest(NoSuccessMessage.AddErrors(identityResult.Errors.Select(x => x.Description).ToList()));
        }
    }
}
