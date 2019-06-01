﻿using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Data;
using rNascarApp.UI.Internal;

namespace rNascarApp.UI.Controls
{
    public partial class WeekendScheduleView : UserControl, IWeekendScheduleView
    {
        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        #endregion

        #region fields

        private Timer _timer = new Timer();

        #endregion

        #region properties

        private WeekendSchedule _weekendSchedule;
        public WeekendSchedule WeekendSchedule
        {
            get
            {
                return _weekendSchedule;
            }
            set
            {
                _weekendSchedule = value;
                PopulateScheduleDisplay(_weekendSchedule);
            }
        }

        #endregion

        #region ctor

        public WeekendScheduleView()
        {
            InitializeComponent();

            _timer.Interval = 120000;
            _timer.Tick += _timer_Tick;
        }

        #endregion

        #region protected

        protected virtual void PopulateScheduleDisplay(WeekendSchedule weekendSchedule)
        {
            if (weekendSchedule == null)
                return;

            if (weekendSchedule is WeekendSchedule)
            {
                WeekendSchedule schedule = weekendSchedule as WeekendSchedule;

                OnSetViewHeaderRequest(schedule.Name);

                tblSchedule.AutoSize = true;

                tblSchedule.Controls.Clear();
                tblSchedule.RowStyles.Clear();
                tblSchedule.RowCount = 0;
                tblSchedule.ColumnStyles.Clear();
                tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tblSchedule.ColumnCount = 1;

                int i = 0;
                foreach (var daySchedule in schedule.DaySchedules.OrderBy(e => e.Date).ToList())
                {
                    var item = new DayScheduleItem(daySchedule);
                    item.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    item.Margin = new Padding(0);
                    item.Dock = DockStyle.Fill;
                    tblSchedule.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tblSchedule.RowCount += 1;
                    tblSchedule.Controls.Add(item, 0, i);
                    i++;
                }
            }
        }

        protected virtual async Task UpdateScheduleAsync()
        {
            WeekendScheduleReader reader = new WeekendScheduleReader();
            var schedule = await reader.GetScheduleAsync();

            PopulateScheduleDisplay(schedule);
        }

        #endregion

        #region private

        private async void ScheduleView_Load(object sender, EventArgs e)
        {
            await UpdateScheduleAsync();
        }

        private async void _timer_Tick(object sender, EventArgs e)
        {
            await UpdateScheduleAsync();
        }

        #endregion
    }
}