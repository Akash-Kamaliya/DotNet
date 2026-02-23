using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

namespace MOM_Project.Controllers
{
    public class AuthController : Controller
    {

        private static List<UserModel> users = new List<UserModel>();

        static AuthController()
        {
            users.Add(new UserModel
            {
                Email = "akashkamaliya112@gmail.com",
                Password = "Akash112"
            });
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return RedirectToAction("DashboardView", "Dashboard");
            }

            ViewBag.Error = "Invalid Email or Password";
            return View();
        }
            
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            users.Add(model);
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
            
    }
}
