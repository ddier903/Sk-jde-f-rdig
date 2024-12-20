using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace SkjødeSystem.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverUrl;

        // konstruktør til at initialisere tjenesten
        public TaskService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _serverUrl = configuration["ApiBaseUrl"]; // Get API base URL from configuration
        }
        // Henter alle opgaver fra API'en
        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetAllTasks");
        }
        // Henter alle opgaver, som er tilknyttet en apartments ID
        public async Task<List<TaskItem>> GetTasksByApartmentId(string apartmentId)
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetTaskByApartmentId/{apartmentId}");
        }
        // Henter alle opgaver for en specifik underentreprenør
        public async Task<List<TaskItem>> GetTasksBySubcontractor(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetTaskBySubcontractor/{userId}");
        }
        // henter alle opgaver der matcher bestemt status
        public async Task<List<TaskItem>> GetTasksByStatus(string status)
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetTasksByStatus/{status}");
        }
        // henter en enkelt opgave baseret på ID
        public async Task<TaskItem> GetTaskById(string taskId)
        {
            return await _httpClient.GetFromJsonAsync<TaskItem>($"{_serverUrl}/api/task/GetTasksById/{taskId}");
        }
        // Opretter en ny opgave
        public async Task<HttpResponseMessage> CreateTask(TaskItem task)
        {
            return await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/task/AddTask", task);
        }
        //opdaterer en eksisterende opgave baseret på ID
        public async Task<HttpResponseMessage> UpdateTask(string taskId, TaskItem task)
        {
            return await _httpClient.PutAsJsonAsync($"{_serverUrl}/api/task/UpdateTask/{taskId}", task);
        }
        // sletter en opgave baseret på ID
        public async Task DeleteTask(string taskId)
        {
            await _httpClient.DeleteAsync($"{_serverUrl}/api/task/DeleteTask/{taskId}");
        }
    }
}
