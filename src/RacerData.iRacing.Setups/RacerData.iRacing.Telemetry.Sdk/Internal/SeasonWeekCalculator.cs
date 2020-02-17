using System;
using System.Collections.Generic;
using System.Linq;

namespace RacerData.iRacing.Telemetry.Sdk.Internal
{
    internal static class SeasonWeekCalculator
    {
        private class SeasonWeekInstance
        {
            public int Year { get; set; }
            public int Season { get; set; }
            public int Week { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        private static IList<SeasonWeekInstance> _seasonWeeks;
        private static IList<SeasonWeekInstance> SeasonWeeks
        {
            get
            {
                if (_seasonWeeks == null)
                {
                    _seasonWeeks = BuildSeasonWeekList();
                }

                return _seasonWeeks;
            }
        }

        public static SeasonWeek GetSeasonWeek(DateTime eventDate)
        {
            var targetWeek = SeasonWeeks.FirstOrDefault(w => w.StartDate <= eventDate && w.EndDate >= eventDate);

            return new SeasonWeek()
            {
                Year = targetWeek.Year,
                Season = targetWeek.Season,
                Week = targetWeek.Week
            };
        }

        private static IList<SeasonWeekInstance> BuildSeasonWeekList()
        {
            IList<SeasonWeekInstance> seasonWeeks = new List<SeasonWeekInstance>();

            int year = 2015;
            int season = 1;
            int week = 1;
            DateTime weekStartDate = new DateTime();
            DateTime weekEndDate = new DateTime();
            DateTime targetDate = new DateTime(2014, 12, 9);

            while (year < 2022)
            {
                while (season <= 4)
                {
                    while (week <= 13)
                    {
                        weekStartDate = targetDate.AddDays(7 * week);
                        weekEndDate = weekStartDate.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);

                        seasonWeeks.Add(new SeasonWeekInstance()
                        {
                            Year = year,
                            Season = season,
                            Week = week,
                            StartDate = weekStartDate,
                            EndDate = weekEndDate
                        });

                        week += 1;
                    }

                    targetDate = weekStartDate;
                    week = 1;
                    season += 1;
                }

                week = 1;
                season = 1;
                year += 1;
            }

            return seasonWeeks;
        }
    }
}
