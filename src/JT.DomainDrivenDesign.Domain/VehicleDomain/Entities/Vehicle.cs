using JT.DomainDrivenDesign.Domain.VehicleDomain.ValueObjects;

namespace JT.DomainDrivenDesign.Domain.VehicleDomain.Entities;

public class Vehicle
{
    public string Id { get; }
    public string Model { get; }
    public string Description { get; }
    public Colour Colour { get; }
    public Hitbox Hitbox { get; }

    private Vehicle(string id, string model, string description, Colour colour, Hitbox hitbox)
    {
        Id = id;
        Model = model;
        Description = description;
        Colour = colour;
        Hitbox = hitbox;
    }

    public static Vehicle Create(VehicleCreationInput input)
    {
        return new Vehicle(
            id: input.Id,
            model: input.Model,
            description: input.Description,
            colour: input.Colour,
            hitbox: Hitbox.Create(input.Hitbox)
        );
    }
}
