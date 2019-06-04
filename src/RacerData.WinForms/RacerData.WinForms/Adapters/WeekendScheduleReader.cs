using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using RacerData.WinForms.Models;
using RacerData.WinForms.Data;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Controls.Adapters
{
    public class WeekendScheduleReader : IWeekendScheduleReader
    {
        #region consts

        private const string MasterScheduleUrl = @"https://www.nascar.com/weekend-schedule/";

        #endregion

        #region public

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

        #endregion

        #region protected

        protected virtual async Task<IDocument> GetDocumentAsync(string masterScheduleUrl)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(masterScheduleUrl);
            return document;
        }

        protected virtual PageReferenceModel GetCurrentScheduleUrl(IDocument document)
        {
            PageReferenceModel result = new PageReferenceModel();

            var elements = document.All.Where(m =>
               m.HasAttribute("class") &&
               m.GetAttribute("class")
                .Contains("search-news-item")
            );

            result.Url = elements
                .ElementAt(0)
                .Children[0]
                .GetAttribute("Href");

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

                            if (DateTime.TryParseExact(
                                eventTime, 
                                formats,
                                System.Globalization.CultureInfo.CurrentCulture,
                                System.Globalization.DateTimeStyles.AssumeLocal, 
                                out eventDateTime))
                            {

                                model.DateTime = new DateTime(
                                    scheduleDate.Year,
                                    scheduleDate.Month,
                                    scheduleDate.Day,
                                    eventDateTime.Hour,
                                    eventDateTime.Minute,
                                    eventDateTime.Second);
                            }
                            else if (DateTime.TryParse(
                                eventTime,
                                System.Globalization.CultureInfo.CurrentCulture,
                                System.Globalization.DateTimeStyles.AssumeLocal,
                                out eventDateTime))
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
                            if (titleText.Contains("(Also"))
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

        #endregion
    }
}
