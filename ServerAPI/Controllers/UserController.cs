using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core; 

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _repository;

    public UserController()
    {
        _repository = new UserRepository();
    }

    //Add Admin
    [HttpPost]
    [Route("AddAdmin")]
    public async Task<IActionResult> PostAdmin(Admin admin)
	{

		await _repository.PostAdmin(admin);
		return Ok("User added successfully");

	}

    //Add Subcontractor

    [HttpPost]
    [Route("AddSubcontractor")]
    public async Task<IActionResult> PostSubcontractor(Subcontractor subcontractor)
    {

        await _repository.PostSubcontractor(subcontractor);
        return Ok("User added successfully");

    }

    //Add Tenant

    [HttpPost]
    [Route("AddTenant")]
    public async Task<IActionResult> PostTenant(Tenant tenant)
    {

        await _repository.PostTenant(tenant);
        return Ok("User added successfully");

    }

    //Delete User
    [HttpDelete]
    [Route("DeleteUser")]
    public async Task<IActionResult> DeleteUser(int userId)
	{

		await _repository.DeleteUSer(userId);
		return Ok("User deleted successfully");

	}
    //Update User
    [HttpPut]
    [Route("UpdateUser")]
    public async Task<IActionResult> UpdateUser(int userId, User updateduser)
	{

		await _repository.UpdateUser(userId, updateduser);
		return Ok("User updated successfully");

	}

    //Get User by Username and Password
    [HttpGet]
    [Route("GetUserByUsernameAndPassword")]

    public async Task<User> GetUserByUsernameAndPassword(string username, string password)
	{
		return await _repository.GetUserByUsernameAndPassword(username, password);
	}

    //Get USer by UserID
    [HttpGet]
    [Route("GetUserById")]
    public async Task<User> GetUserById(int userId)
	{
		return await _repository.GetUserById(userId);
	}

    //Get All Subcontractors
    [HttpGet]
    [Route("GetSubcontractors")]
    public async Task<IEnumerable<User>> GetAllSubcontractors()
	{
		return await _repository.GetAllSubcontractors();
	}
}
