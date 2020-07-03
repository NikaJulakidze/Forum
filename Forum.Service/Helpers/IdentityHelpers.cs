using Forum.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Forum.Service.Helpers
{
    public  class IdentityHelpers
    {
        public static void UploadDefaultProfilePhoto(string path, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(user.ImageUrl))
                user.ImageUrl = path;
            return;
        }

        public static async Task<string> PasswordRecoveryToken(UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            return await userManager.GeneratePasswordResetTokenAsync(user);
            
        }
    }
}
