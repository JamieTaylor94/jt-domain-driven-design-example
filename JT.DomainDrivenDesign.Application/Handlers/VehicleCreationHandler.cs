using JT.DomainDrivenDesign.Application.Dtos;
using JT.DomainDrivenDesign.Application.Mappers;
using JT.DomainDrivenDesign.Domain.VehicleDomain;

namespace JT.DomainDrivenDesign.Application;

public interface IVehicleCreationHandler
{
    Task Handle(CreateVehicle createVehicle);
}

public class VehicleCreationHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleCreationHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    
    public async Task Handle(CreateVehicle createVehicle)
    {
        var existingVehicle = await _vehicleRepository.Get(createVehicle.Id);

        if (existingVehicle != null)
        {
            throw new Exception($"Vehicle with Id: {existingVehicle.Id} already exists.");
        }

        var vehicle = VehicleMapper.Map(createVehicle);
        
        await _vehicleRepository.Add(vehicle);
    }
}