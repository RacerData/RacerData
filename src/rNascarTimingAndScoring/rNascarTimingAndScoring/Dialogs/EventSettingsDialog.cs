﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using NascarApi.Data.Models;
using NascarApi.Models;
using rNascarTimingAndScoring.Factories;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.Dialogs
{
    public partial class EventSettingsDialog : Form
    {
        #region fields

        private IList<ScheduledEvent> _scheduledEvents { get; set; }

        #endregion

        #region properties

        public EventSettings EventSettings { get; set; }

        public ILog Log { get; set; }

        #endregion

        #region ctor

        public EventSettingsDialog(ILog log)
            : this()
        {

            this.Log = log;
        }

        public EventSettingsDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            if (Log != null)
                Log.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show($"{message}: {ex.Message}");
        }

        protected virtual void PopulateDisplayControls()
        {
            var eventFactory = new EventFactory();

            _scheduledEvents = eventFactory.BuildFullSchedule();

            var series = BuildDefaultSeriesList();
            cboSeries.DisplayMember = "name";
            cboSeries.ValueMember = "id";
            cboSeries.DataSource = series;

            var activities = BuildDefaultActivityList();
            cboActivities.DisplayMember = "name";
            cboActivities.ValueMember = "id";
            cboActivities.DataSource = activities;

            cboActivities.SelectedIndex = 0;

            cboSession.DisplayMember = "name";
            cboSession.ValueMember = "id";

            txtSeason.Text = DateTime.Now.Year.ToString();
        }

        protected virtual IList<SeriesModel> BuildDefaultSeriesList()
        {
            var defaultSeriesList = new List<SeriesModel>();

            defaultSeriesList.Add(new SeriesModel()
            {
                id = 1,
                name = "Monster Energy Cup Series"
            });
            defaultSeriesList.Add(new SeriesModel()
            {
                id = 2,
                name = "XFinity Series"
            });
            defaultSeriesList.Add(new SeriesModel()
            {
                id = 3,
                name = "Gander Outdoors Truck Series"
            });
            defaultSeriesList.Add(new SeriesModel()
            {
                id = 999,
                name = "Other (K&N)"
            });

            return defaultSeriesList;
        }

        protected virtual IList<ActivityType> BuildDefaultActivityList()
        {
            var activities = new List<ActivityType>();

            activities.Add(new ActivityType()
            {
                id = 1,
                name = "Practice",
                sessions = new List<SessionType>()
                {
                    new SessionType()
                                {
                                    id = 1,
                                    name = "First Practice"
                                },
                    new SessionType()
                                {
                                    id = 2,
                                    name = "Second Practice"
                                },
                    new SessionType()
                                {
                                    id = 3,
                                    name = "Final Practice"
                                }
                }
            });

            activities.Add(new ActivityType()
            {
                id = 2,
                name = "Qualifying",
                sessions = new List<SessionType>()
                {
                    new SessionType()
                                {
                                    id = 1,
                                    name = "First Round"
                                },
                    new SessionType()
                                {
                                    id = 2,
                                    name = "Second Round"
                                },
                    new SessionType()
                                {
                                    id = 3,
                                    name = "Third Round"
                                }
                }
            });

            activities.Add(new ActivityType()
            {
                id = 3,
                name = "Race",
                sessions = new List<SessionType>()
                {
                    new SessionType()
                                {
                                    id = 1,
                                    name = "First Stage"
                                },
                    new SessionType()
                                {
                                    id = 2,
                                    name = "Second Stage"
                                },
                    new SessionType()
                                {
                                    id = 3,
                                    name = "Third Stage"
                                }
                }
            });

            return activities;
        }

        protected virtual void DisplayEventSettings(EventSettings settings)
        {
            if (settings == null)
                return;

            cboSeries.SelectedValue = settings.seriesId;
            cboActivities.SelectedValue = settings.activityId;
            cboSession.SelectedValue = settings.sessionId;

            txtSeason.Text = settings.season.ToString();
            txtEventId.Text = settings.eventId.ToString();
        }

        protected virtual void UpdateEventSettings()
        {
            if (EventSettings == null)
                EventSettings = new EventSettings();

            EventSettings.seriesId = (int)cboSeries.SelectedValue;
            EventSettings.activityId = (int)cboActivities.SelectedValue;
            EventSettings.sessionId = (int)cboSession.SelectedValue;

            EventSettings.season = Int32.Parse(txtSeason.Text);
            EventSettings.eventId = Int32.Parse(txtEventId.Text);
        }

        #endregion

        #region private

        private void EventSettingsView_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateDisplayControls();

                DisplayEventSettings(EventSettings);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading event settings dialog", ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateEventSettings();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error saving event settings dialog", ex);
            }
        }

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboSession.DataSource = null;

                if (cboActivities.SelectedItem == null)
                    return;

                var selectedActivity = (ActivityType)cboActivities.SelectedItem;

                cboSession.DisplayMember = "name";
                cboSession.ValueMember = "id";
                cboSession.DataSource = selectedActivity.sessions;
                cboSession.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting activity", ex);
            }
        }

        private void cboSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboEvents.DataSource = null;

                if (cboSeries.SelectedItem == null)
                    return;

                var selectedSeries = (SeriesModel)cboSeries.SelectedItem;

                cboEvents.DisplayMember = "name";
                cboEvents.ValueMember = "id";
                cboEvents.DataSource = _scheduledEvents.Where(se => se.series == selectedSeries.id).ToList();
                cboEvents.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting series", ex);
            }
        }

        private void cboEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtEventId.Clear();

                if (cboEvents.SelectedItem == null)
                    return;

                var selectedEvent = (ScheduledEvent)cboEvents.SelectedItem;

                txtEventId.Text = selectedEvent.id.ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error selecting event", ex);
            }
        }

        #endregion

        #region private classes

        protected class SeriesType
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        protected class ActivityType
        {
            public int id { get; set; }
            public string name { get; set; }
            public IList<SessionType> sessions { get; set; } = new List<SessionType>();
        }

        protected class SessionType
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        #endregion
    }
}
