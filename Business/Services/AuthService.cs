using System;
using System.Text;
using System.Security.Cryptography;

namespace EventTicketingWebApp.Business.Services
{
    public class AuthService : IAuthService
    {
        public string HashPassword(string password)
        {
            // Use PBKDF2 with HMAC-SHA256 (modern password-hashing algorithm)
            // OWASP recommends at least 600,000 iterations for PBKDF2-HMAC-SHA256
            // .NET default is 10,000; we use 600,000 for acceptable security
            // Consider increasing further if performance testing shows it's acceptable
            var salt = "EventTicketingSalt";
            using var bytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 600000, HashAlgorithmName.SHA256);
            var hashedBytes = bytes.GetBytes(256 / 8);
            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hashedPassword;
        }
    }
}