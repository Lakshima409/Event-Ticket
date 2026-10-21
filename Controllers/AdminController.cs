using Microsoft.AspNetCore.Mvc;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            // Check if user is logged in and is an admin
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Admin.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "Admin Dashboard - ETicketing System";
            return View();
        }

        public IActionResult Users()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Admin.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "Manage Users - ETicketing System";
            return View();
        }

        public IActionResult Events()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Admin.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "Manage Events - ETicketing System";
            return View();
        }

        public IActionResult Reports()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Admin.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "Reports - ETicketing System";
            return View();
        }
    }
}
