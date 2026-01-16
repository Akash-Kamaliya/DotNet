using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingTypeModel
    {
        [Required]
        public int MeetingTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string MeetingTypeName { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
