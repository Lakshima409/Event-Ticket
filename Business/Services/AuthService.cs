using Microsoft.EntityFrameworkCore;
using EventTicketingWebApp.Business.Interfaces;
using EventTicketingWebApp.Data;
using EventTicketingWebApp.Data.Entities;
using EventTicketingWebApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace EventTicketingWebApp.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);

            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            // Update last login
            user.LastLoginAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> RegisterAsync(RegisterViewModel model)
        {
            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == model.Email || u.Username == model.Email))
                return null;

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = model.Email, // Using email as username
                Email = model.Email,
                PasswordHash = HashPassword(model.Password),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Role = model.Role,
                LoyaltyPointsBalance = 0,
                OrganizationName = model.OrganizationName,
                OrganizationTelephone = model.OrganizationTelephone,
                OrganizationAddress = model.OrganizationAddress,
                OrganizationDescription = model.OrganizationDescription,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
        }

        public async Task<bool> UpdateLastLoginAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.LastLoginAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "EventTicketingSalt"));
            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPassword(string password, string hash)
        {
            var hashedPassword = HashPassword(password);
            return hashedPassword == hash;
        }
    }
}
