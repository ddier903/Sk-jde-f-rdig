using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _repository;

    public UserController()
    {
        _repository = new UserRepository();
    }
