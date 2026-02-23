using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

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

        [HttpPost]
        public IActionResult MeetingsAdd(MeetingsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("MeetingsList");
        }

        public IActionResult MeetingsEditForm()
        {
            var model = new MeetingsModel
            {
                MeetingDate = DateTime.Now,
                MeetingTypeName = "Review Meeting",
                VenueName = "Conference Room A",
                DepartmentName = "CSE",
                MeetingDescription = "Quarterly review discussion"
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult MeetingsEditForm(MeetingsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("MeetingsList");
        }

        public IActionResult MeetingsDeleteForm()
        {
            return View();
        }

        public IActionResult MeetingsView()
        {
            return View();
        }
    }
}
