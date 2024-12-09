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


    //Post apartment: 

    //Update apartment: 

    //Get all Apartments:

    // Get all apartments filtered by status:

    //Get Apartment:

    //Get Apartments "Ikke færdig" Count. 


}