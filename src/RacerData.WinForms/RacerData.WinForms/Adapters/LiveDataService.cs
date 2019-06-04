using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.Data;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Adapters
{
    class LiveDataService : ILiveDataService
    {
        #region fields

        private readonly IResultFactory<LiveDataService> _resultFactory;

        #endregion

        #region ctor

        public LiveDataService(IResultFactory<LiveDataService> resultFactory)
        {
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public virtual async Task<IResult<Dictionary<int, IDictionary<int, LiveData>>>> GetLiveDataAsync(IList<LiveDataSource> dataSources)
        {
            var dataRows = new Dictionary<int, IDictionary<int, LiveData>>();

            var rowCount = 5;
            var columnCount = dataSources.Count;

            for (int r = 0; r < rowCount; r++)
            {
                var dataRow = new Dictionary<int, LiveData>();

                for (int c = 0; c < columnCount; c++)
                {
                    dataRow.Add(c, new LiveData() { Source = dataSources[c], Value = $"{r}:{c}" });
                }

                dataRows.Add(r, dataRow);
            }

            return await Task.FromResult(_resultFactory.Success(dataRows));
        }

        #endregion
    }
}
