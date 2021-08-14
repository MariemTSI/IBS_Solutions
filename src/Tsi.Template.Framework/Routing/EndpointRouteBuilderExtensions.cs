using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Tsi.Template.Core;

namespace Tsi.Template.Framework.Routing
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterRoutes(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var routeProviders = EngineContext.Current.FindAllTypes<IRouteProvider>();

            //create and sort instances of route providers
            var instances = routeProviders
                .Select(routeProvider => (IRouteProvider)Activator.CreateInstance(routeProvider))
                .OrderByDescending(routeProvider => routeProvider.Priority);

            //register all provided routes
            foreach (var routeProvider in instances)
            {
                routeProvider.RegisterRoutes(endpointRouteBuilder);
            }
        }
    }
}
