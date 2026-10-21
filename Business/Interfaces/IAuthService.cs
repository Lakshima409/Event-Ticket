using EventTicketingWebApp.Data.Entities;
using EventTicketingWebApp.Models;

namespace EventTicketingWebApp.Business.Interfaces
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string email, string password);
        Task<User?> RegisterAsync(RegisterViewModel model);
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> UpdateLastLoginAsync(Guid userId);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}
