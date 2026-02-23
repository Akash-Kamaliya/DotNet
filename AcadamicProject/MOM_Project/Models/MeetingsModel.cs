using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingsModel
    {
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Meeting date & time is required")]
        public DateTime MeetingDate { get; set; }

        [Required(ErrorMessage = "Meeting type name is required")]
        [StringLength(100)]
        public string MeetingTypeName { get; set; }

        [Required(ErrorMessage = "Venue name is required")]
        [StringLength(100)]
        public string VenueName { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(250, ErrorMessage = "Max 250 characters")]
        public string? MeetingDescription { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
