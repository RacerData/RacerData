using System.Threading.Tasks;
using RacerData.WinForms.Controls.Models.WeekendScheduleView;

namespace RacerData.WinForms.Ports
{
    internal interface IWeekendScheduleReader
    {
        Task<WeekendSchedule> GetScheduleAsync();
    }
}