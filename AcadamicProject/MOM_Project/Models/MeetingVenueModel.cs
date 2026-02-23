using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingVenueModel
    {
        public int MeetingVenueID { get; set; }

        [Required(ErrorMessage = "Meeting venue name is required")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string MeetingVenueName { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
