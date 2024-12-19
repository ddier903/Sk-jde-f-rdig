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

        public TaskService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _serverUrl = configuration["ApiBaseUrl"]; // Get API base URL from configuration
        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetAllTasks");
        }

        public async Task<List<TaskItem>> GetTasksByApartmentId(string apartmentId)
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetTaskByApartmentId/{apartmentId}");
        }

        public async Task<List<TaskItem>> GetTasksBySubcontractor(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetTaskBySubcontractor/{userId}");
        }

        public async Task<List<TaskItem>> GetTasksByStatus(string status)
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{_serverUrl}/api/task/GetTasksByStatus/{status}");
        }

        public async Task<TaskItem> GetTaskById(string taskId)
        {
            return await _httpClient.GetFromJsonAsync<TaskItem>($"{_serverUrl}/api/task/GetTasksById/{taskId}");
        }

        public async Task<HttpResponseMessage> CreateTask(TaskItem task)
        {
            return await _httpClient.PostAsJsonAsync($"{_serverUrl}/api/task/AddTask", task);
        }

        public async Task<HttpResponseMessage> UpdateTask(string taskId, TaskItem task)
        {
            return await _httpClient.PutAsJsonAsync($"{_serverUrl}/api/task/UpdateTask/{taskId}", task);
        }

        public async Task DeleteTask(string taskId)
        {
            await _httpClient.DeleteAsync($"{_serverUrl}/api/task/DeleteTask/{taskId}");
        }
    }
}
