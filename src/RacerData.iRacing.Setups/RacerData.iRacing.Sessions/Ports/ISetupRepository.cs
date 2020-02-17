using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface ISetupRepository
    {
        void MarkSetupFileAsMoved(string fullPath);
        SetupFile InsertSetupFile(SetupFile setupFile);
        IList<SetupFile> GetSetupFiles();
        IList<DuplicateSetupFile> GetDuplicateSetupFiles();

        Task<Setup> GetSetupAsync(long id);
        Task<Setup> GetSetupAsync(long vehicleId, string name, int updateCount);
        Task<IList<Setup>> GetSetupsAsync();
        Task<Setup> InsertSetupAsync(Setup setup);
        Task<Setup> UpdateSetupAsync(Setup setup);
        IQueryable<Setup> GetSetupsQuery();
        IQueryable<SetupValue> SearchSetupsQuery();
        IList<Run> SearchSetupsList(long setupPropertyId, double? min, double? max);
    }
}
