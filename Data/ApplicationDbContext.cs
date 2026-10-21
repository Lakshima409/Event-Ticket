using Microsoft.EntityFrameworkCore;
using EventTicketingWebApp.Data.Entities;

namespace EventTicketingWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets for your domain entities
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<EventVenue> EventVenues { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<PromotionalDiscount> PromotionalDiscounts { get; set; }
    public DbSet<DiscountUsage> DiscountUsages { get; set; }
    public DbSet<LoyaltyPointsTransaction> LoyaltyPointsTransactions { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure User entity
        builder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.LoyaltyPointsBalance).HasDefaultValue(0);
            entity.Property(e => e.OrganizationName).HasMaxLength(200);
            entity.Property(e => e.OrganizationTelephone).HasMaxLength(20);
            entity.Property(e => e.OrganizationAddress).HasMaxLength(500);
            entity.Property(e => e.OrganizationDescription).HasMaxLength(1000);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Username).IsUnique();
        });

        // Configure primary keys for entities
        builder.Entity<Event>().HasKey(e => e.EventId);
        builder.Entity<EventCategory>().HasKey(e => e.CategoryId);
        builder.Entity<EventVenue>().HasKey(e => e.VenueId);
        builder.Entity<Ticket>().HasKey(e => e.TicketId);
        builder.Entity<TicketType>().HasKey(e => e.TicketTypeId);
        builder.Entity<Booking>().HasKey(e => e.BookingId);
        builder.Entity<Transaction>().HasKey(e => e.TransactionId);
        builder.Entity<PromotionalDiscount>().HasKey(e => e.DiscountId);
        builder.Entity<DiscountUsage>().HasKey(e => e.UsageId);
        builder.Entity<LoyaltyPointsTransaction>().HasKey(e => e.TransactionId);
        builder.Entity<Report>().HasKey(e => e.ReportId);

        // Configure relationships
        builder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany(u => u.OrganizedEvents)
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<DiscountUsage>()
            .HasOne(d => d.User)
            .WithMany(u => u.DiscountUsages)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<LoyaltyPointsTransaction>()
            .HasOne(l => l.User)
            .WithMany(u => u.LoyaltyPointsTransactions)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Report>()
            .HasOne(r => r.GeneratedByUser)
            .WithMany(u => u.GeneratedReports)
            .HasForeignKey(r => r.GeneratedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
