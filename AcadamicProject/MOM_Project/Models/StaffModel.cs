namespace MOM_Project.Models
{
    public class StaffModel
    {
        public int StaffID { get; set; }

        public int DepartmentID { get; set; }

        public string StaffName { get; set; }

        public string MobileNo { get; set; }

        public string EmailAddress { get; set; }

        public string? Remarks { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }


    }
}
