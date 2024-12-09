using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core;

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

    // Update Task: 

    // Delete Task: 

    //Get Task by ApartmentID:

    //Get Task by ApartmentID, sorted by Status: 

    //Get Task by Subconctractor:

    // Get all Tasks:

    // Get Task: 

    // Get Task by status:
}