namespace MOM_Project.Models
{
    public class MeetingsModel
    {
        public int MeetingID { get; set; }

        public DateTime MeetingDate { get; set; }

        public int MeetingVenueID { get; set; }

        public int MeetingTypeID { get; set; }

        public int DepartmentID { get; set; }

        public string? MeetingDescription { get; set; }

        public string? DocumentPath { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public bool? IsCancelled { get; set; }

        public DateTime? CancellationDateTime { get; set; }

        public string? CancellationReason { get; set; }

    }
}
