using SomeWARE.Migrations;
using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.ViewModels
{
    public class DetailsViewModel : CompanyViewModel
    {
        public int CompanyId { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Item> Items { get; set; }
    }
}
