using Forum.Service.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.FileService
{
    public interface IFileService
    {
        Task<Result<string>> UploadImageAsync(string id, IFormFile image, string path);
    }
}
