using System;
using System.Threading.Tasks;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using JT.DomainDrivenDesign.Domain.Vehicle;
using JT.DomainDrivenDesign.Domain.Vehicle.Entities;
using JT.DomainDrivenDesign.Domain.Vehicle.Repositories;
using JT.DomainDrivenDesign.Domain.Vehicle.ValueObjects;
using Moq;
using Xunit;

namespace JT.DomainDrivenDesign.Application.Tests;

public class VehicleCreationHandlerTests
{
    [Fact]
    public async Task Handle_ValidInput_CreatesVehicle()
    {
        // Arrange
        var mockVehicle = SharedMocks.CreateVehicleMock();

        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(mockVehicle.Id))!.ReturnsAsync((VehicleEntity)null!);

        var handler = new VehicleCreationHandler(vehicleRepositoryMock.Object);

        // Act
        await handler.Handle(new CreateVehicleCommand(mockVehicle));

        // Assert
        vehicleRepositoryMock.Verify(r => r.Add(It.Is<VehicleEntity>(v =>
            v.Id == mockVehicle.Id &&
            v.Description == mockVehicle.Description &&
            v.Model == mockVehicle.Model &&
            v.Colour.Red == mockVehicle.ColourDto.Red &&
            v.Colour.Green == mockVehicle.ColourDto.Green &&
            v.Colour.Blue == mockVehicle.ColourDto.Blue &&
            v.Hitbox.Name == mockVehicle.Hitbox
        )), Times.Once);
    }

    [Fact]
    public async Task Handle_VehicleAlreadyExists_ThrowsException()
    {
        // Arrange
        var mockVehicle = SharedMocks.CreateVehicleMock();

        var vehicleRepositoryMock = CreateExistingVehicleMock();

        var commandHandler = new VehicleCreationHandler(vehicleRepositoryMock.Object);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => commandHandler.Handle(new CreateVehicleCommand(mockVehicle)));
    }

    private Mock<IVehicleRepository> CreateExistingVehicleMock()
    {
        const string id = "123";
        var existingVehicle = VehicleEntity.Create(
            new VehicleCreationInput
            {
                Id = id,
                Model = "test modal",
                Description = "test description",
                Colour = new Colour(255, 0, 0),
                Hitbox = "Octane"
            });

        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(id)).ReturnsAsync(existingVehicle);

        return vehicleRepositoryMock;
    }
}