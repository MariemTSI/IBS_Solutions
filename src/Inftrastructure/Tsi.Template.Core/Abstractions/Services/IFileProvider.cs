using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Core.Attributes;

namespace Tsi.Template.Core
{
    public interface IFileProvider
    {
        DirectoryInfo GetCurrentDirectory();
        DirectoryInfo GetAppDataDirectory();
        string GetPhysicalFilePath(string filename);
    }

    
}
