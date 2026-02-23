using System;
using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class StaffModel
    {
        public int StaffID { get; set; }

        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Staff name is required")]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public string StaffName { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter valid 10 digit number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; }

        [StringLength(250)]
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
