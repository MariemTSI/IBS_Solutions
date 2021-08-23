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
    public class ModePayementController : Controller
    {
        private readonly IModePayementService _ModePayementService;
        private readonly IModePayementModelFactory _ModePayementModelFactory;

        public ModePayementController(IModePayementService ModePayementService, IModePayementModelFactory ModePayementModelFactory)
        {
            _ModePayementService = ModePayementService;
            _ModePayementModelFactory = ModePayementModelFactory;
        }

        public async Task<IActionResult> Index()
        {
            var ModePayements = (await _ModePayementService.GetAllAsync()).ToViewModels();

            return View(ModePayements);
        }


        public async Task<IActionResult> Create()
        {
            var model = await _ModePayementModelFactory.PrepareModePayementViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModePayementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ModePayement = model.ToModePayement();

            await _ModePayementService.CreateModePayementAsync(ModePayement);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("ModePayement/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _ModePayementService.DeleteModePayementAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("ModePayement/Edit/{Id}")]
        public async Task<IActionResult> EditAsync(int Id) => View((await _ModePayementService.GetModePayementbyId(Id)).ToViewModel());


        [HttpPost]
        public async Task<IActionResult> EditAsync(ModePayementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _ModePayementService.UpdateModePayementAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
