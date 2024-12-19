using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using SkjødeSystem.Services;

namespace SkjødeSystem.Services
{
public class ApartmentService : IApartmentService
{
        private readonly HttpClient _httpClient;
        private readonly string _serverUrl;

        public ApartmentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _serverUrl = configuration["ApiBaseUrl"]; // Get the API base URL from configuration
        }

        // Hent alle lejligheder
        public async Task<List<Apartment>> GetAllApartments()
    {
        var apartments = await _httpClient.GetFromJsonAsync<List<Apartment>>($"{_serverUrl}/api/apartment/GetAllApartments");
        return apartments;
    }

    // Hent lejlighed ved ID
    public async Task<Apartment> GetApartmentById(string id)
    {
        var apartment = await _httpClient.GetFromJsonAsync<Apartment>($"{_serverUrl}/api/apartment/GetApartmentById/{id}");
        return apartment;
    }

    // Hent lejligheder filtreret efter status
    public async Task<List<Apartment>> GetApartmentsByStatus(string status)
    {
        var apartments = await _httpClient.GetFromJsonAsync<List<Apartment>>($"{_serverUrl}/api/apartment/GetApartmentByStatus/{status}");
        return apartments;
    }

    // Opret en ny lejlighed
    public async Task<Apartment> AddApartment(Apartment apartment)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/apartment/AddApartment", apartment);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Apartment>();
    }

    // Opdater en lejlighed
    public async Task<Apartment> UpdateApartment(string id, Apartment updatedApartment)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_serverUrl}/api/apartment/UpdateApartment/{id}", updatedApartment);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Apartment>();
    }

    // Hent antal "ikke færdig" lejligheder
    public async Task<long> GetApartmentsNotFinishedCount()
    {
        var response = await _httpClient.GetFromJsonAsync<long>($"{_serverUrl}/api/apartment/GetApartmentsNotFinishedCount");
        return response;
    }

    // Hent lejlighed baseret på userId
    public async Task<Apartment> GetApartmentByUserId(string userId)
    {
        var apartment = await _httpClient.GetFromJsonAsync<Apartment>($"{_serverUrl}/api/apartment/user/{userId}");
        return apartment;
    }

    // Tildel en lejer til en lejlighed
    public async Task<bool> AssignTenantToApartment(string apartmentId, Tenant tenant)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_serverUrl}/api/apartment/assign-tenant/{apartmentId}", tenant);
        return response.IsSuccessStatusCode;
    }

    // Opdater tilgængelighed for en lejlighed
    public async Task<bool> UpdateApartmentAvailability(string apartmentId, List<Availability> availabilities)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_serverUrl}/api/apartment/UpdateAvailability/{apartmentId}", availabilities);
        return response.IsSuccessStatusCode;
    }

    // Hent tilgængeligheder for en lejlighed
    public async Task<List<Availability>> GetAvailabilityByApartmentId(string apartmentId)
    {
        var availabilities = await _httpClient.GetFromJsonAsync<List<Availability>>($"{_serverUrl}/api/apartment/GetAvailability/{apartmentId}");
        return availabilities;
    }
}
}
