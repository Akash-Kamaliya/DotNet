namespace MOMPortal.Models
{
    public class StaffDto
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
    }

    public class CreateStaffViewModel
    {
        public string StaffName { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int DepartmentID { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
    }

    public class StaffListViewModel
    {
        public List<StaffDto> Staff { get; set; }
        public List<RoleDto> Roles { get; set; }
        public List<DepartmentDto> Departments { get; set; }
    }
}