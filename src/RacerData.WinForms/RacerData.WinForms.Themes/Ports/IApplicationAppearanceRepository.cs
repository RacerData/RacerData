using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Ports
{
    public interface IApplicationAppearanceRepository
    {
        Task<IResult<IList<IApplicationAppearance>>> SelectListAsync();
        Task<IResult<IApplicationAppearance>> SelectAsync(string key);
        Task<IResult<IApplicationAppearance>> InsertAsync(IApplicationAppearance applicationAppearance);
        Task<IResult<IApplicationAppearance>> UpdateAsync(IApplicationAppearance applicationAppearance);
        Task<IResult<IApplicationAppearance>> DeleteAsync(string key);
    }
}
