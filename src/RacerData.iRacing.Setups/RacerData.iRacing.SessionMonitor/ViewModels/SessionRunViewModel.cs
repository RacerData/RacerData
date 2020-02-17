using System;
using System.Collections.Generic;
using System.Linq;
using RacerData.iRacing.SessionMonitor.Extensions;
using RacerData.iRacing.SessionMonitor.Internal;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class SessionRunViewModel
    {
        private const Single CoreLapThreshold = 1.07F;

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public string EventType { get; set; }
        public string SessionType { get; set; }
        public int LapCount
        {
            get
            {
                return Laps.Count;
            }
        }
        public int ValidLapCount
        {
            get
            {
                return ValidLaps.Count();
            }
        }
        public int CoreLapCount
        {
            get
            {
                return CoreLaps.Count();
            }
        }
        public Single CoreLapsAverage
        {
            get
            {
                return CoreLaps.Count() == 0 ? 0 : CoreLaps.Average(l => l.LapTime);
            }
        }
        public Single CoreLapsBestLapTime
        {
            get
            {
                return BestLap != null ? BestLap.LapTime : 0F;
            }
        }
        public Single CoreLapsStdDev
        {
            get
            {
                return CoreLaps.Count() == 0 ? 0 : CoreLaps.Select(l => l.LapTime).StandardDeviation();
            }
        }
        public Single EstTenLapTime
        {
            get
            {
                return CoreLapsAverage * 10;
            }
        }
        public int SessionStartLap
        {
            get
            {
                return Laps.Count == 0 ? 0 : Laps.Min(l => l.SessionLapNumber);
            }
        }
        public int SessionEndLap
        {
            get
            {
                return Laps.Count == 0 ? 0 : Laps.Max(l => l.SessionLapNumber);
            }
        }

        public SetupViewModel Setup { get; set; } = new SetupViewModel();
        public TireSheetViewModel TireSheet { get; set; } = new TireSheetViewModel();
        public TireSheetViewModel TireSheetFromSetup { get; set; } = new TireSheetViewModel();

        public SessionLapViewModel BestLap
        {
            get
            {
                return ValidLaps.OrderBy(l => l.LapTime).FirstOrDefault();
            }
        }

        private IList<SessionLapViewModel> _laps;
        public IList<SessionLapViewModel> Laps
        {
            get
            {
                return ((List<SessionLapViewModel>)_laps).OrderBy(l => l.RunLapNumber).ToList();
            }
            set
            {
                _laps = value;
            }
        }

        public IEnumerable<SessionLapViewModel> ValidLaps
        {
            get
            {
                return Laps.Where(l => l.Status == SessionLapStatus.ValidLap);
            }
        }

        public IEnumerable<SessionLapViewModel> CoreLaps
        {
            get
            {
                Single minLapTime = BestLap != null ? BestLap.LapTime : 9999F;

                return ValidLaps.Where(l => l.LapTime <= (minLapTime + (minLapTime * CoreLapThreshold)));
            }
        }

        public SessionRunViewModel()
        {
            _laps = new SortableBindingList<SessionLapViewModel>(new List<SessionLapViewModel>());
        }
    }
}
