using Microsoft.AspNetCore.Mvc;
using MOMPortal.Services;
using MOMPortal.Models;

namespace MOMPortal.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public MeetingsController(IApiService apiService, IAuthService authService)
        {
            _apiService = apiService;
            _authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            var user = _authService.GetCurrentUser();
            if (user == null)
                return RedirectToAction("Login", "Account");

            try
            {
                var meetings = await _apiService.GetMeetingsAsync();
                var venues = await _apiService.GetVenuesAsync();
                var types = await _apiService.GetMeetingTypesAsync();
                var departments = await _apiService.GetDepartmentsAsync();

                var viewModel = new MeetingListViewModel
                {
                    Meetings = meetings,
                    Venues = venues,
                    MeetingTypes = types,
                    Departments = departments
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load meetings";
                return View(new MeetingListViewModel { Meetings = new List<MeetingDto>() });
            }
        }

        public async Task<IActionResult> Create()
        {
            var venues = await _apiService.GetVenuesAsync();
            var types = await _apiService.GetMeetingTypesAsync();
            var departments = await _apiService.GetDepartmentsAsync();

            ViewBag.Venues = venues;
            ViewBag.Types = types;
            ViewBag.Departments = departments;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in all required fields";
                return RedirectToAction("Create");
            }

            try
            {
                await _apiService.CreateMeetingAsync(model);
                TempData["Success"] = "Meeting created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to create meeting";
                return RedirectToAction("Create");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var meeting = await _apiService.GetMeetingByIdAsync(id);
                var venues = await _apiService.GetVenuesAsync();
                var types = await _apiService.GetMeetingTypesAsync();
                var departments = await _apiService.GetDepartmentsAsync();

                ViewBag.Venues = venues;
                ViewBag.Types = types;
                ViewBag.Departments = departments;

                var viewModel = new CreateMeetingViewModel
                {
                    MeetingTitle = meeting.MeetingTitle,
                    MeetingNumber = meeting.MeetingNumber,
                    MeetingDescription = meeting.MeetingDescription,
                    MeetingDate = meeting.MeetingDate,
                    MeetingVenueID = meeting.MeetingVenueID,
                    MeetingTypeID = meeting.MeetingTypeID,
                    DepartmentID = meeting.DepartmentID
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to load meeting";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateMeetingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in all required fields";
                return RedirectToAction("Edit", new { id });
            }

            try
            {
                await _apiService.UpdateMeetingAsync(id, model);
                TempData["Success"] = "Meeting updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to update meeting";
                return RedirectToAction("Edit", new { id });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _apiService.DeleteMeetingAsync(id);
                TempData["Success"] = "Meeting deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to delete meeting";
                return RedirectToAction("Index");
            }
        }
    }
}