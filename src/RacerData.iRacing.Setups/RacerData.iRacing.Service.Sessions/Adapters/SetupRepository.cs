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
    internal class SetupRepository : ISetupRepository
    {
        #region fields

        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public SetupRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public void MarkSetupFileAsMoved(string fullPath)
        {
            var model = _context.SetupFilesIndex3.SingleOrDefault(f => f.FullPath == fullPath);

            model.Moved = true;

            _context.SaveChanges();
        }
        public SetupFile InsertSetupFile(SetupFile setupFile)
        {
            var model = _mapper.Map<SetupFileModel>(setupFile);

            _context.SetupFiles.Add(model);

            _context.SaveChanges();

            return _mapper.Map<SetupFile>(model);
        }

        public IList<SetupFile> GetSetupFiles()
        {
            var models = _context.SetupFiles.ToList();

            return _mapper.Map<IList<SetupFile>>(models);
        }
        public IList<DuplicateSetupFile> GetDuplicateSetupFiles()
        {
            var models = _context.DuplicateSetupFiles.ToList();

            return _mapper.Map<IList<DuplicateSetupFile>>(models);
        }

        public async Task<IList<Setup>> GetSetupsAsync()
        {
            var setupModels = await _context.Setups.ToListAsync();

            IList<Setup> results = _mapper.Map<IList<Setup>>(_context.Setups);

            return results;
        }

        public async Task<Setup> GetSetupAsync(long id)
        {
            var setupModel = await _context.Setups.FindAsync(id);

            if (setupModel == null)
            {
                return null;
            }

            return _mapper.Map<Setup>(setupModel);
        }

        public async Task<Setup> GetSetupAsync(long vehicleId, string name, int updateCount)
        {
            var setupModel = await _context.Setups.SingleOrDefaultAsync(s =>
                s.VehicleId == vehicleId &&
                s.Name == name &&
                s.UpdateCount == updateCount);

            if (setupModel == null)
            {
                return null;
            }

            return _mapper.Map<Setup>(setupModel);
        }

        public async Task<Setup> InsertSetupAsync(Setup setup)
        {
            if (setup == null)
            {
                throw new ArgumentException(nameof(setup));
            }

            var setupModel = _mapper.Map<SetupModel>(setup);

            if (setupModel.VehicleId > 0)
            {
                setupModel.Vehicle = _context.Vehicles.Find(setup.VehicleId);
            }

            _context.Setups.Add(setupModel);

            await _context.SaveChangesAsync();

            return _mapper.Map<Setup>(setupModel);
        }

        public async Task<Setup> UpdateSetupAsync(Setup setup)
        {
            if (setup == null)
            {
                throw new ArgumentException(nameof(setup));
            }

            var setupModel = await _context.Setups.FindAsync(setup.Id);

            if (setupModel == null)
            {
                throw new ArgumentException(nameof(setup.Id));
            }

            setupModel = _mapper.Map<Setup, SetupModel>(setup, setupModel);

            await _context.SaveChangesAsync();

            return _mapper.Map<Setup>(setupModel);
        }

        public IQueryable<Setup> GetSetupsQuery()
        {
            var vehicleSettingsList = _context.Setups
                .Include("Settings")
                .Include("Vehicle");

            var mapped = _mapper.ProjectTo<Setup>(vehicleSettingsList);

            return mapped;
        }

        public IQueryable<SetupValue> SearchSetupsQuery()
        {
            var setupValues = _context.SetupValues
                .Include(s => s.Property)
                .Include(s => s.SetupValueRuns)
                    .ThenInclude(svr => svr.Run);

            var mapped = _mapper.ProjectTo<SetupValue>(setupValues);

            return mapped;
        }

        public IList<Run> SearchSetupsList(long setupPropertyId, double? min, double? max)
        {
            var setupSearchQuery = _context.Runs
                .Include(r => r.TireReadings)
                .Include(r => r.SetupValues)
                    .ThenInclude(s => s.SetupValue)
                .Where(s => s.SetupValues.Any(sv => sv.SetupValue.SetupPropertyId == setupPropertyId));

            if (min.HasValue && !max.HasValue)
            {
                setupSearchQuery = setupSearchQuery
                    .Include(r => r.TireReadings)
                    .Include(r => r.SetupValues)
                        .ThenInclude(s => s.SetupValue)
                    .Where(s => s.SetupValues.Any(sv => sv.SetupValue.Value >= min.Value));
            }
            else if (!min.HasValue && max.HasValue)
            {
                setupSearchQuery = setupSearchQuery
                    .Include(r => r.TireReadings)
                    .Include(r => r.SetupValues)
                        .ThenInclude(s => s.SetupValue)
                    .Where(s => s.SetupValues.Any(sv => sv.SetupValue.Value <= max.Value));
            }
            else if (min.HasValue && max.HasValue)
            {
                setupSearchQuery = setupSearchQuery
                    .Include(r => r.TireReadings)
                    .Include(r => r.SetupValues)
                        .ThenInclude(s => s.SetupValue)
                    .Where(s => s.SetupValues.Any(sv => sv.SetupValue.Value >= min.Value && sv.SetupValue.Value <= max.Value));
            }

            var mapped = _mapper.Map<IList<Run>>(setupSearchQuery);

            return mapped;
        }

        #endregion
    }
}
