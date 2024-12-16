using Blazored.LocalStorage;
using Core;
using Microsoft.AspNetCore.Components;
using SkjødeSystem.Services;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WebApp1.Service.Login;

namespace SkjødeSystem.Service
{

    
    public class LoginServiceClientSide : ILoginService
    {

        private readonly LoginServiceServerSide LoginServer;

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


        // Validerer Loginoplysninger
        public async Task<string> Login(string username, string password)
        {
            bool isValid = await Validate(username, password); 

            if (isValid)
            {
                // Hvis validiteten er sand, så modtager vi brugerdata fra serveren
                var user = await LoginServer.GetUserByUsernameAndPassword(username, password);

                // Gem brugeren i localStorage
                await localStorage.SetItemAsync("user", user);
                return user.Role; 
            }

            return null;
        }

            // Log ud
            public async Task Logout()
        {
            await localStorage.RemoveItemAsync("user");
        }

        protected virtual async Task<bool> Validate(string username, string password)
        {
            var isValid = await LoginServer.Validate(username, password);

            return isValid;
        }

    }
}
