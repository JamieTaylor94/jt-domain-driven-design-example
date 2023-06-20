using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Mappers;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;

namespace JT.DomainDrivenDesign.Application.Vehicle.Handlers;

public class VehicleCreationHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleCreationHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    
    public async Task Handle(VehicleDto vehicleDto)
    {
        var existingVehicle = await _vehicleRepository.Get(vehicleDto.Id);

        if (existingVehicle != null)
        {
            throw new Exception($"Vehicle with Id: {existingVehicle.Id} already exists.");
        }

        var vehicle = VehicleMapper.Map(vehicleDto);
        
        await _vehicleRepository.Add(vehicle);
    }
}