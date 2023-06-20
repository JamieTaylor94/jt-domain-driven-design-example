using System;
using System.Threading.Tasks;
using JT.DomainDrivenDesign.Application.Dtos;
using JT.DomainDrivenDesign.Domain.VehicleDomain;
using Moq;
using Xunit;
using Colour = JT.DomainDrivenDesign.Application.Dtos.Colour;

namespace JT.DomainDrivenDesign.Application.Tests;

public class VehicleCreationHandlerTests
{
    [Fact]
    public async Task Handle_ValidInput_CreatesVehicle()
    {
        // Arrange
        var mockVehicle = CreateVehicleMock();

        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(mockVehicle.Id))!.ReturnsAsync((Vehicle)null!);

        var vehicleCreationHandler = new VehicleCreationHandler(vehicleRepositoryMock.Object);

        // Act
        await vehicleCreationHandler.Handle(mockVehicle);

        // Assert
        vehicleRepositoryMock.Verify(r => r.Add(It.IsAny<Vehicle>()), Times.Once);
    }

    [Fact]
    public async Task Handle_VehicleAlreadyExists_ThrowsException()
    {
        // Arrange
        var mockVehicle = CreateVehicleMock();

        var vehicleCreationHandler = new VehicleCreationHandler(CreateExistingVehicleMock().Object);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => vehicleCreationHandler.Handle(mockVehicle));
    }

    private CreateVehicle CreateVehicleMock()
    {
        return new CreateVehicle
        {
            Id = "123",
            Description = "test description",
            Model = "test model",
            Colour = new Colour
            {
                Red = 255, Green = 0, Blue = 0
            },
            Hitbox = "Octane"
        };
    }

    private Mock<IVehicleRepository> CreateExistingVehicleMock()
    {
        const string id = "123";
        var existingVehicle = Vehicle.Create(
            new VehicleCreationInput
            {
                Id = id,
                Model = "test modal",
                Description = "test description",
                Colour = new Domain.VehicleDomain.Colour(255, 0, 0),
                Hitbox = "Octane"
            });
        
        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(id)).ReturnsAsync(existingVehicle);

        return vehicleRepositoryMock;
    }
}