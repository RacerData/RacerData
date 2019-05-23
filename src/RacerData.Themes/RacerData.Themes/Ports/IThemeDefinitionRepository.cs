using System;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.Data.Ports;
using RacerData.Themes.Models;

namespace RacerData.Themes.Ports
{
    public interface IThemeDefinitionRepository : IRepository<ThemeDefinition, Guid>
    {
        Task<IResult<ThemeDefinition>> SelectThemeAsync(string name);
        void SaveChanges();
        void RevertChanges();
    }
}
