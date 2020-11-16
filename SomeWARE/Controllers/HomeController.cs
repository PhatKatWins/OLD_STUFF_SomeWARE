using Microsoft.AspNetCore.Mvc;
using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var letter = (int)'c';
            var nextLetter = letter + 1;
            Dictionary<string, int> StockCodes = new Dictionary<string, int>();
            StockCodes.Add("GR045", 30);
            Debug.WriteLine(((char)nextLetter).ToString().ToUpper());
            return View();
        }

        public IActionResult TestPage()
        {
            return View();
        }
    }
}
