using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Ports;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls.Adapters
{
    public class StaticDataService : IStaticDataService
    {
        #region fields

        private readonly IResultFactory<StaticDataService> _resultFactory;

        #endregion

        #region ctor

        public StaticDataService(IResultFactory<StaticDataService> resultFactory)
        {
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public virtual async Task<IResult<IDictionary<int, string>>> GetStaticDataAsync(IList<StaticField> fields)
        {
            IDictionary<int, string> dataValues = new Dictionary<int, string>();

            foreach (StaticField field in fields)
            {
                dataValues.Add(field.Index, $"[{field.Name}]");
            }

            return await Task.FromResult(_resultFactory.Success(dataValues));
        }

        #endregion
    }
}
