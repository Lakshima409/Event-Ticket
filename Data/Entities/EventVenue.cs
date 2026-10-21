using EventTicketingWebApp.Helper;

namespace EventTicketingWebApp.Data.Entities
{
    public class EventVenue : CommonProps
    {
        public Guid VenueId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? ContactInfo { get; set; }
        public string? MapUrl { get; set; }

        // Navigation properties
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
