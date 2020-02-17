using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.Nascar.Pages.Models;

namespace RacerData.Nascar.Pages.Ports
{
    public interface IWeekendScheduleService
    {
        Task<IResult<WeekendSchedule>> GetWeekendScheduleAsync();
    }
}
