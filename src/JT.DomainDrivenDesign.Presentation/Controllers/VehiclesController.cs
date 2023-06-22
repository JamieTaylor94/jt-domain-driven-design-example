using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace JT.DomainDrivenDesign.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    
    private readonly ICommandHandler<CreateVehicleCommand> _createVehicleCommandHandler;
    private readonly IQueryHandler<RetrieveVehicleQuery, VehicleDto> _retrieveVehicleQueryHandler;

    public VehiclesController(
        ICommandHandler<CreateVehicleCommand> createVehicleCommandHandler,
        IQueryHandler<RetrieveVehicleQuery, VehicleDto> retrieveVehicleQueryHandler)
    {
        _createVehicleCommandHandler = createVehicleCommandHandler;
        _retrieveVehicleQueryHandler = retrieveVehicleQueryHandler;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Create([FromRoute] CreateMessage message)
    { 
        await _createVehicleCommandHandler
            .Handle(new CreateVehicleCommand(message.Vehicle))
            .ConfigureAwait(false); // this is a performance optimisation for multi-threaded applications so we can get the context back on any thread.
        return Ok(); // could return created with location and the id
    }

    [HttpGet(Name = "Retrieve")]
    public async Task<IActionResult> Retrieve(string vehicleId)
    {
        var response = await _retrieveVehicleQueryHandler
            .Handle(new RetrieveVehicleQuery(new VehicleDto
            {
                Id = vehicleId
            }))
            .ConfigureAwait(false);

        return Ok(response);
    }
}

public class CreateMessage
{
    [FromBody]
    public VehicleDto Vehicle { get; set; }

    [FromRoute(Name = "id")]
    public string Id { get; set; }
}