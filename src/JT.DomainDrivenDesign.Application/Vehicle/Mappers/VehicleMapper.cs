using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Domain.VehicleDomain;
using Colour = JT.DomainDrivenDesign.Domain.VehicleDomain.ValueObjects.Colour;

namespace JT.DomainDrivenDesign.Application.Vehicle.Mappers;

public class VehicleMapper
{
    public static Domain.VehicleDomain.Entities.VehicleEntity Map(VehicleDto creation)
    {
        return Domain.VehicleDomain.Entities.VehicleEntity.Create(
            new VehicleCreationInput
            {
                Id = creation.Id,
                Model = creation.Model,
                Description = creation.Description,
                Colour = new Colour(creation.ColourDto.Red, creation.ColourDto.Green, creation.ColourDto.Blue),
                Hitbox = creation.Hitbox
            });
    }
}