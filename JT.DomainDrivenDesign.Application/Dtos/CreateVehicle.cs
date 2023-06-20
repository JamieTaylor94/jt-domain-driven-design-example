namespace JT.DomainDrivenDesign.Application.Dtos;

public class CreateVehicle
{
    public string Id { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public Colour Colour { get; set; }
    public string Hitbox { get; set; }
}

