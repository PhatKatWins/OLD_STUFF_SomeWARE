using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using SomeWARE.Data;
using SomeWARE.Data.Repository;
using SomeWARE.Models;
using SomeWARE.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Controllers
{
    public class CompanyController : Controller
    {
        private IRepository _repository;

        public CompanyController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var vm = _repository.GetAll<Company>();

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var company = _repository.Get<Company>(id);
            var locationData = company.LocationData.Split(".");

            var vm = new DetailsViewModel()
            {
                Name = company.Name,
                Street = locationData[0],
                Number = locationData[1],
                Postcode = locationData[2],
                City = locationData[3],
                Country = locationData[4],
                CompanyId = id,
                Warehouses = _repository.GetAll<Warehouse>().Where(w => w.CompanyId == id).ToList(),
                Items = _repository.GetAll<Item>().Where(w => w.CompanyId == id).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new CompanyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var location = String.Join(".", vm.Street, vm.Number, vm.Postcode, vm.City, vm.Country);

                var company = new Company
                {
                    Name = vm.Name,
                    LocationData = location
                };

                _repository.Add<Company>(company);

                if (await _repository.SaveChangesAsync()) return RedirectToAction("Index", "Home");
            }

            return View(vm);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var objects = _repository.GetAll<Warehouse>().Where(w => w.CompanyId == id);

            _repository.RemoveAll<Warehouse>(objects);

            _repository.Remove<Company>(id);

            await _repository.SaveChangesAsync();

            return RedirectToAction("Index", "Company");
        }
    }
}
