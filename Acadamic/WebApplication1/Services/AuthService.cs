using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MOMPortal.Models;

namespace MOMPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string API_BASE_URL = "https://mom-webapi.onrender.com/api";

        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri(API_BASE_URL);
        }

        public async Task<LoginResponseDto> LoginAsync(string email, string password)
        {
            try
            {
                var endpoint = $"/Auth/login?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}";
                var response = await _httpClient.PostAsync(endpoint, null);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<JsonElement>(content).GetString();

                // If API returns plain token string or wrapped object
                if (string.IsNullOrEmpty(token))
                {
                    token = content.Trim('"');
                }

                // Store token in session
                _httpContextAccessor.HttpContext?.Session.SetString("token", token);

                // Decode JWT to extract user info
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value 
                    ?? jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value 
                    ?? email;

                var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value 
                    ?? jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

                var userSession = new UserSessionModel
                {
                    Email = emailClaim,
                    Role = roleClaim ?? "User"
                };

                _httpContextAccessor.HttpContext?.Session.SetString("user", JsonSerializer.Serialize(userSession));

                return new LoginResponseDto { Token = token, Email = emailClaim };
            }
            catch (Exception ex)
            {
                throw new Exception("Login failed", ex);
            }
        }

        public async Task LogoutAsync()
        {
            _httpContextAccessor.HttpContext?.Session.Remove("token");
            _httpContextAccessor.HttpContext?.Session.Remove("user");
            await Task.CompletedTask;
        }

        public UserSessionModel GetCurrentUser()
        {
            var userJson = _httpContextAccessor.HttpContext?.Session.GetString("user");
            if (string.IsNullOrEmpty(userJson))
                return null;

            return JsonSerializer.Deserialize<UserSessionModel>(userJson);
        }

        public bool HasRole(string[] roles)
        {
            var user = GetCurrentUser();
            if (user == null) return false;
            return roles.Contains(user.Role);
        }
    }
}