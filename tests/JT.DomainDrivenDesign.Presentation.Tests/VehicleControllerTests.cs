using System.Threading.Tasks;
using JT.DomainDrivenDesign.Application.Vehicle;
using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Handlers;
using JT.DomainDrivenDesign.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace JT.DomainDrivenDesign.Presentation.Tests;

public class VehicleControllerTests
{
    [Fact]
    public async Task Create_Vehicle_Is_Successful()
    {
        // Arrange
        var mockHandler = new Mock<IVehicleHandler>();
        mockHandler.Setup(handler => handler.Handle(OperationType.Create, It.IsAny<VehicleDto>()));
        var controller = new VehicleController(mockHandler.Object);

        // Act
        var result = await controller.Create(new VehicleDto
        {
            Id = "123", Model = "model", Description = "description",
            ColourDto = new ColourDto { Red = 255, Blue = 0, Green = 0 }, Hitbox = "Octane"
        });

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task Retrieve_Vehicle_Is_Successful()
    {
        
    }
}