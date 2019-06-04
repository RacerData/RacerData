using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Controls.Adapters
{
    class SeriesService : ISeriesService
    {
        #region fields

        private readonly List<SeriesModel> _seriesList;
        private readonly IResultFactory<SeriesService> _resultFactory;

        #endregion

        #region ctor

        public SeriesService(IResultFactory<SeriesService> resultFactory)
        {
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));

            _seriesList = new List<SeriesModel>()
            {
                new SeriesModel()
                {
                    Id=1,
                    Name = "Monster Energy NASCAR Cup Series",
                    Abbreviation="MENCS"
                },
                new SeriesModel()
                {
                    Id=2,
                    Name = "NASCAR XFinity Series",
                    Abbreviation="XFinity"
                },
                new SeriesModel()
                {
                    Id=3,
                    Name = "NASCAR Gander Outdoors Truck Series",
                    Abbreviation="NGOTS"
                },
                new SeriesModel()
                {
                    Id=9999,
                    Name = "Other",
                    Abbreviation="Other"
                }
            };
        }

        #endregion

        #region public

        public async Task<IResult<SeriesModel>> GetSeriesAsync(int seriesId)
        {
            return await Task.FromResult(_resultFactory.Success(_seriesList.FirstOrDefault(s => s.Id == seriesId)));
        }

        public async Task<IResult<IList<SeriesModel>>> GetSeriesListAsync()
        {
            return await Task.FromResult(_resultFactory.Success(_seriesList.ToList()));
        }

        #endregion
    }
}
