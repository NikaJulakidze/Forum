using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Forum.Service.Services.FileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        public FileController(IWebHostEnvironment env, IFileService fileService)
        {
            _env = env;
            _fileService = fileService;
        }


        [HttpPost("UploadImage/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadImageAsync(string id,[FromForm]IFormFile image)
        {
            return Ok(await _fileService.UploadImageAsync(id, image, _env.ContentRootPath));
        }
        [HttpGet("GetImage")]
        [AllowAnonymous]
        public IActionResult Getimage()
        {
            return Ok(new { ImageUrl = _env.WebRootFileProvider.GetFileInfo("images/Defaultimage.png").PhysicalPath });
        }
    }
}
