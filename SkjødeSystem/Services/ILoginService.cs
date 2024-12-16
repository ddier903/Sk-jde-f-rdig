using Core;

namespace SkjødeSystem.Services
{
    public interface ILoginService
    {
        Task<string> Login(string username, string password);

        Task Logout();

    }

}
