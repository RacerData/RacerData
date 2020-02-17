using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.Nascar.Pages.Models
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
