using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingTypeModel
    {
        public int MeetingTypeID { get; set; }

        [Required(ErrorMessage = "Meeting type name is required")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string MeetingTypeName { get; set; }

        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
