using EventTicketingWebApp.Helper;

namespace EventTicketingWebApp.Data.Entities
{
    public class EventCategory : CommonProps
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation properties
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
