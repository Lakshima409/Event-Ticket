using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EventTicketingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventTicketingWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult EventDetail(int id)
    {
        // Mock data for demonstration purposes
        var eventsData = new List<EventDetailViewModel>
        {
            new EventDetailViewModel
            {
                Id = 1,
                Title = "Rock Concert 2024",
                Category = "Concert",
                ImageUrl = "/images/rock-concert.jpg",
                Date = new DateTime(2024, 12, 15),
                Time = "8:00 PM",
                Location = "New York, NY",
                Venue = "Madison Square Garden",
                Description = "Experience an electrifying night of rock music with legendary bands and emerging artists. Get ready to headbang!",
                NormalPrice = 75.00m,
                VipPrice = 150.00m,
                OrganizerName = "Music Events Pro",
                OrganizerDescription = "Leading concert promoter with 15+ years of experience organizing major music events.",
                OrganizerEmail = "info@musiceventspro.com",
                OrganizerPhone = "+1 (555) 234-5678",
                OrganizerWebsite = "www.musiceventspro.com"
            },
            new EventDetailViewModel
            {
                Id = 2,
                Title = "Classical Symphony Night",
                Category = "Classical",
                ImageUrl = "/images/classical-symphony.jpg",
                Date = new DateTime(2024, 12, 22),
                Time = "7:30 PM",
                Location = "New York, NY",
                Venue = "Carnegie Hall",
                Description = "An evening of timeless classical masterpieces performed by the renowned City Symphony Orchestra. A treat for the senses.",
                NormalPrice = 60.00m,
                VipPrice = 120.00m,
                OrganizerName = "Theater Productions Inc.",
                OrganizerDescription = "Professional theater company specializing in classical and contemporary performances.",
                OrganizerEmail = "contact@theaterproductions.com",
                OrganizerPhone = "+1 (555) 345-6789",
                OrganizerWebsite = "www.theaterproductions.com"
            },
            new EventDetailViewModel
            {
                Id = 3,
                Title = "Jazz Night Live",
                Category = "Jazz",
                ImageUrl = "/images/jazz-night.jpg",
                Date = new DateTime(2024, 11, 28),
                Time = "9:00 PM",
                Location = "New York, NY",
                Venue = "Blue Note Club",
                Description = "Immerse yourself in the soulful rhythms of live jazz. Featuring top local and international jazz artists.",
                NormalPrice = 50.00m,
                VipPrice = 100.00m,
                OrganizerName = "Cultural Events Management",
                OrganizerDescription = "Dedicated to bringing diverse cultural experiences to our community.",
                OrganizerEmail = "hello@culturalevents.com",
                OrganizerPhone = "+1 (555) 456-7890",
                OrganizerWebsite = "www.culturalevents.com"
            }
        };

        var eventDetail = eventsData.FirstOrDefault(e => e.Id == id);

        if (eventDetail == null)
        {
            return NotFound(); // Or redirect to an error page
        }

        return View("Event-Detail", eventDetail);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
