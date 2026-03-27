using Microsoft.AspNetCore.Mvc;
using MOMPortal.Services;
using MOMPortal.Models;

namespace MOMPortal.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public DepartmentsController(IApiService apiService, IAuthService authService)
        {
            _apiService = apiService;
            _authService = authService;
        }

        private bool CheckAdminAccess()
        {
            var user = _authService.GetCurrentUser();
            if (user == null || !_authService.HasRole(new[] { "Admin", "SuperAdmin" }))
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> Index()
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                var departments = await _apiService.GetDepartmentsAsync();
                return View(departments);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load departments";
                return View(new List<DepartmentDto>());
            }
        }

        public IActionResult Create()
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.CreateDepartmentAsync(model);
                TempData["Success"] = "Department created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to create department");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                var dept = await _apiService.GetDepartmentByIdAsync(id);
                var model = new CreateDepartmentViewModel { DepartmentName = dept.DepartmentName };
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load department";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateDepartmentViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.UpdateDepartmentAsync(id, model);
                TempData["Success"] = "Department updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to update department");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                await _apiService.DeleteDepartmentAsync(id);
                TempData["Success"] = "Department deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to delete department";
                return RedirectToAction("Index");
            }
        }
    }
}