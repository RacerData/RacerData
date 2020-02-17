using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RacerData.iRacing.Service.Sessions.Data;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions.Adapters
{
    internal class TelemetryRepository : ITelemetryRepository
    {
        #region fields

        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public TelemetryRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public async Task<IList<TelemetryData>> GetTelemetriesAsync()
        {
            var telemetryModels = await _context.TelemetryData.ToListAsync();

            IList<TelemetryData> results = _mapper.Map<IList<TelemetryData>>(telemetryModels);

            return results;
        }

        public async Task<TelemetryData> GetTelemetryAsync(long id)
        {
            var telemetryModel = await _context.TelemetryData.FindAsync(id);

            if (telemetryModel == null)
            {
                return null;
            }

            return _mapper.Map<TelemetryData>(telemetryModel);
        }

        public async Task<TelemetryData> GetTelemetryAsync(string fileName)
        {
            var telemetryModel = await _context.TelemetryData.FirstOrDefaultAsync(t=>t.FileName== fileName);

            if (telemetryModel == null)
            {
                return null;
            }

            return _mapper.Map<TelemetryData>(telemetryModel);
        }

        public async Task<TelemetryData> InsertTelemetryAsync(TelemetryData telemetry)
        {
            if (telemetry == null)
            {
                throw new ArgumentException(nameof(telemetry));
            }

            var telemetryModel = _mapper.Map<TelemetryModel>(telemetry);

            _context.TelemetryData.Add(telemetryModel);

            await _context.SaveChangesAsync();

            return await GetTelemetryAsync(telemetryModel.Id);
        }

        public async Task<TelemetryData> UpdateTelemetryAsync(TelemetryData telemetry)
        {
            if (telemetry == null)
            {
                throw new ArgumentException(nameof(telemetry));
            }

            var telemetryModel = await _context.TelemetryData.FindAsync(telemetry.Id);

            if (telemetryModel == null)
            {
                throw new ArgumentException(nameof(telemetry.Id));
            }

            _mapper.Map<TelemetryData, TelemetryModel>(telemetry, telemetryModel);

            await _context.SaveChangesAsync();

            return await GetTelemetryAsync(telemetry.Id);
        }

        #endregion
    }
}
