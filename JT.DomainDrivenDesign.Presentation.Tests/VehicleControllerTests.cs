using System.Threading.Tasks;
using JT.DomainDrivenDesign.Application;
using JT.DomainDrivenDesign.Application.Dtos;
using JT.DomainDrivenDesign.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace JT.DomainDrivenDesign.Presentation.Tests
{
    public class VehicleControllerTests
    {
        [Fact]
        public async Task Create_Vehicle_Is_Successful()
        {
            // Arrange
            var mockHandler = new Mock<IVehicleCreationHandler>();
            mockHandler.Setup(handler => handler.Handle(It.IsAny<CreateVehicle>()));
            var controller = new VehicleController(mockHandler.Object);

            // Act
            var result = await controller.Create(new CreateVehicle
            {
                Id = "123", Model = "model", Description = "description",
                Colour = new Colour { Red = 255, Blue = 0, Green = 0 }, Hitbox = "Octane"
            });

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}