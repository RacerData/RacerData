using System;
using System.Collections.Generic;

namespace RacerData.WinForms.Data
{
    public class DayScheduleModel
    {
        public DateTime Date { get; set; }
        public IList<EventScheduleModel> ScheduledEvents { get; set; }

        public DayScheduleModel()
        {
            ScheduledEvents = new List<EventScheduleModel>();
        }
    }
}
