using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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
    public class WarehouseController : Controller
    {
        private IRepository _repository;

        public WarehouseController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Edit(int companyId)
        {
            var vm = new WarehouseViewModel() 
            { 
                CompanyId = companyId ,
                Message = "When using the ALPHABETIC order, you can only have" +
                "a maximum of 26 AISLES or BINS."
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WarehouseViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.AisleOrder == Order.ALPHABETIC && vm.Aisles > 26)
                {
                    vm.Message = "You cannot have more than 26 AISLES"
                        + " when using the ALPHABETIC order.";
                    return View(vm);
                };
                if (vm.BinOrder == Order.ALPHABETIC && vm.Bins > 26)
                {
                    vm.Message = "You cannot have more than 26 BINS"
                        + " when using the ALPHABETIC order.";
                    return View(vm);
                }


                var locationData = String.Join(".", vm.Street, vm.Number, vm.Postcode, vm.City, vm.Country);
                var warehouse = new Warehouse
                {
                    CompanyId = vm.CompanyId,
                    Code = vm.Code,
                    LocationData = locationData,
                    Aisles = vm.Aisles,
                    BinsPerAisle = vm.Bins,
                    AisleOrder = vm.AisleOrder,
                    BinOrder = vm.BinOrder
                };

                _repository.Add<Warehouse>(warehouse);

                if (await _repository.SaveChangesAsync()) return RedirectToAction("Details", "Company", new { id = vm.CompanyId });
                else return View(vm);
            }
            else return View(vm);
        }

        public async Task<IActionResult> Remove(int id, int companyId)
        {
            _repository.Remove<Warehouse>(id);

            await _repository.SaveChangesAsync();

            return RedirectToAction("Details", "Company", new { id = companyId });
        }

        public IActionResult Explore(int id)
        {
            var warehouse = _repository.Get<Warehouse>(id);

            List<string> aisles = new List<string>();
            List<string> bins = new List<string>();

            if (warehouse.AisleOrder == Order.NUMERIC)
            {
                for (int i = 1; i <= warehouse.Aisles; i++)
                {
                    aisles.Add(i.ToString());
                }
            } else
            {
                var letter = (int)'a';
                for (int i = 0; i < warehouse.Aisles; i++)
                {
                    aisles.Add(((char)(letter + i)).ToString().ToUpper());
                }
            }

            if (warehouse.BinOrder == Order.NUMERIC)
            {
                for (int i = 1; i <= warehouse.BinsPerAisle; i++)
                {
                    bins.Add(i.ToString());
                }
            }
            else
            {
                var letter = (int)'a';
                for (int i = 0; i < warehouse.BinsPerAisle; i++)
                {
                    bins.Add(((char)(letter + i)).ToString().ToUpper());
                }
            }

            var vm = new ExploreViewModel()
            {
                Code = warehouse.Code,
                Aisles = aisles,
                Bins = bins
            };

            return View(vm);
        }
    }
}
