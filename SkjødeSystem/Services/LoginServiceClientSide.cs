using Blazored.LocalStorage;
using Core;
using SkjødeSystem.Services;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SkjødeSystem.Service
{
    public class LoginServiceClientSide : ILoginService
    {
        private readonly ILocalStorageService localStorage;

        // Initialisere en liste af Users
        private readonly List<User> users = new();

        public LoginServiceClientSide(ILocalStorageService ls)
        {
            localStorage = ls;
        }

        //Henter den aktuelle bruger.
        public async Task<User?> GetUserLoggedIn()
        {
            var res = await localStorage.GetItemAsync<User>("user");
            return res;
        }


        // Validate user credentials
        public async Task<string> Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
            {
                await localStorage.SetItemAsync("user", user); // Store user in local storage
                return user.Role; // Return the user's role
            }
            return null;
        }

        // Logout method to clear stored user
        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("user");
        }

        //Henter alle brugere fra db
        public async Task GetAllUsers()
        {

        }

    }
}
