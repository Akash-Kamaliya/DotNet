using Microsoft.AspNetCore.Mvc;
using MOMPortal.Services;
using MOMPortal.Models;

namespace MOMPortal.Controllers
{
    public class RolesController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public RolesController(IApiService apiService, IAuthService authService)
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
                var roles = await _apiService.GetRolesAsync();
                return View(roles);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load roles";
                return View(new List<RoleDto>());
            }
        }

        public IActionResult Create()
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.CreateRoleAsync(model);
                TempData["Success"] = "Role created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to create role");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                var role = await _apiService.GetRoleByIdAsync(id);
                var model = new CreateRoleViewModel { RoleName = role.RoleName };
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load role";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateRoleViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.UpdateRoleAsync(id, model);
                TempData["Success"] = "Role updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to update role");
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
                await _apiService.DeleteRoleAsync(id);
                TempData["Success"] = "Role deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to delete role";
                return RedirectToAction("Index");
            }
        }
    }
}