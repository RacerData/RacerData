using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Data;

namespace RacerData.WinForms.Controls.Ports
{
    public interface IListDataService
    {
        Task<IResult<ListViewData>> GetListDataAsync();
    }
}