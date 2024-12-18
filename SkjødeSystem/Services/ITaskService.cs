using Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkjødeSystem.Services;

namespace SkjødeSystem.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasks();
        Task<List<TaskItem>> GetTasksByApartmentId(string apartmentId);
        Task<List<TaskItem>> GetTasksBySubcontractor(string userId);
        Task<List<TaskItem>> GetTasksByStatus(string status);
        Task<TaskItem> GetTaskById(string taskId);
        Task<HttpResponseMessage> CreateTask(TaskItem task);
        Task<HttpResponseMessage> UpdateTask(string taskId, TaskItem task);
        Task DeleteTask(string taskId);
    }
}
