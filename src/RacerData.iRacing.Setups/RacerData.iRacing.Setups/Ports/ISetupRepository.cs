using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.iRacing.Setups.Models;

namespace RacerData.iRacing.Setups.Ports
{
    public interface ISetupRepository
    {
        Task<SetupBase> GetSetup(Guid id);
        Task<IList<SetupBase>> GetSetups();
        Task<IEnumerable<SetupBase>> GetSetups(SetupFilter filter);
        Task<SetupBase> InsertSetup(SetupBase setup);
        Task<SetupBase> UpdateSetup(SetupBase setup);
        Task<bool> DeleteSetup(Guid id);
    }
}
