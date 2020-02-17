using System;
using System.Threading.Tasks;
using RacerData.Commmon.Results;
using RacerData.Common.Results;
using RacerData.Nascar.Pages.Models;
using RacerData.Nascar.Pages.Ports;

namespace RacerData.Nascar.Pages.Adapters
{
    class WeekendScheduleService : IWeekendScheduleService
    {
        #region fields 

        private readonly IWeekendScheduleReader _weekendScheduleReader;
        private readonly IResultFactory<WeekendScheduleService> _resultFactory;

        #endregion

        #region ctor

        public WeekendScheduleService(
            IWeekendScheduleReader weekendScheduleReader,
            IResultFactory<WeekendScheduleService> resultFactory)
        {
            _weekendScheduleReader = weekendScheduleReader ?? throw new ArgumentNullException(nameof(weekendScheduleReader));
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public async Task<IResult<WeekendSchedule>> GetWeekendScheduleAsync()
        {
            try
            {
                var schedule = await _weekendScheduleReader.GetScheduleAsync();

                return await Task.FromResult(_resultFactory.Success(schedule));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(_resultFactory.Exception<WeekendSchedule>(ex));
            }
        }

        #endregion
    }
}
