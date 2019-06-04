using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.Commmon.Results;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Controls
{
    public class WeekendScheduleViewModel
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region fields

        private Timer _timer = new Timer();
        private readonly IWeekendScheduleService _weekendScheduleService;

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
                OnPropertyChanged(nameof(WeekendSchedule));
            }
        }

        #endregion

        #region ctor

        public WeekendScheduleViewModel(
            IWeekendScheduleService weekendScheduleService)
        {
            _weekendScheduleService = weekendScheduleService ?? throw new ArgumentNullException(nameof(weekendScheduleService));

            _weekendSchedule = new WeekendSchedule();

            _timer.Interval = 120000;
            _timer.Tick += _timer_Tick;

            _timer.Start();
        }

        #endregion

        #region public

        public virtual async Task GetWeekendScheduleCommandAsync()
        {
            var result = await _weekendScheduleService.GetWeekendScheduleAsync();

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            WeekendSchedule = result.Value;
        }

        private async void _timer_Tick(object sender, EventArgs e)
        {
            await GetWeekendScheduleCommandAsync();
        }

        #endregion
    }
}
