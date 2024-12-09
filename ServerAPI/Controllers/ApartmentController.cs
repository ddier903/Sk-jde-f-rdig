using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core; 

[ApiController]
[Route("api/[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly ApartmentRepository _repository;

    public ApartmentController()
    {
        _repository = new ApartmentRepository();
    }
}