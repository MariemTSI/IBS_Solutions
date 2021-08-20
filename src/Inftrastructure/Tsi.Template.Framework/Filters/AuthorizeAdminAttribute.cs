using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Core;
using Tsi.Template.Core.Defaults;

namespace Tsi.Template.Framework.Filters
{
    public class AuthorizeAdminAttribute : TypeFilterAttribute
    {
        public AuthorizeAdminAttribute(bool ignore = false) : base(typeof(AuthorizeAdminFilter))
        {
            IgnoreFilter = ignore;
            Arguments = new object[] { ignore };
        }

        public bool IgnoreFilter { get; }


        private class AuthorizeAdminFilter : IAsyncAuthorizationFilter
        {
            private readonly bool _ignoreFilter;
            private readonly IPermissionService _permissionService;
            private readonly IUserAuthenticationService _userAuthenticationService;

            public AuthorizeAdminFilter(bool ignoreFilter, IPermissionService permissionService, IUserAuthenticationService userAuthenticationService)
            {
                _ignoreFilter = ignoreFilter;
                _permissionService = permissionService;
                _userAuthenticationService = userAuthenticationService;
            }

            private async Task AuthorizeAdminAsync(AuthorizationFilterContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }


                //check whether this filter has been overridden for the action
                var actionFilter = context.ActionDescriptor.FilterDescriptors
                    .Where(filterDescriptor => filterDescriptor.Scope == FilterScope.Action)
                    .Select(filterDescriptor => filterDescriptor.Filter)
                    .OfType<AuthorizeAdminAttribute>()
                    .FirstOrDefault();

                //ignore filter (the action is available even if a customer hasn't access to the admin area)
                if (actionFilter?.IgnoreFilter ?? _ignoreFilter)
                {
                    return;
                }

                //there is AdminAuthorizeFilter, so check access
                if (context.Filters.Any(filter => filter is AuthorizeAdminFilter))
                {
                    //authorize permission of access to the admin area
                    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
                    {
                        var user = await _userAuthenticationService.GetAuthenticatedUserAsync();

                        if(user is null)
                        {
                            context.Result = new ChallengeResult();
                        }
                        else
                        { 
                            context.Result = new RedirectToRouteResult("default", null);
                        } 
                    }
                }
            }

            public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
            {
                await AuthorizeAdminAsync(context);
            }
        }
    }
}
