using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IWeekendScheduleService
    {
        Task<IResult<WeekendSchedule>> GetWeekendScheduleAsync();
    }
}
