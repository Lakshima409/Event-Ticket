using EventTicketingWebApp.Helper;

namespace EventTicketingWebApp.Data.Entities
{
    public class DiscountUsage : CommonProps
    {
        public Guid UsageId { get; set; }
        public Guid DiscountId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookingId { get; set; }
        public DateTime UsageDate { get; set; }

        // Navigation properties
        public virtual PromotionalDiscount PromotionalDiscount { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual Booking Booking { get; set; } = null!;
    }
}
