using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

namespace MOM_Project.Controllers
{
    public class DeshboardController : Controller
    {
        
        public IActionResult DeshboardView(DeshboardModel dm)
        {
            ViewBag.vdm = dm.DemoData;
            return View();
        }

    }
}
