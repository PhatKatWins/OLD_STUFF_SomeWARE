using Microsoft.AspNetCore.Mvc;
using SomeWARE.Data.Repository;
using SomeWARE.Helpers;
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
    public class ItemController : Controller
    {
        private IRepository _repository;

        public ItemController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Edit(int companyId)
        {
            var warehouseCodes = new List<string>();
            var warehouseQuantities = new List<int>();
            var aisles = new List<string>();
            var bins = new List<string>();
            var aislesPerWarehouse = new List<List<string>>();
            var binsPerWarehouse = new List<List<string>>();

            var warehouses = _repository.GetAll<Warehouse>().Where(w => w.CompanyId == companyId);

            foreach (var w in warehouses)
            {
                warehouseCodes.Add(w.Code);
                warehouseQuantities.Add(0);
                aisles.Add(String.Empty);
                bins.Add(String.Empty);
                aislesPerWarehouse.Add(WarehouseSectionHelper.GetSections(w.Aisles, w.AisleOrder));
                binsPerWarehouse.Add(WarehouseSectionHelper.GetSections(w.BinsPerAisle, w.BinOrder));
            }

            var vm = new ItemViewModel
            {
                CompanyId = companyId,
                WarehouseCodes = warehouseCodes,
                WarehouseQuantities = warehouseQuantities,
                AislesPerWarehouse = aislesPerWarehouse,
                BinsPerWarehouse = binsPerWarehouse,
                Aisles = aisles,
                Bins = bins
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemViewModel vm)
        {
            var item = new Item
            {
                CompanyId = vm.CompanyId,
                Name = vm.Name,
                Price = vm.Price,
                Availabilities = new List<Availability>()
            };


            for (int i = 0; i < vm.WarehouseCodes.Count; i++)
            {
                item.Availabilities.Add(new Availability
                {
                    WarehouseCode = vm.WarehouseCodes[i],
                    Quantity = vm.WarehouseQuantities[i],
                    Aisle = vm.Aisles[i],
                    Bin = vm.Bins[i]
                });
            }

            _repository.Add<Item>(item);

            if (await _repository.SaveChangesAsync())
            {
                return RedirectToAction("Details", "Company", new { id = vm.CompanyId });
            }
            return View(vm);
        }

        public async Task<IActionResult> Delete(int id, int companyId)
        {
            var availabilities = _repository.GetAll<Availability>().Where(a => a.ItemId == id);
            _repository.RemoveAll<Availability>(availabilities);
            _repository.Remove<Item>(id);

            await _repository.SaveChangesAsync();

            return RedirectToAction("Details", "Company", new { id = companyId });
        }
    }
}
