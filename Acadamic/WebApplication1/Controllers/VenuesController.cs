using Microsoft.AspNetCore.Mvc;
using MOMPortal.Services;
using MOMPortal.Models;

namespace MOMPortal.Controllers
{
    public class VenuesController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public VenuesController(IApiService apiService, IAuthService authService)
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
                var venues = await _apiService.GetVenuesAsync();
                return View(venues);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load venues";
                return View(new List<VenueDto>());
            }
        }

        public IActionResult Create()
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVenueViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.CreateVenueAsync(model);
                TempData["Success"] = "Venue created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to create venue");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            try
            {
                var venue = await _apiService.GetVenueByIdAsync(id);
                var model = new CreateVenueViewModel { MeetingVenueName = venue.MeetingVenueName };
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load venue";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateVenueViewModel model)
        {
            if (!CheckAdminAccess())
                return RedirectToAction("Index", "Dashboard");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.UpdateVenueAsync(id, model);
                TempData["Success"] = "Venue updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to update venue");
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
                await _apiService.DeleteVenueAsync(id);
                TempData["Success"] = "Venue deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to delete venue";
                return RedirectToAction("Index");
            }
        }
    }
}