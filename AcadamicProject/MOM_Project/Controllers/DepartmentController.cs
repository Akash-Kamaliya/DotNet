using Microsoft.AspNetCore.Mvc;

namespace MOM_Project.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult DepartmentList()
        {
            return View();
        }

        public IActionResult DepartmentView()
        {
            return View();
        }

        public IActionResult DepartmentDeleteForm()
        {
            return View();
        }

        public IActionResult DepartmentAdd()
        {
            return View();
        }

        public IActionResult DepartmentEditForm()
        {
            return View();
        }
    }
}
