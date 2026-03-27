using Microsoft.AspNetCore.Mvc;
using MOMPortal.Services;
using MOMPortal.Models;

namespace MOMPortal.Controllers
{
    public class StaffController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public StaffController(IApiService apiService, IAuthService authService)
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
                var staff = await _apiService.GetStaffAsync();
                var roles = await _apiService.GetRolesAsync();
                var departments = await _apiService.GetDepartmentsAsync();

                var viewModel = new StaffListViewModel
                {
                    Staff = staff,
                    Roles = roles,
                    Departments = departments
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load staff";
                return View(new StaffListViewModel { Staff = new List<StaffDto>(), Roles = new List<RoleDto>(), Departments = new List<DepartmentDto>() });
            }
        }

        public async Task<IActionResult> Create()
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            var roles = await _apiService.GetRolesAsync();
            var departments = await _apiService.GetDepartmentsAsync();

            ViewBag.Roles = roles;
            ViewBag.Departments = departments;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                var roles = await _apiService.GetRolesAsync();
                var departments = await _apiService.GetDepartmentsAsync();
                ViewBag.Roles = roles;
                ViewBag.Departments = departments;
                return View(model);
            }

            try
            {
                await _apiService.CreateStaffAsync(model);
                TempData["Success"] = "Staff created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to create staff");
                return RedirectToAction("Create");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                var staff = await _apiService.GetStaffByIdAsync(id);
                var roles = await _apiService.GetRolesAsync();
                var departments = await _apiService.GetDepartmentsAsync();

                var model = new CreateStaffViewModel
                {
                    StaffName = staff.StaffName,
                    MobileNo = staff.MobileNo,
                    EmailAddress = staff.EmailAddress,
                    RoleID = staff.RoleID,
                    DepartmentID = staff.DepartmentID,
                    IsActive = staff.IsActive,
                    Remarks = staff.Remarks
                };

                ViewBag.Roles = roles;
                ViewBag.Departments = departments;
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load staff";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateStaffViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id });
            }

            try
            {
                await _apiService.UpdateStaffAsync(id, model);
                TempData["Success"] = "Staff updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to update staff");
                return RedirectToAction("Edit", new { id });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                await _apiService.DeleteStaffAsync(id);
                TempData["Success"] = "Staff deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to delete staff";
                return RedirectToAction("Index");
            }
        }
    }
}