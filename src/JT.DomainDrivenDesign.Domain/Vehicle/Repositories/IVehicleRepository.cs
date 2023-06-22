using JT.DomainDrivenDesign.Domain.Vehicle.Entities;

namespace JT.DomainDrivenDesign.Domain.Vehicle.Repositories;

public interface IVehicleRepository
{ 
      Task Add(VehicleEntity vehicleEntity);
      Task<VehicleEntity> Get(string id);
}