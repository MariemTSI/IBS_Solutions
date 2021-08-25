using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.Helpers;
using Tsi.Template.ViewModels;
using Tsi.Template.Web.Factories;

namespace Tsi.Template.Web.Controllers
{
    public class ExpertComptableController : Controller
    {
        private readonly IExpertComptableService _expertComptableService;
        private readonly IExpertComptableModelFactory _expertComptableModelFactory;
        private readonly IPaysService _paysService;

        public ExpertComptableController(IExpertComptableService expertComptableService, IExpertComptableModelFactory expertComptableModelFactory, IPaysService paysService)
        {
            _expertComptableService = expertComptableService;
            _expertComptableModelFactory = expertComptableModelFactory;
            _paysService = paysService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var expComptable = await _expertComptableService.GetAllAsync();
            return View(expComptable.ToViewModelsLists());
        }

        public async Task<IActionResult> Create()
        {
            var model = await _expertComptableModelFactory.PrepareExpertComptableViewModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpertComptableViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _expertComptableModelFactory.PopulatePayssSelectListAsync(model);
                return View(model);
            }

            var expertComptable = model.ToExpertComptable();
            await _expertComptableService.CreateExpertComptableAsync(expertComptable);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("ExpertComptable/Edit/{id}")]
        public async Task<IActionResult> EditAsync(int id)
        {
            var model = await _expertComptableModelFactory.PrepareExpertComptableCreateModelAsync(id);
            await _expertComptableModelFactory.PopulatePayssSelectListAsync(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(ExpertComptableViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model = await _expertComptableModelFactory.PopulatePayssSelectListAsync(model);
                return View(model);
            }

            await _expertComptableService.UpdateExpertComptableAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _expertComptableService.DeleteExpertComptableAsync(id);
            return RedirectToAction(nameof(Index)); 
        }

    }
}
