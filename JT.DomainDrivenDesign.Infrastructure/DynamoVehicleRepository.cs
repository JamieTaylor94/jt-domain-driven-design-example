using JT.DomainDrivenDesign.Domain.VehicleDomain.Entities;
using JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;

namespace JT.DomainDriverDesign.Infrastructure;

public class DynamoVehicleRepository : IVehicleRepository
{
    public async Task Add(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }
        
    public async Task<Vehicle> Get(string id)
    {
        throw new NotImplementedException();
    }
}