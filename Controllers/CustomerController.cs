using Microsoft.AspNetCore.Mvc;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult MyTickets()
        {
            // Check if user is logged in and is a customer
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Customer.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "My Tickets - ETicketing System";
            return View();
        }

        public IActionResult MyProfile()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userId) || userRole != UserRole.Customer.ToString())
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewData["Title"] = "My Profile - ETicketing System";
            return View();
        }
    }
}
