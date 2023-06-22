using System;
using System.Threading.Tasks;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using JT.DomainDrivenDesign.Application.Vehicle.Mappers;
using JT.DomainDrivenDesign.Domain.Vehicle.Entities;
using JT.DomainDrivenDesign.Domain.Vehicle.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace JT.DomainDrivenDesign.Application.Tests;

public class VehicleRetrievalHandlerTests
{
    [Fact]
    public async Task Handle_VehicleExists_ReturnsVehicleDto()
    {
        // Arrange
        var mockVehicle = SharedMocks.CreateVehicleMock();
        var vehicleEntity = VehicleMapper.Map(mockVehicle);

        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(mockVehicle.Id)).ReturnsAsync(vehicleEntity);

        var handler = new VehicleRetrievalHandler(vehicleRepositoryMock.Object);

        // Act
        var result = await handler.Handle(new RetrieveVehicleQuery(mockVehicle));

        // Assert
        result.ShouldBeEquivalentTo(mockVehicle);
    }

    [Fact]
    public async Task Handle_VehicleDoesNotExist_ThrowsException()
    {
        // Arrange
        var mockVehicle = SharedMocks.CreateVehicleMock();

        var vehicleRepositoryMock = new Mock<IVehicleRepository>();
        vehicleRepositoryMock.Setup(r => r.Get(mockVehicle.Id))!.ReturnsAsync((VehicleEntity)null!);

        var handler = new VehicleRetrievalHandler(vehicleRepositoryMock.Object);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(new RetrieveVehicleQuery(mockVehicle)));
    }

}
