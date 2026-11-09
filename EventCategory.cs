
using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.Models
{
    public class EventCategory
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter the event ID.")]
        [Range(1, int.MaxValue)]
        public int EventID { get; set; }

        [Required(ErrorMessage = "Please enter the category name.")]
        public string CategoryName { get; set; } = string.Empty;

        [Range(1, int.MaxValue,
            ErrorMessage = "Distance must be greater than zero.")]
        public int DistanceKm { get; set; }

        [Range(0, int.MaxValue,
            ErrorMessage = "Entry fee cannot be negative.")]
        public int EntryFee { get; set; }
    }
}

