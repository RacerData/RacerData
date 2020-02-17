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
    internal class TelemetryFileInfoRepository : ITelemetryFileInfoRepository
    {
        #region fields

        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public TelemetryFileInfoRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public IQueryable<TelemetryFileInfo> Search(TelemetryFileInfoSearch criteria)
        {
            var telemetryModels = _context.TelemetryFileInfos.
                Where(t => t.Year == criteria.Year && t.Vehicle == criteria.Vehicle & t.IsProcessed == false && String.IsNullOrEmpty(t.Comments));

            IQueryable<TelemetryFileInfo> results = _mapper.ProjectTo<TelemetryFileInfo>(telemetryModels);

            return results;
        }

        public async Task<IList<TelemetryFileInfo>> GetTelemetryFileInfosAsync()
        {
            var telemetryModels = await _context.TelemetryFileInfos.ToListAsync();

            IList<TelemetryFileInfo> results = _mapper.Map<IList<TelemetryFileInfo>>(telemetryModels);

            return results;
        }

        public async Task<IList<TelemetryFileInfo>> GetTelemetryFileInfosAsync(int skip, int take)
        {
            var telemetryModels = await _context.TelemetryFileInfos.ToListAsync();

            IList<TelemetryFileInfo> results = _mapper.Map<IList<TelemetryFileInfo>>(telemetryModels);

            return results;
        }

        public IQueryable<TelemetryFileInfo> GetTelemetryFileInfoQuery()
        {
            return _mapper.ProjectTo<TelemetryFileInfo>(_context.TelemetryFileInfos);
        }

        public int GetTelemetryFileInfosCountAsync()
        {
            return _context.TelemetryFileInfos.Count();
        }
        public int GetUnprocessedTelemetryFileInfosCountAsync()
        {
            return _context.TelemetryFileInfos.Where(t => t.IsProcessed == false).Count();
        }

        public void MarkAsProcessed(long id)
        {
            var existing = _context.TelemetryFileInfos
                   .Where(p => p.Id == id)
                   .SingleOrDefault();

            if (existing != null)
            {
                existing.IsProcessed = true;

                _context.SaveChanges();
            }
        }

        public void MarkAsErrored(long id, Exception ex)
        {
            var existing = _context.TelemetryFileInfos
                   .Where(p => p.Id == id)
                   .SingleOrDefault();

            if (existing != null)
            {
                existing.Comments += ex.Message + "\r\n";

                _context.SaveChanges();
            }
        }

        public async Task<IList<TelemetryFileInfo>> GetUnprocessedTelemetryFileInfosAsync(int skip, int take)
        {
            var telemetryModels = await _context.TelemetryFileInfos.Where(t => t.IsProcessed == false).Skip(skip).Take(take).ToListAsync();

            IList<TelemetryFileInfo> results = _mapper.Map<IList<TelemetryFileInfo>>(telemetryModels);

            return results;
        }

        public async Task<TelemetryFileInfo> GetTelemetryFileInfoAsync(long id)
        {
            var telemetryModel = await _context.TelemetryFileInfos.FindAsync(id);

            if (telemetryModel == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _mapper.Map<TelemetryFileInfo>(telemetryModel);
        }

        public TelemetryFileInfo GetTelemetryFileInfoAsync(string fullPath)
        {
            var telemetryModel = _context.TelemetryFileInfos.Where(t => t.FullPath == fullPath).SingleOrDefault();

            if (telemetryModel == null)
            {
                return null;
            }

            return _mapper.Map<TelemetryFileInfo>(telemetryModel);
        }

        public async Task<TelemetryFileInfo> InsertTelemetryFileInfoAsync(TelemetryFileInfo telemetry)
        {
            TelemetryFileInfo fileInfo = null;

            try
            {
                if (telemetry == null)
                {
                    throw new ArgumentNullException(nameof(telemetry));
                }

                TelemetryFileInfoModel telemetryModel = await _context.TelemetryFileInfos.FirstOrDefaultAsync((t => t.Name == telemetry.Name));

                if (telemetryModel != null)
                {
                    telemetryModel = _mapper.Map<TelemetryFileInfo, TelemetryFileInfoModel>(telemetry, telemetryModel);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    telemetry = UpdateSeason(telemetry);

                    telemetryModel = _mapper.Map<TelemetryFileInfoModel>(telemetry);

                    _context.TelemetryFileInfos.Add(telemetryModel);

                    await _context.SaveChangesAsync();
                }

                fileInfo = await GetTelemetryFileInfoAsync(telemetryModel.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

            return fileInfo;
        }

        public async Task<TelemetryFileInfo> UpdateTelemetryFileInfoAsync(TelemetryFileInfo telemetry)
        {
            if (telemetry == null)
            {
                throw new ArgumentException(nameof(telemetry));
            }

            var telemetryModel = await _context.TelemetryFileInfos.FindAsync(telemetry.Id);

            if (telemetryModel == null)
            {
                throw new ArgumentException(nameof(telemetry.Id));
            }

            telemetryModel = _mapper.Map<TelemetryFileInfo, TelemetryFileInfoModel>(telemetry, telemetryModel);

            await _context.SaveChangesAsync();

            return await GetTelemetryFileInfoAsync(telemetry.Id);
        }

        protected virtual TelemetryFileInfo UpdateSeason(TelemetryFileInfo telemetry)
        {
            var raceSeason = _context.Seasons.FirstOrDefault(s => telemetry.Timestamp > s.StartDate && telemetry.Timestamp <= s.EndDate);

            telemetry.Year = raceSeason.Year;
            telemetry.Season = raceSeason.Season;
            telemetry.Week = raceSeason.Week;

            return telemetry;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //_context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TelemetryFileInfoRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #endregion
    }
}
