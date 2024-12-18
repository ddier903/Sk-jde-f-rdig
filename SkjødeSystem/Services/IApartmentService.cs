using Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkjødeSystem.Services
{
    public interface IApartmentService
    {
        Task<List<Apartment>> GetAllApartments();
        Task<Apartment> GetApartmentById(string id);
        Task<List<Apartment>> GetApartmentsByStatus(string status);
        Task<Apartment> AddApartment(Apartment apartment);
        Task<Apartment> UpdateApartment(string id, Apartment updatedApartment);
        Task<long> GetApartmentsNotFinishedCount();
        Task<Apartment> GetApartmentByUserId(string userId);
        Task<bool> AssignTenantToApartment(string apartmentId, Tenant tenant);
        Task<bool> UpdateApartmentAvailability(string apartmentId, List<Availability> availabilities);
        Task<List<Availability>> GetAvailabilityByApartmentId(string apartmentId);
    }
}
