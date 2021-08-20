using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing; 
using Tsi.Template.Framework.Routing;

namespace Tsi.Template.Web.Areas.Admin
{
    public class AdminRouteProvider : IRouteProvider
    {
        public int Priority => 0;

        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
