using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class DepartmentModel
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100, ErrorMessage = "Max 100 characters allowed")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime Modified { get; set; }
    }
}
