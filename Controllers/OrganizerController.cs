using Microsoft.AspNetCore.Mvc;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Controllers
{
    public class OrganizerController : Controller
    {
        public IActionResult Index()
        {
            // Check if user is logged in and is an organizer
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Organizer.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "Organizer Dashboard - ETicketing System";
            return View();
        }

        public IActionResult MyEvents()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Organizer.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "My Events - ETicketing System";
            return View();
        }

        public IActionResult CreateEvent()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Organizer.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "Create Event - ETicketing System";
            return View();
        }

        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Organizer.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "Organizer Profile - ETicketing System";
            return View();
        }
    }
}
