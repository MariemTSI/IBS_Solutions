using Tsi.Template.Framework.Menu;

namespace Tsi.Template.Framework.Factories.SiteMap
{
    public interface ISiteMapLoader
    {
        SiteMapNode LoadMenuNodeForArea(string areaName);
    }
}
