using Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkjødeSystem.Services;

namespace ClientApp.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasks();
        Task<List<TaskItem>> GetTasksByApartmentId(string apartmentId);
        Task<List<TaskItem>> GetTasksBySubcontractor(string userId);
        Task<List<TaskItem>> GetTasksByStatus(string status);
        Task<TaskItem> GetTaskById(string taskId);
        Task CreateTask(TaskItem task);
        Task UpdateTask(string taskId, TaskItem task);
        Task DeleteTask(string taskId);
    }
}
