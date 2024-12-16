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
        private readonly string _serverUrl = "https://localhost:7210"; 

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Tilføj Admin
        public async Task AddAdmin(Admin admin)
        {
            await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/user/AddAdmin", admin);
        }

        // Tilføj Subcontractor
        public async Task AddSubcontractor(Subcontractor subcontractor)
        {
            await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/user/AddSubcontractor", subcontractor);
        }

        // Tilføj Tenant
        public async Task AddTenant(Tenant tenant)
        {
            await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/user/AddTenant", tenant);
        }

        // Slet User
        public async Task DeleteUser(string userId)
        {
            await _httpClient.DeleteAsync($"{_serverUrl}/api/user/DeleteUser{userId}");
        }

        // Opdater User
        public async Task UpdateUser(string userId, User updatedUser)
        {
            await _httpClient.PutAsJsonAsync($"{_serverUrl}/api/user/UpdateUser{userId}", updatedUser);
        }

        // Get User på Username og Password
        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_serverUrl}/api/user/GetUserByUsernameAndPassword?username={username}&password={password}");
        }

        // Get User på UserId
        public async Task<User> GetUserById(string userId)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_serverUrl}/api/user/GetUserById{userId}");
        }

        // Get Alle Subcontractors
        public async Task<List<Subcontractor>> GetAllSubcontractors()
        {
            return await _httpClient.GetFromJsonAsync<List<Subcontractor>>($"{_serverUrl}/api/user/GetSubcontractors");
        }
    }
}
