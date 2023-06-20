namespace JT.DomainDrivenDesign.Domain.VehicleDomain;

public interface IVehicleRepository
{ 
      Task Add(Vehicle vehicle);
      Task<Vehicle> Get(string id);
}