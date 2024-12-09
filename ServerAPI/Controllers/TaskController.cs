using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core;
using System.Reflection;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskRepository _repository;

    public TaskController()
    {
        _repository = new TaskRepository();
    }

    // Post Task:
    [HttpPost]
    [Route("AddTask")]
    public async Task<IActionResult> PostTask(TaskItem task)
    {

        await _repository.PostTask(task);
        return Ok("Task added successfully");

    }

    // Update Task: 
    [HttpPut]
    [Route("UpdateTask")]
    public async Task<IActionResult> UpdateTask(int taskId, TaskItem updatedtask)
    {

        await _repository.UpdateTask(taskId, updatedtask);
        return Ok("Task updated successfully");

    }

    // Delete Task: 
    [HttpDelete]
    [Route("DeleteTask")]
    public async Task<IActionResult> DeleteTask(int taskId)
    {

        await _repository.DeleteTask(taskId);
        return Ok("Task deleted successfully");

    }

    //Get Task by ApartmentID:
    [HttpGet]
    [Route("GetTaskByApartmentId")]
    public async Task<IEnumerable<TaskItem>> GetAllTasksByApartmentId(int apartmentId)
    {
        return await _repository.GetAllTaskByApartmentId(apartmentId);
    }


    //Get Task by ApartmentID, sorted by Status: 

    //Get Task by Subconctractor:
    [HttpGet]
    [Route("GetTaskBySubcontractor")]
    public async Task<IEnumerable<TaskItem>> GetAllTasksBySubcontractor(int userId)
    {
        return await _repository.GetAllTasksBySubcontractor(userId);
    }

    // Get all Tasks:
    [HttpGet]
    [Route("GetAllTasks")]
    public async Task<IEnumerable<TaskItem>> GetAllTasks() 
    {
        return await _repository.GetAllTasks();
    }

    // Get Task by Id: 
    [HttpGet]
    [Route("GetTasksById")]
    public async Task<TaskItem> GetTaskById(int taskId)
    {
        return await _repository.GetTaskById(taskId);
    }

    // Get Tasks filtered by status:
    [HttpGet]
    [Route("GetTasksByStatus")]
    public async Task<IEnumerable<TaskItem>> FilterTaskByStatus(string status)
    {
        return await _repository.FilterTaskByStatus(status);
    }
}