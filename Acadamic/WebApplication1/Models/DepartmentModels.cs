namespace MOMPortal.Models
{
    public class DepartmentDto
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class CreateDepartmentViewModel
    {
        public string DepartmentName { get; set; }
    }
}