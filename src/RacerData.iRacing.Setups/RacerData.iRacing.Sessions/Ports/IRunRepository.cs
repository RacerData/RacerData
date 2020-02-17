using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface IRunRepository : System.IDisposable
    {
        Task<Run> InsertRunAsync(Run run);
        Run GetRun(string fileName);
        IQueryable<Lap> GetLaps(long runId);
        IQueryable<TireSheet> GetTireSheetQuery(long runId);
        TireSheet GetTireSheet(long runId);
        IQueryable<SetupValue> GetSetupValuesQuery(long runId);
        IList<SetupValue> GetSetupValues(long runId);
    }
}
