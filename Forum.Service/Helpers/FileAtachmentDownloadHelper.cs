using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Helpers
{
    public class FileAtachmentDownloadHelper
    {
        private const string wwwRoot = "\\wwwroot\\images";
        public static async Task<string> UploadImageAsync(IFormFile photo,string apiPath)
        {
            if (photo?.Length > 0)
            {
                string location = GenerateFilePath(apiPath,GenerateFileNameAsync(photo));
                using var filestream = new FileStream(location, FileMode.Create);

                await photo.CopyToAsync(filestream);
            }
            return null;
        }

        public static string GenerateFileNameAsync(IFormFile file)
        {
            return Path.Combine(Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));
        }

        private static string GenerateFilePath(string apiPath, string fileName)
        {
            var path = apiPath + wwwRoot;
            return Path.Combine(path, fileName);
        }
    }
}
