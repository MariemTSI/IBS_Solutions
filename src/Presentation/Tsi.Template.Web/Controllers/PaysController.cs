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
    public class PaysController : Controller
    {
        private readonly IPaysService _paysService;
        private readonly IPaysModelFactory _paysModelFactory;


        public PaysController(IPaysService PaysService, IPaysModelFactory PaysModelFactory)
        {
            _paysService = PaysService;
            _paysModelFactory = PaysModelFactory;
        }

        public async Task<IActionResult> Index()
        {
            var Pays = (await _paysService.GetAllAsync()).ToViewModels();

            return View(Pays);
        }
        public async Task<IActionResult> Create()
        {
            var model = await _paysModelFactory.PreparePaysViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaysViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Pays = model.ToPays();

            await _paysService.CreatePaysAsync(Pays);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Pays/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _paysService.DeletePaysAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Pays/Edit/{id}")]
        public async Task<IActionResult> EditAsync(int id) => View((await _paysService.GetPaysbyId(id)).ToViewModel());


        [HttpPost]
        public async Task<IActionResult> EditAsync(PaysViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _paysService.UpdatePaysAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }

}
