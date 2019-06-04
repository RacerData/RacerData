using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.WinForms.Ports;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public class StaticViewModel
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

        private readonly IStaticDataService _staticDataService;
        private readonly StaticViewInfo _viewInfo;

        #endregion

        #region properties

        private IDictionary<int, string> _staticData;
        public IDictionary<int, string> StaticData

        {
            get
            {
                return _staticData;
            }
            set
            {
                _staticData = value;
                OnPropertyChanged(nameof(StaticData));
            }
        }

        private IList<StaticField> _fields;
        public IList<StaticField> Fields

        {
            get
            {
                return _fields;
            }
            set
            {
                _fields = value;
                OnPropertyChanged(nameof(Fields));
            }
        }

        #endregion

        #region ctor

        public StaticViewModel(
            StaticViewInfo viewinfo,
            IStaticDataService staticDataService)
        {
            _viewInfo = viewinfo ?? throw new ArgumentNullException(nameof(viewinfo));
            _staticDataService = staticDataService ?? throw new ArgumentNullException(nameof(staticDataService));

            _staticData = new Dictionary<int, string>();
        }

        #endregion

        #region public

        public virtual async Task GetStaticDataCommandAsync()
        {
            var result = await _staticDataService.GetStaticDataAsync(Fields);

            if (!result.IsSuccessful())
            {
                throw result.Exception;
            }

            StaticData = result.Value;
        }

        public virtual void GetFieldsCommand()
        {
            Fields = _viewInfo.Fields;
        }

        #endregion
    }
}
