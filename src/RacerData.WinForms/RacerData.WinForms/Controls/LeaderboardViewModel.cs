using System;
using System.ComponentModel;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.WinForms.Ports;
using RacerData.WinForms.Data;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public class LeaderboardViewModel
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

        private readonly IListDataService _listDataService;
        private readonly LeaderboardViewInfo _viewInfo;

        #endregion

        #region properties

        private LeaderboardViewDefinition _leaderboardViewDefinition;
        public LeaderboardViewDefinition LeaderboardViewDefinition
        {
            get
            {
                return _leaderboardViewDefinition;
            }
            set
            {
                _leaderboardViewDefinition = value;
                OnPropertyChanged(nameof(LeaderboardViewDefinition));
            }
        }

        private ListViewData _listData;
        public ListViewData ListData
        {
            get
            {
                return _listData;
            }
            set
            {
                _listData = value;
                OnPropertyChanged(nameof(ListData));
            }
        }

        #endregion

        #region ctor

        public LeaderboardViewModel(
            LeaderboardViewInfo viewinfo,
            IListDataService listDataService)
        {
            _viewInfo = viewinfo ?? throw new ArgumentNullException(nameof(viewinfo));
            _listDataService = listDataService ?? throw new ArgumentNullException(nameof(listDataService));
        }

        #endregion

        #region public

        public virtual void GetListDefinitionCommand()
        {
            LeaderboardViewDefinition = _viewInfo.LeaderboardViewDefinition;
        }

        public virtual async Task GetListDataCommandAsync()
        {
            var result = await _listDataService.GetListDataAsync();

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            ListData = result.Value;
        }

        #endregion
    }
}
