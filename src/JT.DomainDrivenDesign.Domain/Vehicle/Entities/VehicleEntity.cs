using JT.DomainDrivenDesign.Domain.Vehicle.ValueObjects;

namespace JT.DomainDrivenDesign.Domain.Vehicle.Entities;

public class VehicleEntity
{
    public string Id { get; }
    public string Model { get; }
    public string Description { get; }
    public Colour Colour { get; }
    public Hitbox Hitbox { get; }

    private VehicleEntity(string id, string model, string description, Colour colour, Hitbox hitbox)
    {
        Id = id;
        Model = model;
        Description = description;
        Colour = colour;
        Hitbox = hitbox;
    }

    public static VehicleEntity Create(VehicleCreationInput input)
    {
        return new VehicleEntity(
            id: input.Id,
            model: input.Model,
            description: input.Description,
            colour: input.Colour,
            hitbox: Hitbox.Create(input.Hitbox)
        );
    }
}
