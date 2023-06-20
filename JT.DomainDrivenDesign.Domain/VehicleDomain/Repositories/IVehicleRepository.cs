using JT.DomainDrivenDesign.Domain.VehicleDomain.Entities;

namespace JT.DomainDrivenDesign.Domain.VehicleDomain.Repositories;

public interface IVehicleRepository
{ 
      Task Add(Vehicle vehicle);
      Task<Vehicle> Get(string id);
}