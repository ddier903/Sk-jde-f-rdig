using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using SkjødeSystem.Services;

namespace SkjødeSystem.Services
{


    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;

        // Adresse på server, hvor API er hostet
        private string serverUrl = "https://localhost:7210"; 

        // Constructor for at injicere HttpClient
        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Hent alle opgaver
        public async Task<List<TaskItem>> GetAllTasks()
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{serverUrl}/api/task/GetAllTasks");
            return tasks;
        }

        // Hent opgaver for en bestemt lejlighed
        public async Task<List<TaskItem>> GetTasksByApartmentId(string apartmentId)
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{serverUrl}/api/task/GetTaskByApartmentId{apartmentId}");
            return tasks;
        }

        // Hent opgaver for en underentreprenør
        public async Task<List<TaskItem>> GetTasksBySubcontractor(string userId)
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{serverUrl}/api/task/GetTaskBySubcontractor{userId}");
            return tasks;
        }

        // Hent opgave baseret på status
        public async Task<List<TaskItem>> GetTasksByStatus(string status)
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<TaskItem>>($"{serverUrl}/api/task/GetTasksByStatus{status}");
            return tasks;
        }

        // Hent en opgave baseret på TaskId
        public async Task<TaskItem> GetTaskById(string taskId)
        {
            var task = await _httpClient.GetFromJsonAsync<TaskItem>($"{serverUrl}/api/task/GetTasksById{taskId}");
            return task;
        }

        // Opret en ny opgave
        public async Task<HttpResponseMessage> CreateTask(TaskItem task)
        {
           return await _httpClient.PostAsJsonAsync($"{serverUrl}/api/task/AddTask", task);
        }

        // Opdater en eksisterende opgave
        public async Task UpdateTask(string taskId, TaskItem task)
        {
            await _httpClient.PutAsJsonAsync($"{serverUrl}/api/task/UpdateTask{taskId}", task);
        }

        // Slet en opgave
        public async Task DeleteTask(string taskId)
        {
            await _httpClient.DeleteAsync($"{serverUrl}/api/task/DeleteTask{taskId}");
        }
    }
}
