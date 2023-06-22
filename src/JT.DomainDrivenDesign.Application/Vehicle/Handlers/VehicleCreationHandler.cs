using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Mappers;
using JT.DomainDrivenDesign.Domain.Vehicle.Repositories;

namespace JT.DomainDrivenDesign.Application.Vehicle.Handlers;

public record CreateVehicleCommand(VehicleDto Vehicle);

public class VehicleCreationHandler : ICommandHandler<CreateVehicleCommand>
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleCreationHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task Handle(CreateVehicleCommand command)
    {
        var existingVehicle = await _vehicleRepository.Get(command.Vehicle.Id);

        if (existingVehicle != null)
        {
            throw new Exception($"Vehicle with Id: {existingVehicle.Id} already exists.");
        }

        var vehicle = VehicleMapper.Map(command.Vehicle);

        await _vehicleRepository.Add(vehicle);
    }
}