﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsi.Template.Web.Controllers
{
    public class SocieteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
