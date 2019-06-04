using System;
using RacerData.Data.Json.Ports;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IAppAppearanceRepository : IJsonRepository<ApplicationAppearance, Guid>
    {
        ApplicationAppearance GetAppearance();
       
    }
}
