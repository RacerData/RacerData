using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RacerData.iRacing.Service.Sessions.Data;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions.Adapters
{
    internal class TrackRepository : ITrackRepository
    {
        #region fields

        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public TrackRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public async Task<IList<Track>> GetTracksAsync()
        {
            var trackModels = await _context.Tracks.ToListAsync();

            IList<Track> results = _mapper.Map<IList<Track>>(trackModels);

            return results;
        }

        public async Task<Track> GetTrackAsync(long id)
        {
            var trackModel = await _context.Tracks.Where(t => t.Id == id).AsNoTracking().FirstOrDefaultAsync();

            if (trackModel == null)
            {
                return null;
            }

            return _mapper.Map<Track>(trackModel);
        }

        public async Task<Track> InsertTrackAsync(Track track)
        {
            if (track == null)
            {
                throw new ArgumentException(nameof(track));
            }

            var trackModel = _mapper.Map<TrackModel>(track);

            _context.Tracks.Add(trackModel);

            await _context.SaveChangesAsync();

            return await GetTrackAsync(trackModel.Id);
        }

        public async Task<Track> UpdateTrackAsync(Track track)
        {
            if (track == null)
            {
                throw new ArgumentException(nameof(track));
            }

            var trackModel = await _context.Tracks.FindAsync(track.Id);

            if (trackModel == null)
            {
                throw new ArgumentException(nameof(track.Id));
            }

            _mapper.Map<Track, TrackModel>(track, trackModel);

            await _context.SaveChangesAsync();

            return await GetTrackAsync(track.Id);
        }

        #endregion
    }
}
