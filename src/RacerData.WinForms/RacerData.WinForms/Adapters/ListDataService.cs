using System;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Ports;
using RacerData.WinForms.Data;

namespace RacerData.WinForms.Adapters
{
    class ListDataService : IListDataService
    {
        #region fields

        private readonly IResultFactory<ListDataService> _resultFactory;
        private readonly ILiveDataService _liveDataService;

        #endregion

        #region ctor

        public ListDataService(
            ILiveDataService liveDataService,
            IResultFactory<ListDataService> resultFactory)
        {
            _liveDataService = liveDataService ?? throw new ArgumentNullException(nameof(liveDataService));
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public virtual async Task<IResult<ListViewData>> GetListDataAsync()
        {
            var data = new ListViewData(3, 3);

            return await Task.FromResult(_resultFactory.Success(data));
        }

        #endregion
    }
}
