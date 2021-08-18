using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsi.Template.Web.Areas.Admin.Controllers
{
    public class ConfigurationController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
