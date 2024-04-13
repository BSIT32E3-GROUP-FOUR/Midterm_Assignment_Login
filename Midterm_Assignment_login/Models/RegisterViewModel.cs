using System.ComponentModel.DataAnnotations;

namespace Midterm_Assignment_login.Models
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username must not contain spaces or special characters.")]
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters long.")]
        public string? Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
