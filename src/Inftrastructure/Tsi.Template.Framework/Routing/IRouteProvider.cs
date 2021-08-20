using Microsoft.AspNetCore.Routing;

namespace Tsi.Template.Framework.Routing
{
    public interface IRouteProvider
    {
        void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder);

        int Priority { get; }
    } 
}
