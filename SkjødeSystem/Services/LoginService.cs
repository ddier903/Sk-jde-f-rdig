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

        // konstruktør til at initialisere tjenesten
        public LoginService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _serverUrl = configuration["ApiBaseUrl"]; 
            _localStorage = localStorage;
        }
        // metode til at validere login
        public async Task<bool> ValidateLogin(string username, string password)
        {
            var response = await _httpClient.GetFromJsonAsync<JsonElement>($"{_serverUrl}/api/User/Authenticate?username={username}&password={password}");

            if (response.TryGetProperty("success", out var successProperty))
            {
                return successProperty.GetBoolean();
            }

            return false;
        }
        // metode til at hente oplysning om brugeren som er logget ind
        public async Task<User> GetUserLoggedIn(string username)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_serverUrl}/api/User/GetLoggedInUser?username={username}");
        }
        //metode til at logge ud
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("user");
        }
    }
}
