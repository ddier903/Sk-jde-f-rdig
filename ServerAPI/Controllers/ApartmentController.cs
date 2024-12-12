using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core;
using MongoDB.Bson;

[ApiController]
[Route("api/[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly ApartmentRepository _repository;

    public ApartmentController()
    {
        _repository = new ApartmentRepository();
    }

    //Post apartment: 

    [HttpPost]
    [Route("AddApartment")]
    public async Task<IActionResult> PostApartment([FromBody]Apartment apartment)
    {
        if (apartment == null)
        {
            return BadRequest("Apartment object is null");
        }

        await _repository.PostApartment(apartment);
        return Ok("Apartment added successfully");
    }

    //Update apartment: 
    [HttpPut]
    [Route("UpdateApartment{id}")]
    public async Task<IActionResult> UpdateApartment(string id,[FromBody] Apartment updatedApartment)
    {
        if (updatedApartment == null)
        {
            return BadRequest("Updated apartment object is null");
        }

        await _repository.UpdateApartment(id, updatedApartment);
        return Ok("Apartment updated successfully");
    }

    //Get all Apartments:
    [HttpGet]
    [Route("GetAllApartments")]

    public async Task<IActionResult> GetAllApartments()
    {
        var apartments = await _repository.GetAllApartments();
        if (apartments == null || !apartments.Any())
        {
            return NotFound("No apartments found");
        }

        return Ok(apartments);
    }


    // Get all apartments filtered by status:
    [HttpGet]
    [Route("GetApartmentByStatus{status}")]
    public async Task<IActionResult> GetApartmentsByStatus(string status)
    {
        var apartments = await _repository.GetApartmentsByStatus(status);

        if (apartments == null || !apartments.Any())
        {
            return NotFound($"No apartments found with status '{status}'");
        }

        return Ok(apartments);
    }

    //Get Apartment:
    [HttpGet]
    [Route("GetApartmentById{id}")]
    public async Task<IActionResult> GetApartment(string id)
    {
        var apartment = await _repository.GetApartment(id);
        if (apartment == null)
        {
            return NotFound($"Apartment with ID {id} not found");
        }

        return Ok(apartment);
    }


    //Get Apartments "Ikke færdig" Count. 
    [HttpGet]
    [Route("GetApartmentsNotFinishedCount")]
    public async Task<IActionResult> GetApartmentsNotFinishedCount()
    {
        var count = await _repository.GetApartmentsNotFinishedCount();
        return Ok(new { Count = count });
    }



}