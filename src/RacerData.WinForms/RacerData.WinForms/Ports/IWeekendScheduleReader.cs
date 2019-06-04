using System.Threading.Tasks;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    internal interface IWeekendScheduleReader
    {
        Task<WeekendSchedule> GetScheduleAsync();
    }
}