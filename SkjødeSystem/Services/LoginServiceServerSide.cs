using System.Data;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Core;
using SkjødeSystem.Service;

namespace WebApp1.Service.Login;

public class LoginServiceServerSide : LoginServiceClientSide
{
    private HttpClient http;

    private string serverUrl = "http://localhost:7210";
    public LoginServiceServerSide(ILocalStorageService ls, HttpClient http) : base(ls)
    {
        this.http = http;

    }

    protected override async Task<bool> Validate(string username, string password)
    {
        User user = new User() { UserName = username, Password = password };
        var res = await http.PostAsJsonAsync<User>($"{serverUrl}/api/user/authenti", user);
        var body = await res.Content.ReadAsStringAsync();
        return body.Equals("true");
    }

    public async Task<User> GetUserByUsernameAndPassword(string username, string password)
    {
        var res = await http.GetAsync($"{serverUrl}/api/user/GetUserByUsernameAndPassword?username={username}&password={password}");
        

        if (res.IsSuccessStatusCode)
        {
           
            var user = await res.Content.ReadFromJsonAsync<User>();
            return user;
        }

        
        return null;
    }

}
