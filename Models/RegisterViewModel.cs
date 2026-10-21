using System.ComponentModel.DataAnnotations;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public UserRole Role { get; set; }

        // Organization fields (only required for Organizer role)
        [Display(Name = "Organization Name")]
        public string? OrganizationName { get; set; }

        [Display(Name = "Organization Telephone")]
        public string? OrganizationTelephone { get; set; }

        [Display(Name = "Organization Address")]
        public string? OrganizationAddress { get; set; }

        [Display(Name = "Organization Description")]
        public string? OrganizationDescription { get; set; }
    }
}
