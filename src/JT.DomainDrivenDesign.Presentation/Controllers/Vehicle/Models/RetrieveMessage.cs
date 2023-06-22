using Microsoft.AspNetCore.Mvc;

namespace JT.DomainDrivenDesign.Presentation.Controllers.Vehicle.Models;

public class RetrieveMessage
{
    [FromRoute(Name = "id")]
    public string VehicleId { get; set; }
}