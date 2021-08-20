using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Core;
using Tsi.Template.Core.Configuration;

namespace Tsi.Template.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly ISettingService _settingService;

        public HomeController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            var userSettings = new UserSettings
            {
                PasswordExpires = true,
                PasswordLifeTime = 90,
                TotalFailedLoginAttemps = 3
            };

            await _settingService.SaveSettingAsync(userSettings);

            return View();
        }
    }
}
