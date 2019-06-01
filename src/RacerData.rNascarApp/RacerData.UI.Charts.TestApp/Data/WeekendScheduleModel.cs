﻿using System.Collections.Generic;

namespace rNascarApp.UI.Data
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
