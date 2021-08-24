using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.Helpers;
using Tsi.Template.Services;
using Tsi.Template.ViewModels;
using Tsi.Template.Web.Factories;

namespace Tsi.Template.Web.Controllers
{
    public class SocieteController : Controller
    {
        private readonly ISocieteService _societeService;
        private readonly ISocieteModelFactory _societeModelFactory;
        private readonly IExpertComptableService _expertComptableService;

        public SocieteController(ISocieteService SocieteService, ISocieteModelFactory SocieteModelFactory, IExpertComptableService ExpertComptableService)
        {
            _societeService = SocieteService;
            _societeModelFactory = SocieteModelFactory;
            _expertComptableService = ExpertComptableService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var societe = await _societeService.GetAllAsync();
            return View(societe.ToViewModelsLists());
        }

        public async Task<IActionResult> Create()
        {
            var model = await _societeModelFactory.PrepareSocieteViewModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocieteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _societeModelFactory.PopulateExpertComptablsSelectListAsync(model);
                return View(model);
            }

            var societe = model.ToSociete();

            await _societeService.CreateSocieteAsync(societe);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Societe/Edit/{id}")]
        public async Task<IActionResult> EditAsync(int id)
        {
            var model = await _societeModelFactory.PrepareSocieteCreateModelAsync(id);
            await _societeModelFactory.PopulateExpertComptablsSelectListAsync(model);
            return View(model);
        }
        //public async Task<IActionResult> EditAsync(int id) => View((await _societeService.GetSocietebyIdAsync(id)).ToViewModel());

        [HttpPost]
        public async Task<IActionResult> EditAsync(SocieteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _societeModelFactory.PopulateExpertComptablsSelectListAsync(model);
                return View(model);
            }

            await _societeService.UpdateSocieteAsync(model);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _societeService.DeleteSocieteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
