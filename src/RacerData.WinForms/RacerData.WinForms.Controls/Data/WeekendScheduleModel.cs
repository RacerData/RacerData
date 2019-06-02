using System.Collections.Generic;

namespace RacerData.WinForms.Data
{
    public class WeekendSchedule
    {
        public string Name { get; set; }
        public IList<DayScheduleModel> DaySchedules { get; set; }

        public WeekendSchedule()
        {
            DaySchedules = new List<DayScheduleModel>();
        }
    }
}
