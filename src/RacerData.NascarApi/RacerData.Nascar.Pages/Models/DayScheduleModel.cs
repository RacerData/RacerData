using System;
using System.Collections.Generic;

namespace RacerData.Nascar.Pages.Models
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
