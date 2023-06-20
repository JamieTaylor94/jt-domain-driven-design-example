using JT.DomainDrivenDesign.Domain.VehicleDomain.Entities;

namespace JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;

public interface IVehicleRepository
{ 
      Task Add(VehicleEntity vehicleEntity);
      Task<VehicleEntity> Get(string id);
}