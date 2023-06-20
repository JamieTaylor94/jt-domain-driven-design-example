using System;
using System.Threading.Tasks;
using JT.DomainDrivenDesign.Application.Vehicle;
using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using JT.DomainDrivenDesign.Domain.VehicleDomain;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Entities;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;
using Moq;
using Xunit;

namespace JT.DomainDrivenDesign.Application.Tests;

public class VehicleCreationHandlerTests
{
    [Fact]
    public async Task Handle_ValidInput_CreatesVehicle()
    {
        // Arrange
        var mockVehicle = CreateVehicleMock();

        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(mockVehicle.Id))!.ReturnsAsync((VehicleEntity)null!);

        var commandHandler = new VehicleHandler(vehicleRepositoryMock.Object);

        // Act
        await commandHandler.Handle(OperationType.Create, mockVehicle);

        // Assert
        vehicleRepositoryMock.Verify(r => r.Add(It.IsAny<VehicleEntity>()), Times.Once);
    }

    [Fact]
    public async Task Handle_VehicleAlreadyExists_ThrowsException()
    {
        // Arrange
        var mockVehicle = CreateVehicleMock();

        var commandHandler = new VehicleHandler(CreateExistingVehicleMock().Object);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => commandHandler.Handle(OperationType.Create, mockVehicle));
    }

    private VehicleDto CreateVehicleMock()
    {
        return new VehicleDto
        {
            Id = "123",
            Description = "test description",
            Model = "test model",
            ColourDto = new ColourDto
            {
                Red = 255, Green = 0, Blue = 0
            },
            Hitbox = "Octane"
        };
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
                Colour = new Domain.VehicleDomain.ValueObjects.Colour(255, 0, 0),
                Hitbox = "Octane"
            });
        
        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(id)).ReturnsAsync(existingVehicle);

        return vehicleRepositoryMock;
    }
}