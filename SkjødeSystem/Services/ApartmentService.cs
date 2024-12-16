using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using SkjødeSystem.Services;

namespace ClientApp.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly HttpClient _httpClient;

        // Adresse på server, hvor din API er hostet
        private string serverUrl = "https://localhost:7227"; // 

        // Constructor for at injicere HttpClient
        public ApartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Hent alle lejligheder
        public async Task<List<Apartment>> GetAllApartments()
        {
            // Lav API-kaldet til GetAllApartments endpointet
            var apartments = await _httpClient.GetFromJsonAsync<List<Apartment>>($"{serverUrl}/api/apartment/GetAllApartments");

            return apartments;
        }
    }
}
