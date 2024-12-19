using Blazored.LocalStorage;
using Core;
using System.Net.Http.Json;
using System.Text.Json;

namespace SkjødeSystem.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverUrl;
        private readonly ILocalStorageService _localStorage;

        public LoginService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _serverUrl = configuration["ApiBaseUrl"]; 
            _localStorage = localStorage;
        }

        public async Task<bool> ValidateLogin(string username, string password)
        {
            var response = await _httpClient.GetFromJsonAsync<JsonElement>($"{_serverUrl}/api/User/Authenticate?username={username}&password={password}");

            if (response.TryGetProperty("success", out var successProperty))
            {
                return successProperty.GetBoolean();
            }

            return false;
        }

        public async Task<User> GetUserLoggedIn(string username)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_serverUrl}/api/User/GetLoggedInUser?username={username}");
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("user");
        }
    }
}
