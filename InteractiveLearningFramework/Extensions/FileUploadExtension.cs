using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.Extensions
{
    public static class FileUploadExtension
    {
        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public static string UploadFileToFolder(this IHostingEnvironment environment, IFormFile file)
        {
            var uniqueFileName = GetUniqueFileName(file.FileName);
            var uploads = Path.Combine(environment.WebRootPath, "uploads/course");
            var filePath = Path.Combine(uploads, uniqueFileName);
            file.CopyTo(new FileStream(filePath, FileMode.Create));

            return uniqueFileName;
        }

    }
}
