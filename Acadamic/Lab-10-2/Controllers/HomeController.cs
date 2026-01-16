using System.Diagnostics;
using Lab_10_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_10_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult DownloadFile()
        {
            return File("Akash.txt","text/plain","Akash.txt");
        }

        public IActionResult ContenetResultDemo()
        {
            return Content("Welcome TO my Wbsite");
        }
        public IActionResult Page()
        {
            return NotFound("4O4 NotFound");
        }
        public IActionResult Page2()
        {
            return Ok("Website is succesfully Loaded");
        }
        public IActionResult GetJsonData()
        {
            var jsondata = new
            {
                Id = 1,
                Name = "Akash"
            };
            return Json(jsondata);
        }

        public IActionResult Privacy()
        {
            return RedirectToAction("Youtube");
        }
        public IActionResult Youtube()
        {
            return Redirect("https://www.youtube.com/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
