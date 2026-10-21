using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class Ticket : CommonProps
    {
        public Guid TicketId { get; set; }
        public Guid TicketTypeId { get; set; }
        public Guid BookingId { get; set; }
        public string TicketNumber { get; set; } = string.Empty;
        public string? QrCode { get; set; }
        public TicketStatus Status { get; set; }

        // Navigation properties
        public virtual TicketType TicketType { get; set; } = null!;
        public virtual Booking Booking { get; set; } = null!;
    }
}
