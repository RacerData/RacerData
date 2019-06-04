using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.Data;

namespace RacerData.WinForms.Controls.Ports
{
    public interface ILiveDataService
    {
        Task<IResult<Dictionary<int, IDictionary<int, LiveData>>>> GetLiveDataAsync(IList<LiveDataSource> dataSources);
    }
}