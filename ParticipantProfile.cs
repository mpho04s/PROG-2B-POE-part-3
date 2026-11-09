
using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.Models
{
    public class ParticipantProfile
    {
        public string ProfileID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the user ID.")]
        public string UserID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the emergency contact name.")]
        public string EmergencyContactName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the emergency contact phone number.")]
        public string EmergencyContactPhone { get; set; } = string.Empty;

        public string? ClubName { get; set; }

        public string? AsaLicenceNumber { get; set; }
    }
}

