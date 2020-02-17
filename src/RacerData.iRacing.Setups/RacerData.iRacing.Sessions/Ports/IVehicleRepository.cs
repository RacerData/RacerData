using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(long id);
        Task<IList<Vehicle>> GetVehiclesAsync();
        Task<IList<SetupProperty>> GetVehicleSetupProperties(long vehicleId);
        Task<Vehicle> InsertVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
    }
}
