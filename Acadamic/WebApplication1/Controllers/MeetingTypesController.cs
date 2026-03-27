using Microsoft.AspNetCore.Mvc;
using MOMPortal.Services;
using MOMPortal.Models;

namespace MOMPortal.Controllers
{
    public class MeetingTypesController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public MeetingTypesController(IApiService apiService, IAuthService authService)
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
                var types = await _apiService.GetMeetingTypesAsync();
                return View(types);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load meeting types";
                return View(new List<MeetingTypeDto>());
            }
        }

        public IActionResult Create()
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingTypeViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.CreateMeetingTypeAsync(model);
                TempData["Success"] = "Meeting type created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to create meeting type");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                var type = await _apiService.GetMeetingTypeByIdAsync(id);
                var model = new CreateMeetingTypeViewModel { MeetingTypeName = type.MeetingTypeName, Remarks = type.Remarks };
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load meeting type";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateMeetingTypeViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.UpdateMeetingTypeAsync(id, model);
                TempData["Success"] = "Meeting type updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to update meeting type");
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
                await _apiService.DeleteMeetingTypeAsync(id);
                TempData["Success"] = "Meeting type deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to delete meeting type";
                return RedirectToAction("Index");
            }
        }
    }
}