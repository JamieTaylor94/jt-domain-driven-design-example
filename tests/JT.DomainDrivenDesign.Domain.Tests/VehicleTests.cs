using System;
using JT.DomainDrivenDesign.Domain.Vehicle;
using JT.DomainDrivenDesign.Domain.Vehicle.Entities;
using JT.DomainDrivenDesign.Domain.Vehicle.ValueObjects;
using Xunit;

namespace JT.DomainDrivenDesign.Domain.Tests;

public class VehicleTests
{
    [Fact]
    public void Vehicle_Is_Correctly_Created()
    {
        // Arrange
        const string id = "VehicleIdentifier";
        const string model = "Vehicle 1";
        const string description = "Vehicle description";
        var colour = new Colour(255, 0, 0);
        var hitbox = "Octane";

        // Act
        var vehicle = VehicleEntity.Create(new VehicleCreationInput
        {
            Id = id,
            Model = model,
            Description = description,
            Colour = colour,
            Hitbox = hitbox
        });

        // Assert
        Assert.Equal(model, vehicle.Model);
        Assert.Equal(description, vehicle.Description); 
        Assert.Equal(colour, vehicle.Colour);
        Assert.Equal(hitbox, vehicle.Hitbox.Name);
    }

    [Fact]
    public void Invalid_Hitbox_Throws()
    {
        Assert.Throws<ArgumentException>(() => Hitbox.Create("invalid"));
    }
}