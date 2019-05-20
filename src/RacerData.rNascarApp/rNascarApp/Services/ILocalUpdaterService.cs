using System;
using System.Threading.Tasks;
using RacerData.UpdaterService.Models;

namespace RacerData.rNascarApp.Services
{
    public interface ILocalUpdaterService
    {
        Task<UpdateResponse> CheckForUpdatesAsync(Version currentVersion);
        void DisplayUpdater();
    }
}