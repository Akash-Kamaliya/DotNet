using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class StaffModel
    {
        [Required]
        public int StaffID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string StaffName { get; set; }

        [Required]
        [MaxLength(20)]
        public string MobileNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [MaxLength(250)]
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }


    }
}
