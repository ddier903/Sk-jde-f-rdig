using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace SkjødeSystem.Services
{
    public interface IUserService
    {
        // Tilføj Admin
        Task AddAdmin(Admin admin);

        // Tilføj Subcontractor
        Task AddSubcontractor(Subcontractor subcontractor);

        // Tilføj Tenant
        Task AddTenant(Tenant tenant);

        // Slet User
        Task DeleteUser(string userId);

        // Opdater User
        Task UpdateUser(string userId, User updatedUser);

        // Get User på Username og Password
        Task<User> GetUserByUsernameAndPassword(string username, string password);

        // Get User på UserId
        Task<User> GetUserById(string userId);

        // Get Alle Subcontractors
        Task<List<Subcontractor>> GetAllSubcontractors();
    }
}

