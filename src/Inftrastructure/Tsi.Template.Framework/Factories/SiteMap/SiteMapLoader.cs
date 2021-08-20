using Tsi.Template.Core;
using Tsi.Template.Core.Attributes;
using Tsi.Template.Core.Helpers;
using Tsi.Template.Framework.Menu;

namespace Tsi.Template.Framework.Factories.SiteMap
{
    [Injectable(typeof(ISiteMapLoader))]
    public class SiteMapLoader : ISiteMapLoader
    {
        private readonly IFileProvider _fileProvider;

        public SiteMapLoader(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public SiteMapNode LoadMenuNodeForArea(string areaName)
        {
            var jsonFile = string.IsNullOrEmpty(areaName) ? "SiteMap.json" : $"{areaName}.SiteMap.json";

            var filePath = _fileProvider.GetPhysicalFilePath(jsonFile);

            var rootNode = JsonHelper<Root>.Deserialize(filePath);

            return rootNode.siteMap.siteMapNode;
        }
    }
}
