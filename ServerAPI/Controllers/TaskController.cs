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
    public async Task<IActionResult> PostTask([FromBody] TaskItem task)
    {

        await _repository.PostTask(task);

        if (task == null)
        {
            return BadRequest("Task object is null");
        }

        return Ok("Task added successfully");

    }

    // Update Task: 
    [HttpPut]
    [Route("UpdateTask{taskId}")]
    public async Task<IActionResult> UpdateTask(string taskId, [FromBody] TaskItem updatedtask)
    {

        await _repository.UpdateTask(taskId, updatedtask);
        return Ok("Task updated successfully");

    }

    // Delete Task: 
    [HttpDelete]
    [Route("DeleteTask{taskId}")]
    public async Task<IActionResult> DeleteTask(string taskId)
    {

        await _repository.DeleteTask(taskId);
        return Ok("Task deleted successfully");

    }

    //Get Task by ApartmentID:
    [HttpGet]
    [Route("GetTaskByApartmentId{apartmentId}")]
    public async Task<IActionResult> GetAllTasksByApartmentId(string apartmentId)
    {
        var tasks = await _repository.GetAllTaskByApartmentId(apartmentId);
        if (tasks == null || !tasks.Any())
        {
            return NotFound($"No tasks found with id: {apartmentId}");
        }

        return Ok(tasks);

    }


    //Get Task by ApartmentID, sorted by Status: 


    //Get Task by Subconctractor:
    [HttpGet("GetTaskBySubcontractor/{userId}")]
    public async Task<IActionResult> GetAllTasksBySubcontractor(string userId)
    {
        Console.WriteLine($"Fetching tasks for subcontractor with ID: {userId}");

        var tasks = await _repository.GetAllTasksBySubcontractor(userId);
        if (tasks == null || !tasks.Any())
        {
            Console.WriteLine($"No tasks found for subcontractor with ID: {userId}");
            return NotFound($"No tasks found for subcontractor with ID: {userId}");
        }

        Console.WriteLine($"Tasks found: {tasks.Count}");
        return Ok(tasks);
    }


// Get all Tasks:
[HttpGet]
    [Route("GetAllTasks")]
    public async Task<IActionResult> GetAllTasks() 
    {
        var tasks = await _repository.GetAllTasks();
        if (tasks == null || !tasks.Any())
        {
            return NotFound("No tasks found");
        }

        return Ok(tasks);
    }

    // Get Task by Id: 
    [HttpGet("GetTasksById/{taskId}")]
    public async Task<IActionResult> GetTasksById(string taskId)
    {
        Console.WriteLine($"Request received for GetTasksById with ID: {taskId}");

        var task = await _repository.GetTaskById(taskId);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {taskId} not found");
            return NotFound($"Task with ID {taskId} not found");
        }

        Console.WriteLine($"Task found: {task.TaskName}");
        return Ok(task);
    }

    // Get Tasks filtered by status:
    [HttpGet]
    [Route("GetTasksByStatus{status}")]
    public async Task<IActionResult> FilterTaskByStatus(string status)
    {
        var tasks = await _repository.FilterTaskByStatus(status);

        if (tasks == null || !tasks.Any())
        {
            return NotFound($"No tasks found with status '{status}'");
        }

        return Ok(tasks);
    }
}