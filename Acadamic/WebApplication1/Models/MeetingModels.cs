namespace MOMPortal.Models
{
    public class MeetingDto
    {
        public int MeetingID { get; set; }
        public string MeetingTitle { get; set; }
        public string MeetingNumber { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime MeetingDate { get; set; }
        public int MeetingVenueID { get; set; }
        public string MeetingVenueName { get; set; }
        public int MeetingTypeID { get; set; }
        public string MeetingTypeName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class CreateMeetingViewModel
    {
        public string MeetingTitle { get; set; }
        public string MeetingNumber { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime MeetingDate { get; set; }
        public int MeetingVenueID { get; set; }
        public int MeetingTypeID { get; set; }
        public int DepartmentID { get; set; }
        public IFormFile DocumentFile { get; set; }
    }

    public class MeetingListViewModel
    {
        public List<MeetingDto> Meetings { get; set; }
        public List<VenueDto> Venues { get; set; }
        public List<MeetingTypeDto> MeetingTypes { get; set; }
        public List<DepartmentDto> Departments { get; set; }
    }
}