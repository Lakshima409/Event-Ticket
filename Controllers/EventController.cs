using Microsoft.AspNetCore.Mvc;
using EventTicketingWebApp.Models;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        // GET: Event/Detail/{id}
        public IActionResult Detail(int id)
        {
            // Mock event data - in real app this would come from database
            var mockEvent = GetMockEvent(id);
            
            if (mockEvent == null)
            {
                return NotFound();
            }

            return View(mockEvent);
        }

        // GET: Event/Index
        public IActionResult Index()
        {
            // Mock events list - in real app this would come from database
            var mockEvents = GetMockEvents();
            return View(mockEvents);
        }

        private EventDetailViewModel GetMockEvent(int id)
        {
            // Mock event data based on ID
            var events = new Dictionary<int, EventDetailViewModel>
            {
                {
                    1, new EventDetailViewModel
                    {
                        Id = 1,
                        Title = "Rock Concert 2024",
                        Description = "Experience the ultimate rock concert featuring top artists from around the world. This electrifying event promises an unforgettable night of music, energy, and pure entertainment.",
                        ImageUrl = "https://images.unsplash.com/photo-1470229722913-7c0e2dbbafd3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                        Category = "Concert",
                        Date = DateTime.Now.AddDays(30),
                        Time = "8:00 PM",
                        Location = "New York, NY",
                        Venue = "Madison Square Garden",
                        NormalPrice = 75.00m,
                        VipPrice = 150.00m,
                        OrganizerName = "Music Events Pro",
                        OrganizerDescription = "Leading concert promoter with 15+ years of experience organizing major music events.",
                        OrganizerEmail = "info@musiceventspro.com",
                        OrganizerPhone = "+1 (555) 234-5678",
                        OrganizerWebsite = "www.musiceventspro.com"
                    }
                },
                {
                    2, new EventDetailViewModel
                    {
                        Id = 2,
                        Title = "Classical Symphony Night",
                        Description = "Immerse yourself in the beauty of classical music with our world-renowned symphony orchestra. A night of elegance, sophistication, and musical excellence.",
                        ImageUrl = "https://images.unsplash.com/photo-1493225457124-a3eb161ffa5f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                        Category = "Classical",
                        Date = DateTime.Now.AddDays(45),
                        Time = "7:30 PM",
                        Location = "New York, NY",
                        Venue = "Carnegie Hall",
                        NormalPrice = 95.00m,
                        VipPrice = 180.00m,
                        OrganizerName = "Theater Productions Inc.",
                        OrganizerDescription = "Professional theater company specializing in classical and contemporary performances.",
                        OrganizerEmail = "contact@theaterproductions.com",
                        OrganizerPhone = "+1 (555) 345-6789",
                        OrganizerWebsite = "www.theaterproductions.com"
                    }
                },
                {
                    3, new EventDetailViewModel
                    {
                        Id = 3,
                        Title = "Jazz Night Live",
                        Description = "Join us for an intimate evening of smooth jazz featuring talented musicians in a cozy, atmospheric setting. Perfect for jazz enthusiasts and music lovers.",
                        ImageUrl = "https://images.unsplash.com/photo-1415201364774-f6f0bb35f28f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                        Category = "Jazz",
                        Date = DateTime.Now.AddDays(20),
                        Time = "9:00 PM",
                        Location = "New York, NY",
                        Venue = "Blue Note Club",
                        NormalPrice = 45.00m,
                        VipPrice = 85.00m,
                        OrganizerName = "Cultural Events Management",
                        OrganizerDescription = "Dedicated to bringing diverse cultural experiences to our community.",
                        OrganizerEmail = "hello@culturalevents.com",
                        OrganizerPhone = "+1 (555) 456-7890",
                        OrganizerWebsite = "www.culturalevents.com"
                    }
                }
            };

            return events.ContainsKey(id) ? events[id] : null;
        }

        private List<EventDetailViewModel> GetMockEvents()
        {
            return new List<EventDetailViewModel>
            {
                GetMockEvent(1),
                GetMockEvent(2),
                GetMockEvent(3)
            }.Where(e => e != null).ToList();
        }
    }

    public class EventDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public decimal NormalPrice { get; set; }
        public decimal VipPrice { get; set; }
        public string OrganizerName { get; set; } = string.Empty;
        public string OrganizerDescription { get; set; } = string.Empty;
        public string OrganizerEmail { get; set; } = string.Empty;
        public string OrganizerPhone { get; set; } = string.Empty;
        public string OrganizerWebsite { get; set; } = string.Empty;
    }
}
