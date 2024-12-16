using Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkjødeSystem.Services
{
    public interface IApartmentService
    {
        Task<List<Apartment>> GetAllApartments();
    }
}
