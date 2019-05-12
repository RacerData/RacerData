using System.Collections.Generic;
using System.ComponentModel;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;

namespace RacerData.rNascarApp.Models
{
    public class ViewDataContext
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        private LiveFeedData _liveFeedData = new LiveFeedData();
        public LiveFeedData LiveFeedData
        {
            get
            {
                return _liveFeedData;
            }
            set
            {
                _liveFeedData = value;
                OnPropertyChanged(nameof(LiveFeedData));
            }
        }

        private IList<LivePitData> _livePitData = new List<LivePitData>();
        public IList<LivePitData> LivePitData
        {
            get
            {
                return _livePitData;
            }
            set
            {
                _livePitData = value;
                OnPropertyChanged(nameof(LivePitData));
            }
        }

        private IList<LivePointsData> _livePointsData = new List<LivePointsData>();
        public IList<LivePointsData> LivePointsData
        {
            get
            {
                return _livePointsData;
            }
            set
            {
                _livePointsData = value;
                OnPropertyChanged(nameof(LivePointsData));
            }
        }

        private IList<LiveFlagData> _liveFlagData = new List<LiveFlagData>();
        public IList<LiveFlagData> LiveFlagData
        {
            get
            {
                return _liveFlagData;
            }
            set
            {
                _liveFlagData = value;
                OnPropertyChanged(nameof(LiveFlagData));
            }
        }

        private IList<LiveQualifyingData> _liveQualifyingData = new List<LiveQualifyingData>();
        public IList<LiveQualifyingData> LiveQualifyingData
        {
            get
            {
                return _liveQualifyingData;
            }
            set
            {
                _liveQualifyingData = value;
                OnPropertyChanged(nameof(LiveQualifyingData));
            }
        }

        private LapTimeData _lapTimeData = new LapTimeData();
        public LapTimeData LapTimeData
        {
            get
            {
                return _lapTimeData;
            }
            set
            {
                _lapTimeData = value;
                OnPropertyChanged(nameof(LapTimeData));
            }
        }

        private LapAverageData _lapAverageData = new LapAverageData();
        public LapAverageData LapAverageData
        {
            get
            {
                return _lapAverageData;
            }
            set
            {
                _lapAverageData = value;
                OnPropertyChanged(nameof(LapAverageData));
            }
        }

        #endregion

    }
}
