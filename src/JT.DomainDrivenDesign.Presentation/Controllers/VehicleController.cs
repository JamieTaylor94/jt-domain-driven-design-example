using JT.DomainDrivenDesign.Application.Vehicle;
using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace JT.DomainDrivenDesign.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleCommandHandler _handler;

    public VehicleController(IVehicleCommandHandler handler)
    {
        _handler = handler;
    }
        
    [HttpPost(Name = "Create")]
    public async Task<IActionResult> Create(VehicleDto vehicleDto)
    {
        await _handler.Handle(OperationType.Create, vehicleDto);
            
        return Ok();
    }
}