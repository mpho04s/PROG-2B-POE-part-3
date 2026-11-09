using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.Models
{
    public class Users
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter your full name.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your password.")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a role.")]
        public string Role { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;
    }
}

