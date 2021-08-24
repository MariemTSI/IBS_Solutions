using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.Helpers;

namespace Tsi.Template.Web.Controllers
{
    public class ExpertComptableController : Controller
    {
        private readonly IExpertComptableService _expertComptableService;

        public ExpertComptableController(IExpertComptableService expertComptableService)
        {
            _expertComptableService = expertComptableService;
        }

       public async Task<IActionResult> IndexAsync()
        {
            var expComptable = await _expertComptableService.GetAllAsync();
            return View(expComptable.ToViewModelsLists());
        }

        //public async Task<IActionResult> Create()
        //{
        //    var model = await _expertComptableService.
        //} 
    }
}
