using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThemeConversion.Models;

namespace ThemeConversion.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Resume()
        {
            return View();
        }
    }
}
