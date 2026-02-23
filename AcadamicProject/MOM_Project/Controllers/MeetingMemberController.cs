using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

namespace MOM_Project.Controllers
{
    public class MeetingMemberController : Controller
    {
        public IActionResult MeetingMemberList()
        {
            return View();
        }

        public IActionResult MeetingMemberAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MeetingMemberAdd(MeetingMemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("MeetingMemberList");
        }

        public IActionResult MeetingMemberEditForm()
        {
            var model = new MeetingMemberModel
            {
                MeetingName = "Project Kickoff",
                StaffName = "Rahul",
                IsPresent = true,
                Remarks = "Attended full meeting"
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult MeetingMemberEditForm(MeetingMemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("MeetingMemberList");
        }

        public IActionResult MeetingMemberDeleteForm()
        {
            return View();
        }

        public IActionResult MeetingMemberView()
        {
            return View();
        }
    }
}
