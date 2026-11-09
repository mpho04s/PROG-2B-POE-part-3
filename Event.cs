
using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [Required(ErrorMessage = "Please enter the organiser ID.")]
        [Range(1, int.MaxValue)]
        public int OrganiserID { get; set; }

        [Required(ErrorMessage = "Please enter the event name.")]
        public string EventName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the event description.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the event date in YYYYMMDD format.")]
        [Range(20000101, 20991231,
            ErrorMessage = "Enter a date as YYYYMMDD, for example 20261101.")]
        public int EventDate { get; set; }

        [Required(ErrorMessage = "Please enter the starting location.")]
        public string StartLocation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the city.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the province.")]
        public string Province { get; set; } = string.Empty;
    }
}
