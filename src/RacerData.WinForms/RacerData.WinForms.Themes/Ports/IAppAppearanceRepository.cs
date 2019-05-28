using System;
using RacerData.Data.Json.Ports;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Ports
{
    public interface IAppAppearanceRepository : IJsonRepository<ApplicationAppearance, Guid>
    {
        ApplicationAppearance GetAppearance();
       
    }
}
