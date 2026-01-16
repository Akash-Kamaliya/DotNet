using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingVenueModel
    {
        [Required]
        public int MeetingVenueID { get; set; }

        [Required]
        [StringLength(100)]
        public string MeetingVenueName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
