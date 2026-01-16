using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

namespace MOM_Project.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult DashboardView(DashboardModel dm)
        {
            ViewBag.vdm = dm.DemoData;
            return View();
        }

    }
}
