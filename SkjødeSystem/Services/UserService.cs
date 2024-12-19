using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Core;
using System.Collections.Generic;

namespace SkjødeSystem.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverUrl;

        public UserService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _serverUrl = configuration["ApiBaseUrl"]; // Get API base URL from configuration
        }

        public async Task AddAdmin(Admin admin)
        {
            await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/user/AddAdmin", admin);
        }

        public async Task AddSubcontractor(Subcontractor subcontractor)
        {
            await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/user/AddSubcontractor", subcontractor);
        }

        public async Task AddTenant(Tenant tenant)
        {
            await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/user/AddTenant", tenant);
        }

        public async Task DeleteUser(string userId)
        {
            await _httpClient.DeleteAsync($"{_serverUrl}/api/user/DeleteUser/{userId}");
        }

        public async Task UpdateUser(string userId, User updatedUser)
        {
            await _httpClient.PutAsJsonAsync($"{_serverUrl}/api/user/UpdateUser/{userId}", updatedUser);
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_serverUrl}/api/user/GetUserByUsernameAndPassword?username={username}&password={password}");
        }

        public async Task<User> GetUserById(string userId)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_serverUrl}/api/user/GetUserById/{userId}");
        }

        public async Task<List<Subcontractor>> GetAllSubcontractors()
        {
            return await _httpClient.GetFromJsonAsync<List<Subcontractor>>($"{_serverUrl}/api/user/GetSubcontractors");
        }
        public async Task<Subcontractor> GetSubcontractorById(string userId)
        {
            return await _httpClient.GetFromJsonAsync<Subcontractor>($"{_serverUrl}/api/user/GetSubcontractorById/{userId}");
        }
    }
}
