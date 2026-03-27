using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MOMPortal.Models;

namespace MOMPortal.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string API_BASE_URL = "https://mom-webapi.onrender.com/api";

        public ApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri(API_BASE_URL);
        }

        private void AddAuthorizationHeader()
        {
            var token = _httpContextAccessor.HttpContext?.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        private async Task<T> PostAsync<T>(string endpoint, object data)
        {
            AddAuthorizationHeader();
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent);
        }

        private async Task<T> PutAsync<T>(string endpoint, object data)
        {
            AddAuthorizationHeader();
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent);
        }

        private async Task<bool> DeleteAsync(string endpoint)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }

        // Meetings
        public async Task<List<MeetingDto>> GetMeetingsAsync()
        {
            return await GetAsync<List<MeetingDto>>("/Meetings/GetAll");
        }

        public async Task<MeetingDto> GetMeetingByIdAsync(int id)
        {
            return await GetAsync<MeetingDto>($"/Meetings/GetById/{id}");
        }

        public async Task<MeetingDto> CreateMeetingAsync(CreateMeetingViewModel model)
        {
            var dto = new { model.MeetingTitle, model.MeetingNumber, model.MeetingDescription, model.MeetingDate, model.MeetingVenueID, model.MeetingTypeID, model.DepartmentID };
            return await PostAsync<MeetingDto>("/Meetings/Create", dto);
        }

        public async Task<MeetingDto> UpdateMeetingAsync(int id, CreateMeetingViewModel model)
        {
            var dto = new { model.MeetingTitle, model.MeetingNumber, model.MeetingDescription, model.MeetingDate, model.MeetingVenueID, model.MeetingTypeID, model.DepartmentID };
            return await PutAsync<MeetingDto>($"/Meetings/Update/{id}", dto);
        }

        public async Task<bool> DeleteMeetingAsync(int id)
        {
            return await DeleteAsync($"/Meetings/Delete/{id}");
        }

        // Staff
        public async Task<List<StaffDto>> GetStaffAsync()
        {
            return await GetAsync<List<StaffDto>>("/MOM_Staff/GetAll");
        }

        public async Task<StaffDto> GetStaffByIdAsync(int id)
        {
            return await GetAsync<StaffDto>($"/MOM_Staff/GetById/{id}");
        }

        public async Task<StaffDto> CreateStaffAsync(CreateStaffViewModel model)
        {
            return await PostAsync<StaffDto>("/MOM_Staff/Create", model);
        }

        public async Task<StaffDto> UpdateStaffAsync(int id, CreateStaffViewModel model)
        {
            return await PutAsync<StaffDto>($"/MOM_Staff/Update/{id}", model);
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            return await DeleteAsync($"/MOM_Staff/Delete/{id}");
        }

        // Roles
        public async Task<List<RoleDto>> GetRolesAsync()
        {
            return await GetAsync<List<RoleDto>>("/MOM_Role/GetAll");
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            return await GetAsync<RoleDto>($"/MOM_Role/GetById/{id}");
        }

        public async Task<RoleDto> CreateRoleAsync(CreateRoleViewModel model)
        {
            return await PostAsync<RoleDto>("/MOM_Role/Create", model);
        }

        public async Task<RoleDto> UpdateRoleAsync(int id, CreateRoleViewModel model)
        {
            return await PutAsync<RoleDto>($"/MOM_Role/Update/{id}", model);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await DeleteAsync($"/MOM_Role/Delete/{id}");
        }

        // Departments
        public async Task<List<DepartmentDto>> GetDepartmentsAsync()
        {
            return await GetAsync<List<DepartmentDto>>("/Department/GetAll");
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            return await GetAsync<DepartmentDto>($"/Department/GetById/{id}");
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentViewModel model)
        {
            return await PostAsync<DepartmentDto>("/Department/Create", model);
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(int id, CreateDepartmentViewModel model)
        {
            return await PutAsync<DepartmentDto>($"/Department/Update/{id}", model);
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            return await DeleteAsync($"/Department/Delete/{id}");
        }

        // Venues
        public async Task<List<VenueDto>> GetVenuesAsync()
        {
            return await GetAsync<List<VenueDto>>("/MOM_Venue/GetAll");
        }

        public async Task<VenueDto> GetVenueByIdAsync(int id)
        {
            return await GetAsync<VenueDto>($"/MOM_Venue/GetById/{id}");
        }

        public async Task<VenueDto> CreateVenueAsync(CreateVenueViewModel model)
        {
            return await PostAsync<VenueDto>("/MOM_Venue/Create", model);
        }

        public async Task<VenueDto> UpdateVenueAsync(int id, CreateVenueViewModel model)
        {
            return await PutAsync<VenueDto>($"/MOM_Venue/Update/{id}", model);
        }

        public async Task<bool> DeleteVenueAsync(int id)
        {
            return await DeleteAsync($"/MOM_Venue/Delete/{id}");
        }

        // Meeting Types
        public async Task<List<MeetingTypeDto>> GetMeetingTypesAsync()
        {
            return await GetAsync<List<MeetingTypeDto>>("/MOM_MeetingType/GetAll");
        }

        public async Task<MeetingTypeDto> GetMeetingTypeByIdAsync(int id)
        {
            return await GetAsync<MeetingTypeDto>($"/MOM_MeetingType/GetById/{id}");
        }

        public async Task<MeetingTypeDto> CreateMeetingTypeAsync(CreateMeetingTypeViewModel model)
        {
            return await PostAsync<MeetingTypeDto>("/MOM_MeetingType/Create", model);
        }

        public async Task<MeetingTypeDto> UpdateMeetingTypeAsync(int id, CreateMeetingTypeViewModel model)
        {
            return await PutAsync<MeetingTypeDto>($"/MOM_MeetingType/Update/{id}", model);
        }

        public async Task<bool> DeleteMeetingTypeAsync(int id)
        {
            return await DeleteAsync($"/MOM_MeetingType/Delete/{id}");
        }
    }
}