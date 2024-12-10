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
    [Route("UpdateTask")]
    public async Task<IActionResult> UpdateTask(int taskId, [FromBody] TaskItem updatedtask)
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
    public async Task<IActionResult> GetAllTasksByApartmentId(int apartmentId)
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
    [HttpGet]
    [Route("GetTaskBySubcontractor")]
    public async Task<IActionResult> GetAllTasksBySubcontractor(int userId)
    {
        var tasks = await _repository.GetAllTasksBySubcontractor(userId);
        if(tasks == null || !tasks.Any()) 
        {
            return NotFound($"No tasks found for subcontractor with ID:{userId}");
        }
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
    [HttpGet]
    [Route("GetTasksById")]
    public async Task<IActionResult> GetTaskById(int taskId)
    {
        var tasks = await _repository.GetTaskById(taskId);
        if (tasks == null)
        {
            return NotFound($"Tasks with ID {taskId} not found");
        }

        return Ok(tasks);
    }

    // Get Tasks filtered by status:
    [HttpGet]
    [Route("GetTasksByStatus")]
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