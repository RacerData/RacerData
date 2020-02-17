using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface IDriverRepository
    {
        Task<Driver> GetDriverAsync(long id);
        Task<IList<Driver>> GetDriversAsync();
        Task<Driver> InsertDriverAsync(Driver driver);
        Task<Driver> UpdateDriverAsync(Driver driver);
    }
}
