using System.Threading.Tasks;
using RacerData.Common.Results;

namespace RacerData.WinForms.Controls.Ports
{
    public interface IGraphDataService
    {
        Task<IResult> GetGraphDataAsync();
    }
}