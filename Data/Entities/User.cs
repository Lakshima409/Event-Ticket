using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class User : CommonProps
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public int LoyaltyPointsBalance { get; set; }
        public string? OrganizationName { get; set; }
        public string? OrganizationTelephone { get; set; }
        public string? OrganizationAddress { get; set; }
        public string? OrganizationDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginAt { get; set; }

        // Navigation properties
        public virtual ICollection<Event> OrganizedEvents { get; set; } = new List<Event>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<Report> GeneratedReports { get; set; } = new List<Report>();
        public virtual ICollection<DiscountUsage> DiscountUsages { get; set; } = new List<DiscountUsage>();
        public virtual ICollection<LoyaltyPointsTransaction> LoyaltyPointsTransactions { get; set; } = new List<LoyaltyPointsTransaction>();
    }
}
