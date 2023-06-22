using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Domain.VehicleDomain;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Entities;
using Colour = JT.DomainDrivenDesign.Domain.VehicleDomain.ValueObjects.Colour;

namespace JT.DomainDrivenDesign.Application.Vehicle.Mappers;

public static class VehicleMapper
{
    public static VehicleEntity Map(VehicleDto creation)
    {
        return VehicleEntity.Create(
            new VehicleCreationInput
            {
                Id = creation.Id,
                Model = creation.Model,
                Description = creation.Description,
                Colour = new Colour(creation.ColourDto.Red, creation.ColourDto.Green, creation.ColourDto.Blue),
                Hitbox = creation.Hitbox
            });
    }

    public static VehicleDto Map(VehicleEntity vehicle)
    {
        return new VehicleDto
        {
            Id = vehicle.Id,
            Description = vehicle.Description,
            ColourDto = new ColourDto
            {
                Blue = vehicle.Colour.Blue,
                Green = vehicle.Colour.Green,
                Red = vehicle.Colour.Red
            },
            Hitbox = vehicle.Hitbox.Name,
            Model = vehicle.Model,
        };
    }
}