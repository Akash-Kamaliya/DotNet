using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class DepartmentModel
    {
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
