using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;

namespace JT.DomainDrivenDesign.Application.Vehicle.Handlers;

public interface IVehicleHandler
{
    Task Handle(OperationType operationType, VehicleDto vehicle);
}

public class VehicleHandler : IVehicleHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task Handle(OperationType operationType, VehicleDto vehicle)
    {
        switch (operationType)
        {
            case OperationType.Create:
                var handler = new VehicleCreationHandler(_vehicleRepository);
                await handler.Handle(vehicle);
                break;
            case OperationType.Retrieve:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
        }
    }
}
