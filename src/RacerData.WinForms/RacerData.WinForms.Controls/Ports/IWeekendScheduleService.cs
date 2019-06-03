using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.Models.WeekendScheduleView;

namespace RacerData.WinForms.Controls.Ports
{
    public interface IWeekendScheduleService
    {
        Task<IResult<WeekendSchedule>> GetWeekendScheduleAsync();
    }
}
