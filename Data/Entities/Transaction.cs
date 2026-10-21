using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class Transaction : CommonProps
    {
        public Guid TransactionId { get; set; }
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? GatewayTransactionId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public TransactionStatus Status { get; set; }
        public string? ResponseCode { get; set; }

        // Navigation properties
        public virtual Booking Booking { get; set; } = null!;
    }
}
