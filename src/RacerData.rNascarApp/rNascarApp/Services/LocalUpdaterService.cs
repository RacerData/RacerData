using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.UpdaterService.Models;
using RacerData.UpdaterService.Ports;

namespace RacerData.rNascarApp.Services
{
    public class LocalUpdaterService
    {
        public static void DisplayUpdater()
        {
            var thisVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var thisApplicationPath = Application.ExecutablePath;
            var thisApplicationDirectory = System.IO.Path.GetDirectoryName(thisApplicationPath);
            var autoUpdate = 0;
            var updaterApplicationPath = @"C:\Users\Rob\source\repos\RacerData\src\RacerData.Updater\RacerData.Updater.UI\bin\Release\RacerData.Updater.exe";// System.IO.Path.Combine(thisApplicationDirectory, "RacerData.Updater.exe");

            var updaterApplication = new Process();
            updaterApplication.StartInfo.FileName = updaterApplicationPath;
            updaterApplication.StartInfo.Arguments = $"{thisApplicationPath} {thisVersion} {autoUpdate}";
            updaterApplication.Start();
        }

        public async Task<UpdateResponse> CheckForUpdatesAsync(Version currentVersion)
        {
            var updater = ServiceProvider.Instance.GetRequiredService<IUpdateService>();

            var result = await updater.GetUpdatesAsync("rNascar", currentVersion);

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            return result.Value;
        }
    }
}
