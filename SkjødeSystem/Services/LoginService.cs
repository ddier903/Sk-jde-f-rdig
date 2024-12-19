using Blazored.LocalStorage;
using Core;
using System.Net.Http.Json;
using System.Text.Json;

namespace SkjødeSystem.Services
{
    public class LoginService : ILoginService
    {
        HttpClient http;
        private string _serverUrl = "https://localhost:7210";
        private ILocalStorageService localStorage { get; set; }

        public LoginService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<bool> ValidateLogin(string username, string password)
        {
            var response = await http.GetFromJsonAsync<JsonElement>($"{_serverUrl}/api/User/Authenticate?username={username}&password={password}");

            if (response.TryGetProperty("success", out var successProperty))
            {
                return successProperty.GetBoolean();
            }

            return false;
        }

        public async Task<User> GetUserLoggedIn(string username)
        {
            var user = await http.GetFromJsonAsync<User>($"{_serverUrl}/api/User/GetLoggedInUser?username={username}");
            return user;

        }

        // Logout method to clear stored user
        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("user");
        }


    }
}