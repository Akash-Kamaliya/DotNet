using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingMemberModel
    {
        [Required]
        public int MeetingMemberID { get; set; }
        
        [Required]
        public int MeetingID { get; set; }
        
        [Required]
        public int StaffID { get; set; }

        [Required]
        public bool IsPresent { get; set; }

        [StringLength(250)]
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
