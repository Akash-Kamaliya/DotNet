using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingsModel
    {
        [Required]
        public int MeetingID { get; set; }

        [Required]
        public DateTime MeetingDate { get; set; }

        [Required]
        public int MeetingVenueID { get; set; }

        [Required]
        public int MeetingTypeID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [StringLength(250)]
        public string? MeetingDescription { get; set; }

        [StringLength(250)]
        public string? DocumentPath { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public bool? IsCancelled { get; set; }

        public DateTime? CancellationDateTime { get; set; }

        public string? CancellationReason { get; set; }

    }
}
