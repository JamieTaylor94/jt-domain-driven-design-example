using JT.DomainDrivenDesign.Application.Dtos;
using JT.DomainDrivenDesign.Domain.VehicleDomain;
using Colour = JT.DomainDrivenDesign.Domain.VehicleDomain.Colour;

namespace JT.DomainDrivenDesign.Application.Mappers;

// Mapper is an application layer service

public class VehicleMapper
{
    public static Vehicle Map(CreateVehicle creation)
    {
        return Vehicle.Create(
            new VehicleCreationInput
            {
                Id = creation.Id,
                Model = creation.Model,
                Description = creation.Description,
                Colour = new Colour(creation.Colour.Red, creation.Colour.Green, creation.Colour.Blue),
                Hitbox = creation.Hitbox
            });
    }
}