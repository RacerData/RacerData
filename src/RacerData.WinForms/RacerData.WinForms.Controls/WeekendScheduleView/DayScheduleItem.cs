using System;
using System.Windows.Forms;
using RacerData.WinForms.Controls.Models.WeekendScheduleView;

namespace RacerData.WinForms.Controls
{
    public partial class DayScheduleItem : UserControl
    {
        private DayScheduleModel _model;
        public DayScheduleModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                DisplaySchedule(_model);
            }
        }

        public DayScheduleItem(DayScheduleModel model)
            : this()
        {
            Model = model;
        }

        public DayScheduleItem()
        {
            InitializeComponent();
        }

        private void DayScheduleItem_Load(object sender, EventArgs e)
        {
            DisplaySchedule(Model);
        }

        protected virtual void DisplaySchedule(DayScheduleModel model)
        {
            lblDate.Text = Model.Date.ToString("dddd, MMMM d");

            tblSchedule.AutoSize = true;

            tblSchedule.Controls.Clear();
            tblSchedule.RowStyles.Clear();
            tblSchedule.RowCount = 0;

            int i = 0;
            WeekendScheduleItem lastEvent = null;
            DateTime lastModelDateTime = DateTime.MinValue;
            foreach (EventScheduleModel scheduledEvent in model.ScheduledEvents)
            {
                var item = new WeekendScheduleItem(scheduledEvent);
                item.Margin = new Padding(0);
                if (scheduledEvent.DateTime.Date == DateTime.Now.Date &&
                    scheduledEvent.DateTime > DateTime.Now &&
                    lastEvent != null &&
                    lastModelDateTime < DateTime.Now)
                {
                    lastEvent.IsActive = true;
                }
                tblSchedule.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tblSchedule.RowCount += 1;
                tblSchedule.Controls.Add(item, 0, i);
                i++;
                lastEvent = item;
                lastModelDateTime = scheduledEvent.DateTime;
            }
        }
    }
}
