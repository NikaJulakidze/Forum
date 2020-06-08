using Forum.Data.Entities;
using Forum.Service.Dto.Account;
using Forum.Service.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Forum.Service.Helpers
{
    public static class IdentityHelpers
    {
        //public async static Task<Result<UserAuthenticationResponseDto>> AuthenticateUser(this SignInManager<ApplicationUser> signInManager,ApplicationUser user,string password)
        //{
        //    if (user == null)
        //    {
        //        var noSuccessMessage = NoSuccessMessage.AddError("Username or password is incorrect");
        //        return Result.BadRequest<UserAuthenticationResponseDto>(noSuccessMessage);
        //    }

        //    return null;
        //}

    }
}
