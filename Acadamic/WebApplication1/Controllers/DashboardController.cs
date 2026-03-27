using Microsoft.AspNetCore.Mvc;
using MOMPortal.Services;
using MOMPortal.Models;

namespace MOMPortal.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public DashboardController(IApiService apiService, IAuthService authService)
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
                var now = DateTime.Now;
                var upcomingMeetings = meetings
                    .Where(m => m.MeetingDate > now)
                    .OrderBy(m => m.MeetingDate)
                    .Take(5)
                    .ToList();

                var isAdmin = _authService.HasRole(new[] { "Admin", "SuperAdmin" });
                int staffCount = 0, deptCount = 0, rolesCount = 0;

                if (isAdmin)
                {
                    var staffTask = _apiService.GetStaffAsync();
                    var deptsTask = _apiService.GetDepartmentsAsync();
                    var rolesTask = _apiService.GetRolesAsync();

                    await Task.WhenAll(staffTask, deptsTask, rolesTask);

                    staffCount = staffTask.Result.Count;
                    deptCount = deptsTask.Result.Count;
                    rolesCount = rolesTask.Result.Count;
                }

                ViewBag.TotalMeetings = meetings.Count;
                ViewBag.StaffCount = staffCount;
                ViewBag.DeptCount = deptCount;
                ViewBag.RolesCount = rolesCount;
                ViewBag.UpcomingMeetings = upcomingMeetings;
                ViewBag.IsAdmin = isAdmin;
                ViewBag.UserEmail = user.Email;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Failed to load dashboard";
                return View();
            }
        }
    }
}