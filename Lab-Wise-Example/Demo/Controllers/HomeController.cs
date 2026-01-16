using System.Diagnostics;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["message"] = "Data Fetch Succesfully !!";
            ViewBag.name = "Akash";
            ViewBag.student = new[]{
            new {
            name = "Akash",
            details = new[]
            {
                    new{sem = 1 , spi = 9.1 }
            }
        },
        new {
            name = "Sky",
            details = new[]
            {
                    new{sem = 1 , spi = 5.1 }
            }
        }
    };
            return View();
        }
    }
}
