using System.Threading.Tasks;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    interface IAwsDataPump
    {
        Task WriteLapAveragesAsync(LapAverageData lapAverages);
    }
}