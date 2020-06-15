using Forum.Data.Entities;
using Forum.Service.Helpers;
using Forum.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Forum.Service.Services.FileService
{
    public class FileService:IFileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public FileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<string>> UploadImageAsync(string id, IFormFile image, string apiPath)
        {
            var user = await _userManager.FindByIdAsync(id);
            var a= await  FileAtachmentDownloadHelper.UploadImageAsync(image, apiPath);
            return Result.Ok(a);
        }
    }
}
