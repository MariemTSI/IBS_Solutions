
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims; 
using System.Threading.Tasks; 
using Tsi.Template.Core;
using Tsi.Template.Core.Attributes;
using Tsi.Template.Core.Configuration;
using Tsi.Template.Core.Entities;

namespace Tsi.Template.Services.Common
{
    [Injectable(typeof(IUserAuthenticationService))]
    public class UserAuthenticationService : IUserAuthenticationService
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UserAuthenticationService(IUserService userService, ISettingService settingService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Utilities

        private static List<Claim> GetUserClaims(User user) => new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.NormalizedUsername),
            new Claim(ClaimTypes.Name, user.Description),
            new Claim(ClaimTypes.Email, user.NormalizedEmail),
            new Claim(ClaimTypes.PrimarySid, user.Id.ToString())
        };

        #endregion

        #region Methods

        public async Task<User> GetAuthenticatedUserAsync()
        {
            var claims = _httpContextAccessor.HttpContext?.User?.Claims ?? null;

            if (claims is null || !claims.Any())
            {
                return null;
            } 

            var settings = await _settingService.LoadSettingAsync<UserSettings>();

            var userSidClaim = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.PrimarySid);

            if (string.IsNullOrEmpty(userSidClaim.Value))
            {
                return null;
            }

            if(Int32.TryParse(userSidClaim.Value, out var id))
            {
                return await _userService.GetUserByIdAsync(id);
            }

            return null;
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            string authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            var claims = GetUserClaims(user);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, authenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var settings = await _settingService.LoadSettingAsync<UserSettings>();

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true, 
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.UtcNow
            };

            // setting the expiring date if a value is set in the customer settings
            if(settings.CookieLifetime > 0)
            {
                authProperties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(settings.CookieLifetime);
            }

            await _httpContextAccessor.HttpContext.SignInAsync(authenticationScheme, claimsPrincipal, authProperties);
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        #endregion
    }
}
