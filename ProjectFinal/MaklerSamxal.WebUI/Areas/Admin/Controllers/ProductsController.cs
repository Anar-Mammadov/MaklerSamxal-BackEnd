using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MediatR;
using MaklerSamxal.WebUI.Application.Products;

namespace MaklerSamxal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ProductsPagedQuery request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        public async Task<IActionResult> Details(ProductsSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }

            return View(respons);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductsCreateComman command)
        {

            Product model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductsRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }

        public async Task<IActionResult> Edit(ProductsSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            ProductsViewModel vm = new ProductsViewModel();

            vm.Id = respons.Id;
            vm.Title = respons.Title;
            vm.Location = respons.Location;
            vm.Price = respons.Price;
            vm.ImagePath = respons.ImagePath;
            vm.Bed = respons.Bed;
            vm.Baths = respons.Baths;
            vm.Sqft = respons.Sqft;
            vm.Description = respons.Description;
            vm.ShopDescription = respons.ShopDescription;

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductsEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }
    }
}
