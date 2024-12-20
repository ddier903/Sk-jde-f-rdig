using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core;
using MongoDB.Bson;


// Kontrollere API-kald til lejlighedsrelateret ting
[ApiController]
[Route("api/[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly ApartmentRepository _repository;

    public ApartmentController()
    {
        _repository = new ApartmentRepository();
    }

    //Post Lejlighed

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

    //Opdatere lejlighed
    [HttpPut]
    [Route("UpdateApartment/{id}")]
    public async Task<IActionResult> UpdateApartment(string id,[FromBody] Apartment updatedApartment)
    {
        if (updatedApartment == null)
        {
            return BadRequest("Updated apartment object is null");
        }

        await _repository.UpdateApartment(id, updatedApartment);
        return Ok("Apartment updated successfully");
    }

    //Henter alle apartments
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


    // Henter alle lejligheder baseret på status
    [HttpGet]
    [Route("GetApartmentByStatus/{status}")]
    public async Task<IActionResult> GetApartmentsByStatus(string status)
    {
        var apartments = await _repository.GetApartmentsByStatus(status);

        if (apartments == null || !apartments.Any())
        {
            return NotFound($"No apartments found with status '{status}'");
        }

        return Ok(apartments);
    }

    // Henter en specifik lejlighed
    [HttpGet]
    [Route("GetApartmentById/{id}")]
    public async Task<IActionResult> GetApartment(string id)
    {
        var apartment = await _repository.GetApartment(id);
        if (apartment == null)
        {
            return NotFound($"Apartment with ID {id} not found");
        }

        return Ok(apartment);
    }


    //Henter lejgliheder som ikke er færdige
    [HttpGet]
    [Route("GetApartmentsNotFinishedCount")]
    public async Task<IActionResult> GetApartmentsNotFinishedCount()
    {
        var count = await _repository.GetApartmentsNotFinishedCount();
        return Ok(new { Count = count });
    }
    
    //Henter lejlighed baseret på bruger ID
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetApartmentByUserId(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return BadRequest("UserId is required.");
        }

        var apartment = await _repository.GetApartmentByUserId(userId);

        if (apartment == null)
        {
            return NotFound($"No apartment found for UserId: {userId}");
        }

        return Ok(apartment);
    }

    //Tildeler en lejer til en lejlighed
    [HttpPut("assign-tenant/{apartmentId}")]
    public async Task<IActionResult> AssignTenant(string apartmentId, [FromBody] Tenant tenant)
    {
        if (tenant == null)
        {
            return BadRequest("Tenant data is null.");
        }

        var success = await _repository.AssignTenantToApartment(apartmentId, tenant);

        if (!success)
        {
            return NotFound($"Apartment with ID {apartmentId} not found.");
        }

        return Ok($"Tenant assigned to apartment with ID {apartmentId}.");
    }


    // Opdaterer tilgængeligheden for en lejlighed
    [HttpPut("UpdateAvailability/{apartmentId}")]
    public async Task<IActionResult> UpdateAvailability(string apartmentId, [FromBody] List<Availability> availabilities)
    {
        if (availabilities == null || !availabilities.Any())
        {
            return BadRequest("Availability list is null or empty.");
        }

        
        foreach (var availability in availabilities)
        {
            availability.Date = availability.Date.ToUniversalTime();
        }

        var success = await _repository.UpdateApartmentAvailability(apartmentId, availabilities);

        if (!success)
        {
            return NotFound($"Apartment with ID {apartmentId} not found.");
        }

        return Ok("Availability updated successfully.");
    }

    // Henter tilgængelighed for en specifik lejlighed
    [HttpGet("GetAvailability/{apartmentId}")]
    public async Task<IActionResult> GetAvailability(string apartmentId)
    {
        var apartment = await _repository.GetApartment(apartmentId);

        if (apartment == null)
        {
            return NotFound($"Apartment with ID {apartmentId} not found.");
        }

      // Konverter datoer til lokal format, hvis de findes
        if (apartment.Availability != null)
        {
            foreach (var availability in apartment.Availability)
            {
                availability.Date = availability.Date.ToLocalTime();

            }
        }

        return Ok(apartment.Availability);
    }



}