using CommonModels;
using Forum.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Forum.Service.Services.FileService
{
    public interface IFileService
    {
        Task<Result<string>> UploadImageAsync(string id, IFormFile image, string path);
    }
}
