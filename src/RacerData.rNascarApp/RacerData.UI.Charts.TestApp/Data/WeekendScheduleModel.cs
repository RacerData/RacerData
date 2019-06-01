using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

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

    public class DayScheduleModel
    {
        public DateTime Date { get; set; }
        public IList<EventScheduleModel> ScheduledEvents { get; set; }

        public DayScheduleModel()
        {
            ScheduledEvents = new List<EventScheduleModel>();
        }
    }

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

    public class WeekendScheduleReader
    {
        private const string MasterScheduleUrl = @"https://www.nascar.com/weekend-schedule/";

        public async Task<WeekendSchedule> GetScheduleAsync()
        {
            // get master weekend schedule page
            IDocument masterScheduleDocument = await GetDocumentAsync(MasterScheduleUrl);

            // parse link to current schedule
            var currentSchedulePage = GetCurrentScheduleUrl(masterScheduleDocument);

            // get current schedule page
            var currentScheduleDocument = await GetDocumentAsync(currentSchedulePage.Url);

            // build list
            var schedule = BuildScheduleModels(currentScheduleDocument);

            return schedule;
        }

        protected virtual async Task<IDocument> GetDocumentAsync(string masterScheduleUrl)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(masterScheduleUrl);
            return document;
        }

        protected virtual PageReference GetCurrentScheduleUrl(IDocument document)
        {
            PageReference result = new PageReference();

            try
            {
                var elements = document.All.Where(m =>
                   m.HasAttribute("class") &&
                   m.GetAttribute("class")
                    .Contains("search-news-item")
                );

                result.Url = elements
                    .ElementAt(0)
                    .Children[0]
                    .GetAttribute("Href");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        protected virtual WeekendSchedule BuildScheduleModels(IDocument document)
        {
            var schedule = new WeekendSchedule();
            
            try
            {
                schedule.Name = document.Head.Children[8].InnerHtml;

                var elements = document.All.Where(m =>
                   m.HasAttribute("class") &&
                   m.GetAttribute("class")
                    .Contains("day-schedule-container")
                );

                foreach (IElement dayElement in elements)
                {
                    var activityDateTime = dayElement.GetElementsByClassName("day-schedule-header")[0].InnerHtml;

                    var scheduleDate = DateTime.Parse(activityDateTime).Date;

                    var daySchedule = new DayScheduleModel();

                    daySchedule.Date = scheduleDate;

                    var dayEvents = dayElement.GetElementsByClassName("weekend-schedule-table");

                    foreach (IElement eventElement in dayEvents)
                    {
                        var timeElements = eventElement.GetElementsByClassName("event-time");

                        var titleElements = eventElement.GetElementsByClassName("event-title");

                        var seriesLogoElements = eventElement.GetElementsByClassName("series-logo");

                        for (int i = 0; i < seriesLogoElements.Count(); i++)
                        {
                            var model = new EventScheduleModel();

                            var eventTime = timeElements[i]
                                .InnerHtml
                                .Replace(" ET", "")
                                .Replace("a.m.", "AM")
                                .Replace("p.m.", "PM");

                            DateTime eventDateTime = scheduleDate;

                            string[] formats = { "h:mm tt", "hh:mm tt", "h tt" };

                            if (DateTime.TryParseExact(eventTime, formats,
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None, out eventDateTime))
                            {

                                model.DateTime = new DateTime(
                                    scheduleDate.Year,
                                    scheduleDate.Month,
                                    scheduleDate.Day,
                                    eventDateTime.Hour,
                                    eventDateTime.Minute,
                                    eventDateTime.Second);
                            }

                            var titleText = titleElements[i].InnerHtml;
                            if (titleText.Contains('('))
                                titleText = titleText.Substring(0, titleText.IndexOf('('));

                            model.Title = titleText;

                            var logoElement = seriesLogoElements[i].Children[0].Attributes["src"].Value;
                            model.LogoUrl = logoElement;

                            var seriesElement = seriesLogoElements[i].Children[0].Attributes["alt"].Value;
                            model.Series = seriesElement;

                            daySchedule.ScheduledEvents.Add(model);
                        }
                    }

                    schedule.DaySchedules.Add(daySchedule);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return schedule;
        }

        protected virtual string GetSeries(IElement eventElement)
        {
            //<table class="weekend-schedule-table">
            //  <tr class="series-gander-outdoors-truck-series" role="row">
            //  <td class="series-logo" tabindex="0" role="cell"><img src = 'https://www.nascar.media/wp-content/uploads/sites/7/2018/12/NGOTS-Logo-3.png' alt='Gander Outdoors Truck Series' /></td>
            //  <td class="event-time" tabindex="0" role="cell">4:05 p.m.ET</td>
            //  <td class="event-title" tabindex="0" role="cell">First practice</td>
            //  <td class="event-broadcast" tabindex="0" role="cell">
            //    <a href = "https://www.nascar.com/results/race_center/2019/gander-outdoors-truck-series/vankor-350/stn/practice1/" title="Results">Results</a>    </td>
            //</tr>
            //  <tr class="series-gander-outdoors-truck-series" role="row">
            //  <td class="series-logo" tabindex="0" role="cell"><img src = 'https://www.nascar.media/wp-content/uploads/sites/7/2018/12/NGOTS-Logo-3.png' alt='Gander Outdoors Truck Series' /></td>
            //  <td class="event-time" tabindex="0" role="cell">6:05 p.m.ET</td>
            //  <td class="event-title" tabindex="0" role="cell">Final Practice</td>
            //  <td class="event-broadcast" tabindex="0" role="cell">
            //    <a href = "https://www.nascar.com/results/race_center/2019/gander-outdoors-truck-series/vankor-350/stn/practice2/" title="Results">Results</a>    </td>
            //</tr>
            //</table>

            // series-nascar-general
            // series-xfinity-series
            // series-monster-energy-nascar-cup-series
            // series-gander-outdoors-truck-series

            return "";
        }

        protected class PageReference
        {
            public string Url { get; set; }
            public string Name { get; set; }
        }
    }
}
