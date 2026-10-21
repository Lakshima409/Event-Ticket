using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class Event : CommonProps
    {
        public Guid EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public Guid OrganizerId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid VenueId { get; set; }
        public EventStatus Status { get; set; }
        public string? EventBanner { get; set; } 

        // Navigation properties
        public virtual User Organizer { get; set; } = null!;
        public virtual EventCategory Category { get; set; } = null!;
        public virtual EventVenue Venue { get; set; } = null!;
        public virtual ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
    }
}
