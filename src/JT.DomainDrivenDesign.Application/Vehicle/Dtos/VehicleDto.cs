namespace JT.DomainDrivenDesign.Application.Vehicle.Dtos;

public class VehicleDto
{
    public string Id { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public ColourDto ColourDto { get; set; }
    public string Hitbox { get; set; }
}

