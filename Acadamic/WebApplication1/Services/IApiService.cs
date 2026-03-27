using MOMPortal.Models;

namespace MOMPortal.Services
{
    public interface IApiService
    {
        // Meetings
        Task<List<MeetingDto>> GetMeetingsAsync();
        Task<MeetingDto> GetMeetingByIdAsync(int id);
        Task<MeetingDto> CreateMeetingAsync(CreateMeetingViewModel model);
        Task<MeetingDto> UpdateMeetingAsync(int id, CreateMeetingViewModel model);
        Task<bool> DeleteMeetingAsync(int id);

        // Staff
        Task<List<StaffDto>> GetStaffAsync();
        Task<StaffDto> GetStaffByIdAsync(int id);
        Task<StaffDto> CreateStaffAsync(CreateStaffViewModel model);
        Task<StaffDto> UpdateStaffAsync(int id, CreateStaffViewModel model);
        Task<bool> DeleteStaffAsync(int id);

        // Roles
        Task<List<RoleDto>> GetRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(int id);
        Task<RoleDto> CreateRoleAsync(CreateRoleViewModel model);
        Task<RoleDto> UpdateRoleAsync(int id, CreateRoleViewModel model);
        Task<bool> DeleteRoleAsync(int id);

        // Departments
        Task<List<DepartmentDto>> GetDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentByIdAsync(int id);
        Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentViewModel model);
        Task<DepartmentDto> UpdateDepartmentAsync(int id, CreateDepartmentViewModel model);
        Task<bool> DeleteDepartmentAsync(int id);

        // Venues
        Task<List<VenueDto>> GetVenuesAsync();
        Task<VenueDto> GetVenueByIdAsync(int id);
        Task<VenueDto> CreateVenueAsync(CreateVenueViewModel model);
        Task<VenueDto> UpdateVenueAsync(int id, CreateVenueViewModel model);
        Task<bool> DeleteVenueAsync(int id);

        // Meeting Types
        Task<List<MeetingTypeDto>> GetMeetingTypesAsync();
        Task<MeetingTypeDto> GetMeetingTypeByIdAsync(int id);
        Task<MeetingTypeDto> CreateMeetingTypeAsync(CreateMeetingTypeViewModel model);
        Task<MeetingTypeDto> UpdateMeetingTypeAsync(int id, CreateMeetingTypeViewModel model);
        Task<bool> DeleteMeetingTypeAsync(int id);
    }
}