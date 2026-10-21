using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class Booking : CommonProps
    {
        public Guid BookingId { get; set; }
        public Guid UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public int LoyaltyPointsUsed { get; set; }
        public int LoyaltyPointsDiscount { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public BookingStatus Status { get; set; }
        public Guid? DiscountId { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual PromotionalDiscount? PromotionalDiscount { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<DiscountUsage> DiscountUsages { get; set; } = new List<DiscountUsage>();
        public virtual ICollection<LoyaltyPointsTransaction> LoyaltyPointsTransactions { get; set; } = new List<LoyaltyPointsTransaction>();
    }
}
