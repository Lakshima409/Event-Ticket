using Microsoft.EntityFrameworkCore;
using EventTicketingWebApp.Data;
using EventTicketingWebApp.Business.Interfaces;
using EventTicketingWebApp.Business.Services;
using EventTicketingWebApp.Middleware;
using EventTicketingWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add custom authentication service
builder.Services.AddScoped<IAuthService, AuthService>();

// Add session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedAdminUser(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add session middleware
app.UseSession();

// Add custom authentication middleware
app.UseCustomAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Method to seed admin user
static async Task SeedAdminUser(IServiceProvider serviceProvider)
{
    var authService = serviceProvider.GetRequiredService<IAuthService>();
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

    // Create admin user if it doesn't exist
    var adminEmail = "admin@eventticketing.com";
    var adminUser = await authService.GetUserByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var adminModel = new RegisterViewModel
        {
            Email = adminEmail,
            Password = "Admin123!",
            ConfirmPassword = "Admin123!",
            FirstName = "System",
            LastName = "Administrator",
            Role = EventTicketingWebApp.Helpers.UserRole.Admin
        };

        await authService.RegisterAsync(adminModel);
    }
}
