namespace MOM_Project.Models
{
    public class MeetingMemberModel
    {
        public int MeetingMemberID { get; set; }

        public int MeetingID { get; set; }

        public int StaffID { get; set; }

        public bool IsPresent { get; set; }

        public string? Remarks { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime CancellationDateTime { get; set; }

        public string? CancellationReason { get; set; }


    }
}
