using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface ITelemetryFileInfoRepository : IDisposable
    {
        Task<TelemetryFileInfo> GetTelemetryFileInfoAsync(long id);
        TelemetryFileInfo GetTelemetryFileInfoAsync(string fileName);
        Task<IList<TelemetryFileInfo>> GetTelemetryFileInfosAsync();
        IQueryable<TelemetryFileInfo> GetTelemetryFileInfoQuery();
        Task<IList<TelemetryFileInfo>> GetTelemetryFileInfosAsync(int skip, int take);
        Task<IList<TelemetryFileInfo>> GetUnprocessedTelemetryFileInfosAsync(int skip, int take);
        IQueryable<TelemetryFileInfo> Search(TelemetryFileInfoSearch criteria);
        Task<TelemetryFileInfo> InsertTelemetryFileInfoAsync(TelemetryFileInfo telemetryFileInfo);
        Task<TelemetryFileInfo> UpdateTelemetryFileInfoAsync(TelemetryFileInfo telemetryFileInfo);
        int GetTelemetryFileInfosCountAsync();
        int GetUnprocessedTelemetryFileInfosCountAsync();
        void MarkAsProcessed(long id);
        void MarkAsErrored(long id, Exception ex);
    }
}
