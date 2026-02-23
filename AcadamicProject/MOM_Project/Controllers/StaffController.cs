using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

namespace MOM_Project.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult StaffList()
        {
            return View();
        }

        public IActionResult StaffAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StaffAdd(StaffModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("StaffList");
        }

        public IActionResult StaffEditForm()
        {
            var model = new StaffModel
            {
                StaffName = "Raju Patel",
                DepartmentName = "CSE",
                MobileNo = "9876543210",
                EmailAddress = "raju@email.com"
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult StaffEditForm(StaffModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("StaffList");
        }

        public IActionResult StaffView()
        {
            return View();
        }

        public IActionResult StaffDeleteForm()
        {
            return View();
        }
    }
}
