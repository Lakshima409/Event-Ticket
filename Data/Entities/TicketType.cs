using EventTicketingWebApp.Helper;

namespace EventTicketingWebApp.Data.Entities
{
    public class TicketType : CommonProps
    {
        public Guid TicketTypeId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }

        // Navigation properties
        public virtual Event Event { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
