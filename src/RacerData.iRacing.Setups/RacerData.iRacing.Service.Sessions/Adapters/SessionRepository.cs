using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RacerData.iRacing.Service.Sessions.Data;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions.Adapters
{
    internal class SessionRepository : ISessionRepository
    {
        #region consts
        public int NoTrackStateId = 11;
        public int VariableTimeOfDayId = 8;
        #endregion

        #region fields

        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public SessionRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public IQueryable<SessionListView> GetSessionsQuery()
        {
            var sessionsList = _context.SessionListViews
                .Include("Run")
                .AsQueryable();

            return _mapper.ProjectTo<SessionListView>(sessionsList);
        }

        public SessionTime GetSessionTimeOfDay(TimeSpan timeOfDay)
        {
            var timeModel = _context.SessionTimes.FirstOrDefault(t =>
                t.StartTime.CompareTo(timeOfDay) <= 0
                && t.EndTime.CompareTo(timeOfDay) >= 0);

            return _mapper.Map<SessionTime>(timeModel);
        }
        public SessionTime GetVariableSessionTimeOfDay()
        {
            var timeModel = _context.SessionTimes.Find(VariableTimeOfDayId);

            return _mapper.Map<SessionTime>(timeModel);
        }

        public SessionTrackState GetSessionTrackState(string trackState)
        {
            SessionTrackStateModel trackStateModel = null;

            if (String.IsNullOrEmpty(trackState))
                trackStateModel = _context.SessionTrackStates.Find(NoTrackStateId);
            else
            {
                //trackStateModel = _context.SessionTrackStates.FirstOrDefault(t =>
                //  t.TrackState.ToUpper() == trackState.ToUpper());

                trackStateModel = _context.SessionTrackStates.FirstOrDefault(t =>
                    String.Compare(t.TrackState, trackState, true) == 0);
            }

            return _mapper.Map<SessionTrackState>(trackStateModel);
        }

        #endregion
    }
}
