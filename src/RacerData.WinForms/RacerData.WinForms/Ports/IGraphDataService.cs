using System.Threading.Tasks;
using RacerData.Common.Results;

namespace RacerData.WinForms.Ports
{
    public interface IGraphDataService
    {
        Task<IResult> GetGraphDataAsync();
    }
}