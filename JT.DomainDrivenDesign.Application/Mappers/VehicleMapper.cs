using JT.DomainDrivenDesign.Application.Dtos;
using JT.DomainDrivenDesign.Domain.VehicleDomain;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Entities;
using Colour = JT.DomainDrivenDesign.Domain.VehicleDomain.ValueObjects.Colour;

namespace JT.DomainDrivenDesign.Application.Mappers;

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