using System.Threading.Tasks;
using RacerData.Nascar.Pages.Models;

namespace RacerData.Nascar.Pages.Ports
{
    internal interface IWeekendScheduleReader
    {
        Task<WeekendSchedule> GetScheduleAsync();
    }
}