﻿using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> PostAdmin([FromBody] Admin admin)
	{

        if (admin == null)
        {
            return BadRequest("Admin object is null");
        }

        await _repository.PostAdmin(admin);
        return Ok("Admin added successfully");

    }

    //Add Subcontractor

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

    //Add Tenant

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

    //Delete User
    [HttpDelete]
    [Route("DeleteUser{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
	{

		await _repository.DeleteUSer(userId);
		return Ok("User deleted successfully");

	}
    //Update User
    [HttpPut]
    [Route("UpdateUser{userId}")]
    public async Task<IActionResult> UpdateUser(string userId, [FromBody] User updateduser)
	{

		await _repository.UpdateUser(userId, updateduser);
		return Ok("User updated successfully");

	}

    //Get User by Username and Password
    [HttpPost]
    [Route("Authenticate")]

    public async Task<IActionResult> Authenticate(User user)
	{
        var userlogin = await _repository.Authenticate(user);
        if (userlogin == null)
        {
            return NotFound($"Invalid username or password.");
        }

        return Ok( new { userlogin.UserId, userlogin.UserName, userlogin.Role });
    }

    //Get USer by UserID
    [HttpGet]
    [Route("GetUserById{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
	{
        var user = await _repository.GetUserById(userId);
        if (user == null)
        {
            return NotFound($"User with ID {userId} not found");
        }

        return Ok(user);
    }

    //Get All Subcontractors
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
