using EventTicketingWebApp.Business.Interfaces;
using EventTicketingWebApp.Data.Entities;
using System.Security.Claims;

namespace EventTicketingWebApp.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthService authService)
        {
            // Check for session-based authentication
            var userId = context.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(userId) && Guid.TryParse(userId, out var userGuid))
            {
                var user = await authService.GetUserByIdAsync(userGuid);
                if (user != null)
                {
                    // Create claims identity
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, "CustomAuth");
                    context.User = new ClaimsPrincipal(identity);
                }
            }

            await _next(context);
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
