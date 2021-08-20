using Microsoft.AspNetCore.Hosting; 
using System.IO;
using Tsi.Template.Core;
using Tsi.Template.Core.Attributes;
using Tsi.Template.Core.Exceptions;

namespace Tsi.Template.Framework.Services
{
    [Injectable(typeof(IFileProvider))]
    public class FileProvider : IFileProvider
    {

        private readonly IWebHostEnvironment _env;

        public FileProvider(IWebHostEnvironment env)
        {
            _env = env;
        } 

        public DirectoryInfo GetAppDataDirectory() =>
            new( Path.Combine(GetCurrentDirectory().FullName, "..", "AppData"));

        public DirectoryInfo GetCurrentDirectory() =>
            new(_env.WebRootPath);

        public string GetPhysicalFilePath(string filename)
        {
            var filePath = Path.Combine(GetAppDataDirectory().FullName, filename);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            throw new CoreException($"File {filename} doesn't exist in the app data folder");
        }
    }
}
