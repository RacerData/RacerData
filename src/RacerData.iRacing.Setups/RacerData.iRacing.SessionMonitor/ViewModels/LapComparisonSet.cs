using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    class LapComparisonSet
    {
        public IList<SessionLapViewModel> FirstRunLaps { get; set; }
        public IList<SessionLapViewModel> SecondRunLaps { get; set; }

        public IList<LapComparison> LapsCompared
        {
            get
            {
                var lapsCompared = new List<LapComparison>();

                int maxLapCount = FirstRunLaps == null && SecondRunLaps == null ?
                    0 :
                    FirstRunLaps != null && SecondRunLaps == null ? FirstRunLaps.Count :
                    FirstRunLaps == null && SecondRunLaps != null ? SecondRunLaps.Count :
                    FirstRunLaps.Count >= SecondRunLaps.Count ? FirstRunLaps.Count : SecondRunLaps.Count;

                float? runDelta = 0F;

                for (int i = 0; i < maxLapCount; i++)
                {
                    float? firstLapTime = FirstRunLaps != null && FirstRunLaps.Count > i ? FirstRunLaps[i].LapTime : (float?)null;
                    float? secondLapTime = SecondRunLaps != null && SecondRunLaps.Count > i ? SecondRunLaps[i].LapTime : (float?)null;
                    float? lapDelta = firstLapTime.HasValue && secondLapTime.HasValue ? secondLapTime - firstLapTime : (float?)null;
                    runDelta = lapDelta.HasValue ? runDelta + lapDelta : (float?)null;

                    lapsCompared.Add(new LapComparison()
                    {
                        LapNumber = i + 1,
                        FirstLapTime = firstLapTime,
                        SecondLapTime = secondLapTime,
                        LapDelta = lapDelta,
                        RunDelta = runDelta
                    });
                }

                return lapsCompared;
            }
        }
    }
}
