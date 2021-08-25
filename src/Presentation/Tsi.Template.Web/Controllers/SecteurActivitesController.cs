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
    public class SecteurActivitesController : Controller
    {
        private readonly ISecteurActiviteService _secteurActiviteService;
        private readonly ISecteurActivitesModelFactory _secteurActivitesModelFactory;

        public SecteurActivitesController(ISecteurActiviteService secteurActiviteService, ISecteurActivitesModelFactory secteurActivitesModelFactory)
        {
            _secteurActiviteService = secteurActiviteService;
            _secteurActivitesModelFactory = secteurActivitesModelFactory;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var secteurActivite = await _secteurActiviteService.GetAllAsync();
            return View(secteurActivite.ToViewModelsLists());
        }

        public async Task<IActionResult> Create()
        {
            var model = await _secteurActivitesModelFactory.PrepareSecteurActivitesViewModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SecteursActivitesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var secteurActivite = model.ToSecteurActivite();

            await _secteurActiviteService.CreateSecteursActivitesAsync(secteurActivite);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("SecteurActivites/Edit/{id}")]
        public async Task<IActionResult> EditAsync(int id) => View((await _secteurActiviteService.GetSecteursActivitesbyIdAsync(id)).ToViewModel());

        [HttpPost]
        public async Task<IActionResult> EditAsync(SecteursActivitesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _secteurActiviteService.UpdateSecteursActivitesAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _secteurActiviteService.DeleteSecteursActivitesAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
