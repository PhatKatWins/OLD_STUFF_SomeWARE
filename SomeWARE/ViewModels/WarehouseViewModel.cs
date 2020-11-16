using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.ViewModels
{
    public class WarehouseViewModel : LocationViewModel
    {
        public int CompanyId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int Aisles { get; set; }
        [Required]
        public int Bins { get; set; }
        [Required]
        public Order AisleOrder { get; set; }
        [Required]
        public Order BinOrder { get; set; }
        public string Message { get; set; }
    }
}
