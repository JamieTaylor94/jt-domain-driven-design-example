using JT.DomainDrivenDesign.Application.Dtos;
using JT.DomainDrivenDesign.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace JT.DomainDrivenDesign.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleCreationHandler _handler;

        public VehicleController(IVehicleCreationHandler handler)
        {
            _handler = handler;
        }
        
        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(CreateVehicle createVehicle)
        {  
            await _handler.Handle(createVehicle);
            return Ok();
        }
    }
}