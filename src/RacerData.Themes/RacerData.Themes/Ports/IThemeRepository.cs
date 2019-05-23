using System;
using RacerData.Data.Ports;
using RacerData.Themes.Models;

namespace RacerData.Themes.Ports
{
    public interface IThemeRepository : IRepository<Theme, Guid>
    {
        void SaveChanges();
    }
}
