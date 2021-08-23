using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;

namespace Tsi.Template.Web.Controllers
{
    public class SocieteController : Controller
    {
        private readonly ISocieteService _societeService;



        public IActionResult Index()
        {
            return View();
        }
    }
}
