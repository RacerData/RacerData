using System;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Adapters
{
    class GraphDataService : IGraphDataService
    {
        #region fields

        private readonly IResultFactory<GraphDataService> _resultFactory;
        private readonly ILiveDataService _liveDataService;

        #endregion

        #region ctor

        public GraphDataService(
            ILiveDataService liveDataService,
            IResultFactory<GraphDataService> resultFactory)
        {
            _liveDataService = liveDataService ?? throw new ArgumentNullException(nameof(liveDataService));
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public virtual async Task<IResult> GetGraphDataAsync()
        {
            return await Task.FromResult(_resultFactory.Success());
        }

        #endregion
    }
}
