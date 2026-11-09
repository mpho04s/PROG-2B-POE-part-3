
using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.Models
{
    public class Result
    {
        public int ResultID { get; set; }

        [Required(ErrorMessage = "Please enter the enrolment ID.")]
        [Range(1, int.MaxValue)]
        public int EnrolmentID { get; set; }

        [Required(ErrorMessage = "Please enter the official time.")]
        public string OfficialTime { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int OverallPosition { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryPosition { get; set; }

        public string? PacePerKm { get; set; }
    }
}
