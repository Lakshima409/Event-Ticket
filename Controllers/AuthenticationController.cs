using Microsoft.AspNetCore.Mvc;
using EventTicketingWebApp.Business.Interfaces;
using EventTicketingWebApp.Data.Entities;
using EventTicketingWebApp.Models;
using EventTicketingWebApp.Helpers;
using System.Security.Claims;

namespace EventTicketingWebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Validate organization fields for Organizer role
                if (model.Role == UserRole.Organizer)
                {
                    if (string.IsNullOrEmpty(model.OrganizationName))
                    {
                        ModelState.AddModelError(nameof(model.OrganizationName), "Organization Name is required for Organizer accounts.");
                        return View(model);
                    }
                }

                var user = await _authService.RegisterAsync(model);

                if (user != null)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Set session
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserRole", user.Role.ToString());
                    HttpContext.Session.SetString("UserFullName", $"{user.FirstName} {user.LastName}");

                    // Redirect based on user role
                    return RedirectToRoleBasedPage(user.Role);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Email may already be in use.");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["ErrorMessage"] = "Email and password are required.";
                return View(new { Email = email });
            }

            var user = await _authService.AuthenticateAsync(email, password);
            
            if (user != null)
            {
                _logger.LogInformation("User logged in.");

                // Set session
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserRole", user.Role.ToString());
                HttpContext.Session.SetString("UserFullName", $"{user.FirstName} {user.LastName}");

                // Debug logging
                _logger.LogInformation($"User {user.Email} logged in with role: {user.Role}");

                // Redirect based on user role
                return RedirectToRoleBasedPage(user.Role);
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
            }

            return View(new { Email = email });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToRoleBasedPage(UserRole role)
        {
            _logger.LogInformation($"Redirecting user with role: {role}");
            
            return role switch
            {
                UserRole.Customer => RedirectToAction("Index", "Home"), // Customers go to main home page
                UserRole.Organizer => RedirectToAction("Index", "Organizer"),
                UserRole.Admin => RedirectToAction("Index", "Admin"),
                _ => RedirectToAction("Index", "Home")
            };
        }
    }
}
