using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

namespace MOM_Project.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepartmentAdd(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("DepartmentList");
            }

            return View(model);
        }

        public IActionResult DepartmentEditForm(int id)
        {
            DepartmentModel model = new DepartmentModel()
            {
                DepartmentID = id,
                DepartmentName = "IT Department",
                Modified = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DepartmentEditForm(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("DepartmentList");
            }

            return View(model);
        }

        public IActionResult DepartmentList()
        {
            return View();
        }

        public IActionResult DepartmentDeleteForm()
        {
            return View();
        }

        public IActionResult DepartmentView()
        {
            return View();
        }
    }
}
