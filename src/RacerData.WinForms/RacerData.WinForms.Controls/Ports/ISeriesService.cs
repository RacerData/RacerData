using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.Models;

namespace RacerData.WinForms.Controls.Ports
{
    public interface ISeriesService
    {
        Task<IResult<IList<SeriesModel>>> GetSeriesListAsync();
        Task<IResult<SeriesModel>> GetSeriesAsync(int seriesId);
    }
}
