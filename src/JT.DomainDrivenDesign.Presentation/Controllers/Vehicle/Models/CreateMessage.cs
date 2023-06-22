using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace JT.DomainDrivenDesign.Presentation.Controllers.Vehicle.Models;

public class CreateMessage
{
    [FromBody]
    public VehicleDto Vehicle { get; set; }

    [FromRoute(Name = "id")]
    public string Id { get; set; }
}