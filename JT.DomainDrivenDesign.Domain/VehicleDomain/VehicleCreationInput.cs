namespace JT.DomainDrivenDesign.Domain.VehicleDomain;

public class VehicleCreationInput
{
    public string Id { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public Colour Colour { get; set; }
    public string Hitbox { get; set; }
}