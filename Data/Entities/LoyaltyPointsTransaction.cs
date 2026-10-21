using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class LoyaltyPointsTransaction : CommonProps
    {
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public Guid? BookingId { get; set; }
        public LoyaltyTransactionType TransactionType { get; set; }
        public int Points { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Booking? Booking { get; set; }
    }
}
