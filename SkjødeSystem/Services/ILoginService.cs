using Core;

namespace SkjødeSystem.Services
{
    public interface ILoginService
    {
        Task<bool> ValidateLogin(string username, string password);
        Task<User> GetUserLoggedIn(string username);

        Task Logout();


    }
}
