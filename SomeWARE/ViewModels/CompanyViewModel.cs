using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.ViewModels
{
    public class CompanyViewModel : LocationViewModel
    {
        [Required]
        public string Name { get; set; } 
    }
}
