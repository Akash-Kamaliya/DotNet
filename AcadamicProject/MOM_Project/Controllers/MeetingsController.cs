using Microsoft.AspNetCore.Mvc;

namespace MOM_Project.Controllers
{
    public class MeetingsController : Controller
    {
        public IActionResult MeetingsList()
        {
            return View();
        }

        public IActionResult MeetingsAdd()
        {
            return View();
        }
        public IActionResult MeetingsView()
        {
            return View();
        }
        public IActionResult MeetingsEditForm()
        {
            return View();
        }
        public IActionResult MeetingsDeleteForm()
        {
            return View();
        }
    }
}
