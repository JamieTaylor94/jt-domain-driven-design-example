using System.Threading.Tasks;
using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using JT.DomainDrivenDesign.Presentation.Controllers;
using JT.DomainDrivenDesign.Presentation.Controllers.Vehicle;
using JT.DomainDrivenDesign.Presentation.Controllers.Vehicle.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace JT.DomainDrivenDesign.Presentation.Tests;

public class VehiclesControllerTests
{
    [Fact]
    public async Task Create_Vehicle_Is_Successful()
    {
        // Arrange
        var mockCreate = new Mock<ICommandHandler<CreateVehicleCommand>>();
        var mockRetrieve = new Mock<IQueryHandler<RetrieveVehicleQuery, VehicleDto>>();
        var controller = new VehiclesController(mockCreate.Object, mockRetrieve.Object);

        var vehicleDto = new VehicleDto
        {
            Model = "model",
            Description = "description",
            ColourDto = new ColourDto { Red = 255, Blue = 0, Green = 0 },
            Hitbox = "Octane"
        };

        // Act
        var result = await controller.Create(new CreateMessage { Vehicle = vehicleDto, Id = vehicleDto.Id });

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task Retrieve_Vehicle_Is_Successful()
    {
        // Arrange
        var mockCreate = new Mock<ICommandHandler<CreateVehicleCommand>>();
        var mockRetrieve = new Mock<IQueryHandler<RetrieveVehicleQuery, VehicleDto>>();
        var controller = new VehiclesController(mockCreate.Object, mockRetrieve.Object);

        var vehicleDto = new VehicleDto
        {
            Id = "123",
        };

        // Act
        var result = await controller.Retrieve(new RetrieveMessage {VehicleId = vehicleDto.Id});

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }
}
