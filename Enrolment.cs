
using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.Models
{
    public class Enrolment
    {
        public int EnrolmentID { get; set; }

        [Required(ErrorMessage = "Please enter the category ID.")]
        [Range(1, int.MaxValue)]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter the participant ID.")]
        [Range(1, int.MaxValue)]
        public int ParticipantID { get; set; }

        [Required(ErrorMessage = "Please enter the race number.")]
        [Range(1, int.MaxValue)]
        public int RaceNumber { get; set; }

        [Required(ErrorMessage = "Please enter the enrolment date in YYYYMMDD format.")]
        [Range(20000101, 20991231)]
        public int EnrolmentDate { get; set; }

        [Required(ErrorMessage = "Please enter the enrolment status.")]
        public string Status { get; set; } = string.Empty;

        public string? Pending { get; set; }
    }
}

