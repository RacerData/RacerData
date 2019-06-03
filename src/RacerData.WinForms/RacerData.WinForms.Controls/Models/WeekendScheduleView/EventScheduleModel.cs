using System;

namespace RacerData.WinForms.Controls.Models.WeekendScheduleView
{
    public class EventScheduleModel
    {
        public string Series { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string LogoUrl { get; set; }
        public string ResultsUrl { get; set; }
        public string WatchLiveUrl { get; set; }
        public string TvRadio { get; set; }
    }
}
