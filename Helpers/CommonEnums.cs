namespace EventTicketingWebApp.Helpers
{
    // User roles in the system
    public enum UserRole
    {
        Customer = 1,
        Organizer = 2,
        Admin = 3
    }

    // Loyalty points transaction types
    public enum LoyaltyTransactionType
    {
        Earned = 1,
        Redeemed = 2
    }

    // Event status values
    public enum EventStatus
    {
        Draft = 1,
        Published = 2,
        Active = 3,
        Cancelled = 4,
        Completed = 5,
        SoldOut = 6
    }

    // Ticket status values
    public enum TicketStatus
    {
        Reserved = 1,
        Confirmed = 2,
        Cancelled = 3,
        Used = 4,
        Expired = 5
    }

    // Payment status values
    public enum PaymentStatus
    {
        Pending = 1,
        Processing = 2,
        Completed = 3,
        Failed = 4,
        Refunded = 5,
        Cancelled = 6
    }

    // Transaction status values
    public enum TransactionStatus
    {
        Pending = 1,
        Processing = 2,
        Completed = 3,
        Failed = 4,
        Declined = 5,
        Refunded = 6
    }

    // Payment method types
    public enum PaymentMethod
    {
        CreditCard = 1,
        DebitCard = 2,
        PayPal = 3,
        BankTransfer = 4,
        Cash = 5,
        DigitalWallet = 6
    }

    // Report types
    public enum ReportType
    {
        SalesReport = 1,
        EventReport = 2,
        UserReport = 3,
        FinancialReport = 4,
        AttendanceReport = 5,
        CustomReport = 6
    }

    // Booking status values
    public enum BookingStatus
    {
        Pending = 1,
        Confirmed = 2,
        Cancelled = 3,
        Completed = 4,
        Expired = 5
    }
}
