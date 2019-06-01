using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Data;

namespace rNascarApp.UI.Controls
{
    public partial class ScheduleView<TModel> : UserControl, IWeekendScheduleView<TModel>
    {
        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        private Timer _timer = new Timer();
        private ImageList _seriesImages = new ImageList();

        private TModel _model;
        public TModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                PopulateScheduleDisplay(_model as WeekendSchedule);
            }
        }

        public ScheduleView()
        {
            InitializeComponent();

            _timer.Interval = 120000;
            _timer.Tick += _timer_Tick;
        }

        private async void _timer_Tick(object sender, EventArgs e)
        {
            await UpdateScheduleAsync();
        }

        protected virtual void PopulateScheduleDisplay(WeekendSchedule weekendSchedule)
        {
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

        private async void ScheduleView_Load(object sender, EventArgs e)
        {
            await UpdateScheduleAsync();
        }

        protected virtual async Task UpdateScheduleAsync()
        {
            WeekendScheduleReader reader = new WeekendScheduleReader();
            var schedule = await reader.GetScheduleAsync();

            PopulateScheduleDisplay(schedule);
        }
    }
}
