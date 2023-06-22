using JT.DomainDrivenDesign.Application.Vehicle.Dtos;
using JT.DomainDrivenDesign.Application.Vehicle.Mappers;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;

namespace JT.DomainDrivenDesign.Application.Vehicle.Handlers;

public record RetrieveVehicleQuery(VehicleDto Vehicle);

public class VehicleRetrievalHandler : IQueryHandler<RetrieveVehicleQuery, VehicleDto>
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleRetrievalHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<VehicleDto> Handle(RetrieveVehicleQuery query)
    {
        var vehicleEntity = await _vehicleRepository.Get(query.Vehicle.Id);

        return vehicleEntity != null
            ? VehicleMapper.Map(vehicleEntity)
            : throw new Exception($"Could not retrieve vehicle with ID: {query.Vehicle.Id}");
    }
}
