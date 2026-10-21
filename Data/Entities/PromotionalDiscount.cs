using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class PromotionalDiscount : CommonProps
    {
        public Guid DiscountId { get; set; }
        public string PromoCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int TotalUsageLimit { get; set; }
        public int PerUserLimit { get; set; }

        // Navigation properties
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<DiscountUsage> DiscountUsages { get; set; } = new List<DiscountUsage>();
    }
}
