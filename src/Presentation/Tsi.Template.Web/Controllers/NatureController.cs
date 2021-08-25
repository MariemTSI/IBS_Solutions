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
    public class NatureController : Controller
    {
        private readonly INatureService _natureService;
        private readonly INatureModelFactory _natureModelFactory;


        public NatureController(INatureService NatureService, INatureModelFactory NatureModelFactory)
        {
            _natureService = NatureService;
            _natureModelFactory = NatureModelFactory;
        }

        public async Task<IActionResult> Index()
        {
            var Pays = (await _natureService.GetAllAsync()).ToViewModels();

            return View(Pays);
        }
        public async Task<IActionResult> Create()
        {
            var model = await _natureModelFactory.PrepareNatureViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NatureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Nature = model.ToNature();

            await _natureService.CreatePaysAsync(Nature);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Nature/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _natureService.DeleteNatureAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Nature/Edit/{id}")]
        public async Task<IActionResult> EditAsync(int id) => View((await _natureService.GetNaturebyId(id)).ToViewModel());


        [HttpPost]
        public async Task<IActionResult> EditAsync(NatureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _natureService.UpdateNatureAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
