using Forum.Data.Entities;
using Forum.Service.Dto.Account;
using Forum.Service.Models;
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
    }
}
