using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core; 


// Håndterer API-Kald relateret til brugere som admins, underentreprenører og lejere
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _repository;

    public UserController()
    {
        _repository = new UserRepository();
    }

    //Tilføjer en admin
    [HttpPost]
    [Route("AddAdmin")]
    public async Task<IActionResult> PostAdmin([FromBody] Admin admin)
	{

        if (admin == null)
        {
            return BadRequest("Admin object is null");
        }

        await _repository.PostAdmin(admin);
        return Ok("Admin added successfully");

    }

    //Tilføjer en underentreprenør

    [HttpPost]
    [Route("AddSubcontractor")]
    public async Task<IActionResult> PostSubcontractor([FromBody] Subcontractor subcontractor)
    {

        if (subcontractor == null)
        {
            return BadRequest("Subcontractor object is null");
        }

        await _repository.PostSubcontractor(subcontractor);
        return Ok("Subcontractor added successfully");
    }

    //Tilføjer lejer 

    [HttpPost]
    [Route("AddTenant")]
    public async Task<IActionResult> PostTenant([FromBody] Tenant tenant)
    {

        if (tenant == null)
        {
            return BadRequest("Tenant object is null");
        }

        await _repository.PostTenant(tenant);
        return Ok("Tenant added successfully");

    }

    //Sletter en bruger baseret på deres userID
    [HttpDelete]
    [Route("DeleteUser/{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
	{

		await _repository.DeleteUSer(userId);
		return Ok("User deleted successfully");

	}
    //Opdaterer en brugers data, baseret på userID
    [HttpPut]
    [Route("UpdateUser{userId}")]
    public async Task<IActionResult> UpdateUser(string userId, [FromBody] User updateduser)
	{

		await _repository.UpdateUser(userId, updateduser);
		return Ok("User updated successfully");

	}

    //Autentificerer bruger baseret på brugernavn og adgangskode
    [HttpGet]
    [Route("Authenticate")]

    public async Task<IActionResult> Authenticate([FromQuery] string username, string password)
    {
        var userlogin = await _repository.Authenticate(username, password);
        if (!userlogin)
        {
            return NotFound(new { success = false, message = "Invalid username or password." });
        }

        return Ok(new { success = true });
    }

    //Henter detajler om den som er logget ind, baseret på brugernavn

    [HttpGet]
    [Route("GetLoggedInUser")]

    public async Task<IActionResult> GetLoggedInUser([FromQuery] string username)
    {
        var LoggedInUser = await _repository.GetLoggedInUser(username);

        if (LoggedInUser == null)
        {
            return NotFound("Invalid username or password");
        }
        return Ok(LoggedInUser);
    }

    // Henter en bruger baseret på userID
    [HttpGet]
    [Route("GetUserById/{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
	{
        Console.WriteLine($"Fetching user with ID: {userId}");
        var user = await _repository.GetUserById(userId);
        if (user == null)
        {
            Console.WriteLine($"User with ID {userId} not found.");
            return NotFound($"User with ID {userId} not found");
        }
        Console.WriteLine($"User found: {user.UserName}");
        return Ok(user);
    }

    //Henter alle underentreprenører
    [HttpGet]
    [Route("GetSubcontractors")]
    public async Task<IActionResult> GetAllSubcontractors()
	{
        var subcontractors = await _repository.GetAllSubcontractors();
        if (subcontractors == null || !subcontractors.Any())
        {
            return NotFound("No subcontractors found");
        }

        return Ok(subcontractors);
    }
}
