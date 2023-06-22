using JT.DomainDrivenDesign.Application.Vehicle.Dtos;

namespace JT.DomainDrivenDesign.Application.Tests;

public class SharedMocks
{
    public static VehicleDto CreateVehicleMock()
    {
        return new VehicleDto
        {
            Id = "123",
            Description = "test description",
            Model = "test model",
            ColourDto = new ColourDto
            {
                Red = 255,
                Green = 0,
                Blue = 0
            },
            Hitbox = "Octane"
        };
    }
}